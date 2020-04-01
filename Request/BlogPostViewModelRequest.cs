using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogPost_WebAPI.Request
{
    public class BlogPostViewModelRequest
    {
        public string Slug { get; set; }
        public string Title { get; set; }

        public string Description { get; set; }

        public string Body { get; set; }

        public List<string> Tags { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
