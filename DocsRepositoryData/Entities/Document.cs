using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocsStorageData.Entities
{
    [Serializable]
    public class Document
    {

        public Document()
        { }

        public Document(string name, DateTime creationDate, string author, string tags)
        {
            Name = name;
            CreationDate = creationDate;
            Author = author;
            Tags = tags;
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public DateTime CreationDate { get; set; }

        public string Author { get; set; }

        //public List<string> Tags { get; set; }

        public string Tags { get; set; }

        public List<string> GetTags()
        {
            if (!string.IsNullOrEmpty(Tags))
            {
                List<string> tags = new List<string>();
                tags.AddRange(Tags.Split(','));
                return tags;
            }
            else
            {
                return null;
            }            
        }
    }
}
