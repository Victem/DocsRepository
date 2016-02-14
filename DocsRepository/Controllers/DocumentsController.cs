using DocsRepository.Models;
using DocsRepositoryData.Abstract;
using DocsRepositoryData.Concrete;
using DocsRepositoryData.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;


namespace DocsRepository.Controllers
{
    [Authorize]
    public class DocumentsController : Controller
    {
        // GET: Documents
        private IDocumentsRepository documentsRepository;
       
        public DocumentsController(IDocumentsRepository repository)
        {
            documentsRepository = repository;
        }

        
        public ActionResult List(string searchTerm = null, string[] tags = null)
        {
            
            DocumentsListViewModel model = new DocumentsListViewModel();
            model.TotalRecordsCount = documentsRepository.Documents.Count();
            model.Documents = documentsRepository.Documents.ToList()
                                         .Where(d => (string.IsNullOrEmpty(searchTerm) || d.Name.ToLower().Contains(searchTerm.ToLower())))
                                         .Intersect(documentsRepository.Documents.ToList().Where(d=> tags==null || d.GetTags().Intersect(tags).Count()>0)).OrderBy(d => d.Name);
            
           if (Request.IsAjaxRequest())
           {
              return PartialView("_DocumentsList", model);
           }
           else 
           {
               //System.Threading.Thread.Sleep(5000);
               return View(model);
           }
            
        }


        public ActionResult Add()
        {
            return View(new AddDocumentViewModel());
        }




        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(AddDocumentViewModel model)
        {
            if (ModelState.IsValid)
            {
                Document d = new Document(model.Name, DateTime.Now.Date, User.Identity.Name, TagsToString(model.Tags));
                documentsRepository.AddDocument(d);
                return RedirectToAction("List");
            }
            else
            {
                ModelState.AddModelError("","Данные введены некорректно");
                return View();
            }
                
        }


        public ActionResult AutocompleteName(string term)
        {
            var model = documentsRepository.Documents
                        .Where(d => d.Name.Contains(term))
                        .Take(10)
                        .Select(d => new 
                            {
                                label = d.Name
                            });
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        public ActionResult AvailableTags(string term)
        {
            var model = GetTagsList(documentsRepository)
                        .Where(s => s.ToLower().StartsWith(term.ToLower()))
                        .Select(s => new { label = s });
            return Json(model, JsonRequestBehavior.AllowGet);
        }
      

        private IEnumerable<string> GetTagsList(IDocumentsRepository repository)
        {
            List<string> tags = new List<string>();

            foreach (Document d in repository.Documents)
            {
                tags.AddRange(d.GetTags());                
            }
            return tags.Distinct();
            
        }

        private string TagsToString(string[] tags)
        {
            if (tags!=null)
            {
                string tagsString = string.Empty;
                foreach (string tag in tags)
                {
                    tagsString += tag + ",";
                }
                return tagsString.Remove(tagsString.Length - 1, 1);
            }
            return null;            
        }

        public JsonResult ValidateName(string name)
        {
            Document doc = (documentsRepository.Documents.Where(d => d.Name.ToLower().Equals(name.ToLower()))).FirstOrDefault();
            if (doc != null)
                return Json("", JsonRequestBehavior.AllowGet);
            else
                return Json(true, JsonRequestBehavior.AllowGet);
        }

        
        public FileResult GetFile(int id)
        {
            Document doc = documentsRepository.Documents.FirstOrDefault(d => d.Id == id );
            if (doc != null)
            {
                byte[] arr = ASCIIEncoding.Unicode.GetBytes(doc.ToString());
                return File(arr, "text", doc.Name + ".txt");
            }
            else
                return null;

        }
    }
}