using DocsStorageData.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocsStorageData.Abstract
{
    public interface IDocumentsRepository
    {
        IQueryable<Document> Documents { get; }

        void AddDocument(Document document);


    }
}
