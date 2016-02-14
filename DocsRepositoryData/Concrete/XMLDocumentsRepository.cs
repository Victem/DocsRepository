using DocsStorageData.Abstract;
using DocsStorageData.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DocsStorageData.Concrete
{
    public class XMLDocumentsRepository : IDocumentsRepository
    {
       
        private string xmlPath = AppDomain.CurrentDomain.BaseDirectory+"/App_Data/Documents.xml";
        private List<Document> documentsRepository; 

        public XMLDocumentsRepository()
        {
            XmlLoad();
        }
        public IQueryable<Document> Documents
        {
            get
            {
                return documentsRepository.AsQueryable<Document>();
            }
        }

        public void AddDocument(Document document)
        {
            this.documentsRepository.Add(document);
            SaveAsXml(this.documentsRepository);
        }


        private void SaveAsXml(List<Document> documentsList)
        {
            XmlSerializer xmlFormat = new XmlSerializer(typeof(List<Document>));
            using (Stream stream = new FileStream(xmlPath, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                xmlFormat.Serialize(stream, documentsList);
            }
        }

        private void XmlLoad()
        {
            try
            {
                XmlSerializer xmlData = new XmlSerializer(typeof(List<Document>));
                using (Stream stream = File.OpenRead(xmlPath))
                {
                    documentsRepository = (List<Document>)xmlData.Deserialize(stream);
                }
            }
            catch (Exception e)
            {
                DefaultXMLData data = new DefaultXMLData();
                documentsRepository = data.DefaultData;
            }
        }

       
    }
}
