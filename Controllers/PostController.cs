using BlogPost_WebAPI.Interface;
using BlogPost_WebAPI.Models;
using BlogPost_WebAPI.Request;
using BlogPost_WebAPI.Response;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace BlogPost_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController: ControllerBase
    {
        IBlogPosts blogPosts;

        public PostController(IBlogPosts _blogPosts)
        {
            blogPosts = _blogPosts;
        }

        [HttpGet]
        [Route("/api/tags")]
        public async Task<IActionResult> GetTags()
        {
            try
            {
                var tags = await blogPosts.GetTags();
                if (tags == null)
                {
                    return NotFound();
                }

                return Ok(tags);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }


        [HttpGet]
        [Route("/api/posts")]
        public async Task<IActionResult> GetPosts(string tag = "")
        {
            try
            {
                var posts = await blogPosts.GetPostTags(tag);
                if (posts == null)
                {
                    return NotFound();
                }

                return Ok(posts);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }


        [HttpGet]
        [Route("/api/posts/{slug}")]
        public async Task<IActionResult> GetPost(string slug)
        {
            try
            {
                var post = await blogPosts.GetPost(slug);
                if (post == null)
                {
                    return NotFound();
                }

                return Ok(post);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("/api/posts")]
        public async Task<IActionResult> AddPost(BlogPostTagViewModelRequest model)
        {
            if(ModelState.IsValid)
            { 
                try
                {
                    var post = await blogPosts.AddPost(model);
                    if (post == null)
                    {
                        return NotFound();
                    }

                    return Ok(post);
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }


        [HttpDelete]
        [Route("/api/posts/{slug}")]
        public async Task<IActionResult> DeletePost(string slug)
        {
            try
            {
                var post = await blogPosts.DeletePost(slug);
                if (post == null)
                {
                    return NotFound();
                }

                return Ok(post);
            }
            catch (Exception ex)
            {
                string msg = ex.InnerException + " / " + ex.Message;
                return BadRequest();
            }
        }


        [HttpPut]
        [Route("/api/posts/{slug}")]
        public async Task<IActionResult> UpdatePost(string slug, BlogPostTagViewModelRequest model)
        {
            try
            {
                var post = await blogPosts.UpdatePost(slug, model);
                if (post == null)
                {
                    return NotFound();
                }

                return Ok(post);
            }
            catch (Exception ex)
            {
                string msg = ex.InnerException + " / " + ex.Message;
                return BadRequest();
            }
        }
    }
}
