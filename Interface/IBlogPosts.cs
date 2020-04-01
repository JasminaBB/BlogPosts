using BlogPost_WebAPI.Models;
using BlogPost_WebAPI.Request;
using BlogPost_WebAPI.Response;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogPost_WebAPI.Interface
{
    public interface IBlogPosts
    {
        Task<List<string>> GetTags();

        Task<List<BlogPostViewModelResponse>> GetPostTags(string tag);

        Task<BlogPostViewModelResponse> GetPost(string slug);

        Task<BlogPostViewModelResponse> AddPost(BlogPostTagViewModelRequest post);

        Task<string> DeletePost(string slug);

        Task<BlogPostViewModelResponse> UpdatePost(string slug, BlogPostTagViewModelRequest post);

    }
}
