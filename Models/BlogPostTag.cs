using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogPost_WebAPI.Models
{
    public class BlogPostTag
    {
        public string BlogPostId { get; set; }
        public BlogPost BlogPost { get; set; }
        public string TagId { get; set; }
        public Tag Tag { get; set; }
    }
}
