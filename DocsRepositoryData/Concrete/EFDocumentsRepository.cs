using DocsRepositoryData.Abstract;
using DocsRepositoryData.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocsRepositoryData.Concrete
{
    public class EFDocumentsRepository : IDocumentsRepository
    {

        EFDBContext context = new EFDBContext();
        public EFDocumentsRepository()
        {
            
        }

        public IQueryable<Document> Documents
        {
            get
            {
                return context.Documents;
            }
        }

        public void AddDocument(Document document)
        {
            context.Documents.Add(document);
            context.SaveChanges();
        }

        
    }
}
