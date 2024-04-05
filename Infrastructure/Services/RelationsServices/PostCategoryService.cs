using System.Net;
using Dapper;
using Domain.Models;
using Domain.Response;
using Infrastructure.DataContext;

namespace Infrastructure.Services.RelationsServices;

public class PostCategoryService : IPostCategoryService
{
        private readonly DapperContext _context;
        public PostCategoryService(DapperContext context)
        {
            _context = context;
        }
    public async Task<Responses<string>> AddPostCategoryAsync(PostCategory post)
    {
    try
        {
            var sql = $@"insert into post_categories(post_id,category_id)
                values({post.Post_Id},{post.Category_Id})";
                var inserted = await _context.Connection().ExecuteAsync(sql);
                if(inserted > 0) return new Responses<string>("Added succesfully !");
                return new Responses<string>(HttpStatusCode.BadRequest,"Error");
        }
        catch (System.Exception e)
        {
            return new Responses<string>(HttpStatusCode.InternalServerError,e.Message);
        }    }

    public async Task<Responses<List<PostCategory>>> GetPostCategoryAsync()
    {
        try
        {
            var sql = $@"select * from post_categories";
                var selected = await _context.Connection().QueryAsync<PostCategory>(sql);
                return new Responses<List<PostCategory>>(selected.ToList());
        }
        catch (System.Exception e)
        {
            return new Responses<List<PostCategory>>(HttpStatusCode.InternalServerError,e.Message);
        }
    }

    public async Task<Responses<PostCategory>> GetPostCategoryByIdAsync(int id)
    {
    try
        {
            var sql = $@"select * from post_categories where id = {@id}";
                var selected = await _context.Connection().QueryFirstOrDefaultAsync<PostCategory>(sql);
            if(selected !=null ) return new Responses<PostCategory>(selected);
            return new Responses<PostCategory>(HttpStatusCode.BadRequest,"Not Found!");
        }
        catch (System.Exception e)
        {
            return new Responses<PostCategory>(HttpStatusCode.InternalServerError,e.Message);
        }   
        }

    public async Task<Responses<string>> UpdatePostCategoryAsync(PostCategory post)
    {
try
        {
            var sql = $@"update from post_categories set post_id = {post.Post_Id},category_id = {post.Category_Id}";
                var updated = await _context.Connection().ExecuteAsync(sql);
            if(updated > 0) return new Responses<string>("Yet Updated!");
            return new Responses<string>(HttpStatusCode.BadRequest,"Error");
        }
        catch (System.Exception e)
        {
            return new Responses<string>(HttpStatusCode.InternalServerError,e.Message);
        }    }

        public async Task<Responses<bool>> DeletePostCategoryAsync(int id)
    {
try
        {
            var sql = $@"delete from post_categories where id = {@id}";
                var deleted = await _context.Connection().ExecuteAsync(sql);
            if(deleted > 0) return new Responses<bool>(true);
            return new Responses<bool>(HttpStatusCode.BadRequest,"Error",false);
        }
        catch (System.Exception e)
        {
            return new Responses<bool>(HttpStatusCode.InternalServerError,e.Message);
        }    }


}
