using DocsRepositoryData.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DocsRepository.Models
{
    public class DocumentsListViewModel
    {
        public IEnumerable<Document> Documents { get; set; }

        public int CurrentRecordCount{ get { return Documents.Count(); } }

        public int TotalRecordsCount { get; set; }
    }
}