using BlogPost_WebAPI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlogPost_WebAPI.Response
{
    public class BlogPostTagViewModelResponse
    {
        public BlogPostViewModelResponse BlogPosts { get; set; }

       // public List<TagResponse> TagList { get; set; }
       
    }
}
