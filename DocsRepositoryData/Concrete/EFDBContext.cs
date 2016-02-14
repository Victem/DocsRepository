using DocsStorageData.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocsStorageData.Concrete
{
    public class EFDBContext : DbContext
    {
        public EFDBContext() : base("DocsRepository")
        { }

        public DbSet<Document> Documents { get; set; }

        //public DbSet<Tag> Tags { get; set; }
    }
}
