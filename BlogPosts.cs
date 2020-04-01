using BlogPost_WebAPI.Context;
using BlogPost_WebAPI.Helpers;
using BlogPost_WebAPI.Interface;
using BlogPost_WebAPI.Models;
using BlogPost_WebAPI.Request;
using BlogPost_WebAPI.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;


namespace BlogPost_WebAPI
{
    public class BlogPosts : IBlogPosts
    {
        BlogPostContext db;
        private readonly HttpContext _context;
        

        public BlogPosts(BlogPostContext _db, IHttpContextAccessor httpContextAccessor)
        {
            db = _db;
            _context = httpContextAccessor.HttpContext;
        }
        public async Task<BlogPostViewModelResponse> AddPost(BlogPostTagViewModelRequest post)
        {
            Models.BlogPost blogPost = new Models.BlogPost();
            blogPost.Tags = new List<BlogPostTag>();
            Tag tag = new Tag();
            BlogPostViewModelResponse response = new BlogPostViewModelResponse();
            BlogPostTag blogPostTag = new BlogPostTag();
            tag.BlogPosts = new List<BlogPostTag>();

            if (db != null)
            {
                //get generated slug
                string slug = Helpers.GenerateSlug.ToUrlSlug(post.BlogPost.Title);
                //blogPost.Id - automatic generated
                blogPost.Slug = response.Slug = slug;
                blogPost.Title = response.Title = post.BlogPost.Title;
                blogPost.Description = response.Description = post.BlogPost.Description;
                blogPost.Body = response.Body = post.BlogPost.Body;
                blogPost.CreatedAt = response.CreatedAt = DateTime.Now;
                blogPost.UpdatedAt = response.UpdatedAt = DateTime.Now;
                response.tagList = post.BlogPost.Tags;

                //checking tags
                List<string> list = await GetTags();
                //records exist in new list /not in db list
                List<string> dList = post.BlogPost.Tags.Except(list).ToList();
                //add new records in Tag table
                for (int i = 0; i < dList.Count; i++)
                {
                    string name = dList.ElementAt(i);
                    tag.Name = name;
                    
                    
                    blogPostTag.BlogPost = blogPost;
                    blogPostTag.Tag = tag;
                    blogPostTag.BlogPost.Tags.Add(blogPostTag);
                    //db.SaveChanges();
                }
                await db.Tags.AddAsync(tag);
                await db.BlogPosts.AddAsync(blogPost);
                await db.BlogPostTag.AddAsync(blogPostTag);
                await db.SaveChangesAsync();

                return response;
            }
            return response;
        }

        public async Task<string> DeletePost(string slug)
        {
            if (db != null)
            {
                Models.BlogPost post = db.BlogPosts.Include(p => p.Tags).Where(p => p.Slug == slug).FirstOrDefault();
                if (post != null)
                {
                    //create BlogPostTag object for delete (relationship with BlogPost table
                    BlogPostTag blogPostTag = new BlogPostTag();
                    //get BlogPostId from BlogPostTag table, include all Tags
                    blogPostTag = db.BlogPostTag
                                    .Include(b => b.BlogPost)
                                    .Include(b => b.Tag)
                                    .Where(b => b.BlogPostId == post.Id).FirstOrDefault();
                    if (blogPostTag != null)
                    {
                        db.BlogPostTag.Remove(blogPostTag);
                        db.BlogPosts.Remove(post);
                        db.SaveChanges();
                    }
                }
            }
            return "Record successfully deleted!";
        }

        public Task<List<Models.BlogPost>> GetBlogPosts()
        {
            throw new NotImplementedException();
        }

        public async Task<BlogPostViewModelResponse> GetPost(string slug)
        {
            if (db != null)
            {
                if (!String.IsNullOrEmpty(slug))
                {
                    List<BlogPostTag> list = db.BlogPostTag
                                         .Include(b => b.BlogPost)
                                         .Include(t => t.Tag)
                                         .Where(b => b.BlogPost.Slug == slug && b.BlogPostId == b.BlogPost.Id).ToList();

                    return          list
                                    .Select(s => new BlogPostViewModelResponse
                                    {
                                        Slug = s.BlogPost.Slug,
                                        Title = s.BlogPost.Title,
                                        Description = s.BlogPost.Description,
                                        Body = s.BlogPost.Body,
                                        CreatedAt = s.BlogPost.CreatedAt,
                                        UpdatedAt = s.BlogPost.UpdatedAt,
                                        tagList = ConvertToListString(s.BlogPost.Tags.ToList())
                                    }
                                  ).Distinct().FirstOrDefault();
                }
                
            }
            return null;
        }

        public async Task<List<BlogPostViewModelResponse>> GetPostTags(string tag)
        {
            
            if (db != null)
            {
                if (!String.IsNullOrEmpty(tag))
                {
                    List<BlogPostTag> list = db.BlogPostTag
                                    .Include(b => b.BlogPost)
                                    .Include(t => t.Tag)
                                    .Where(b => b.Tag.Name == tag && b.BlogPostId == b.BlogPost.Id).ToList();

                    return          list
                                    .Select(s => new BlogPostViewModelResponse
                                    {
                                        Slug = s.BlogPost.Slug,
                                        Title = s.BlogPost.Title,
                                        Description = s.BlogPost.Description,
                                        Body = s.BlogPost.Body,
                                        CreatedAt = s.BlogPost.CreatedAt,
                                        UpdatedAt = s.BlogPost.UpdatedAt,
                                        tagList = ConvertToListString(s.BlogPost.Tags.ToList())
                                    }
                                  ).Distinct().OrderByDescending(x => x.CreatedAt).ToList();
                }
                else
                {

                    List<BlogPostTag> list = db.BlogPostTag
                                     .Include(b => b.BlogPost)
                                     .Include(t => t.Tag)
                                     .Where(b => b.BlogPostId == b.BlogPost.Id)
                                     .Distinct().ToList();

                             return list
                                    .Select(s => new BlogPostViewModelResponse
                                    {
                                        Slug = s.BlogPost.Slug,
                                        Title = s.BlogPost.Title,
                                        Description = s.BlogPost.Description,
                                        Body = s.BlogPost.Body,
                                        CreatedAt = s.BlogPost.CreatedAt,
                                        UpdatedAt = s.BlogPost.UpdatedAt,
                                        tagList = ConvertToListString(s.BlogPost.Tags.ToList())
                                    }
                                  ).OrderByDescending(x => x.CreatedAt).ToList();
                }
            }
            return null;
        }

        private List<string> ConvertToListString(List<BlogPostTag> tags)
        {
            object obj = tags.Select(t => t.Tag.Name).ToList();

            var list = ((IEnumerable)obj).OfType<object>();
            List<string> strings = list.Select(s => s.ToString()).ToList();
            return strings;
        } 

        public async Task<BlogPostViewModelResponse> UpdatePost(string slug, BlogPostTagViewModelRequest model)
        {
            BlogPostViewModelResponse response = new BlogPostViewModelResponse();
            Models.BlogPost blog = new Models.BlogPost();
            blog.Tags = new List<BlogPostTag>();
            if (db != null)
            {
                BlogPostTag foundPost = db.BlogPostTag
                                                .AsNoTracking()
                                                .Include(p => p.BlogPost)
                                                .Include(p => p.Tag)
                                                .Where(p => p.BlogPost.Slug == slug).FirstOrDefault();

                if (!String.IsNullOrEmpty(model.BlogPost.Title) && model.BlogPost.Title != foundPost.BlogPost.Title)
                {
                    blog.Title = response.Title = model.BlogPost.Title;
                    blog.Slug = response.Slug = GenerateSlug.ToUrlSlug(blog.Title);
                }
                blog.Id = foundPost.BlogPostId;
                blog.CreatedAt = foundPost.BlogPost.CreatedAt;
                blog.UpdatedAt = response.UpdatedAt = DateTime.Now;
                blog.Description = response.Description 
                                 = !String.IsNullOrEmpty(model.BlogPost.Description) ? model.BlogPost.Description : foundPost.BlogPost.Description;
                blog.Body = response.Body
                          = !String.IsNullOrEmpty(model.BlogPost.Body) ? model.BlogPost.Body : foundPost.BlogPost.Body;
                if (model.BlogPost.Tags != null)
                    response.tagList = model.BlogPost.Tags;
                else
                {
                    blog.Tags = foundPost.BlogPost.Tags;
                    response.tagList = ConvertToListString(foundPost.BlogPost.Tags);
                } 

                db.BlogPosts.Update(blog);
                await db.SaveChangesAsync();
            }
            return response;
        }

        public async Task<List<string>> GetTags()
        {
            if (db != null)
            {
                object obj = await (from t in db.Tags
                                    select t.Name).ToListAsync();

                var list = ((IEnumerable)obj).OfType<object>();
                List<string> strings = list.Select(s => s.ToString()).ToList();
                return strings;
            }
            return null;
        }
    }
}
