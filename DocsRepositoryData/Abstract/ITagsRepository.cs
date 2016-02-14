using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocsRepositoryData.Abstract
{
    public interface ITagsRepository
    {
        IQueryable<string> Tags { get; set; }

        void AddTags(string[] tags);

        void AddTag(string tag);
    }
}
