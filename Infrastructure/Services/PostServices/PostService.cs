using System.Net;
using Dapper;
using Domain.Models;
using Domain.Response;
using Infrastructure.DataContext;

namespace Infrastructure.Services.PostServices;

public class PostService : IPostService
{
    private readonly DapperContext _context;
    public PostService(DapperContext context)
    {
        _context = context;
    }
    public async Task<Responses<string>> AddPostAsync(Post post)
    {
        try
        {
            var sql = $@"insert into posts(author_id,title,created_at,updated_at,published,contents)
                    values({post.AuthorId},'{post.Title}','{post.Created_At}','{post.Updated_At}','{post.Published}','{post.Content}')";
                    var inserted = await _context.Connection().ExecuteAsync(sql);
                    if(inserted > 0) return new Responses<string>("Added succesfylly !");
                    return new Responses<string>(HttpStatusCode.BadRequest,"Error");
        }
        catch (System.Exception e)
        {
            
            return new Responses<string>(HttpStatusCode.InternalServerError,e.Message);
        }
    }


    public async Task<Responses<Post>> GetPostByIdAsync(int id)
    {
        try
        {
            var sql = $@"select * from posts where id = {@id}";
            var selected = await _context.Connection().QueryFirstOrDefaultAsync<Post>(sql);
            if(selected != null ) return new Responses<Post>(selected);
            return new Responses<Post>(HttpStatusCode.BadRequest,"Not found");
        }
        catch (System.Exception e)
        {
            
            return new Responses<Post>(HttpStatusCode.InternalServerError,e.Message);
        }
    }

    public async Task<Responses<List<Post>>> GetPostsAsync()
    {
        try
        {
            var sql = $@"select * from posts";
            var selected = await _context.Connection().QueryAsync<Post>(sql);
            return new Responses<List<Post>>(selected.ToList());
        }
        catch (System.Exception e)
        {
          return new Responses<List<Post>>(HttpStatusCode.InternalServerError,e.Message);
        }
    }

    public async Task<Responses<string>> UpdatePostAsync(Post post)
    {
        try
        {
            var sql = $@"update posts set title='{post.Title}',updated_at='{post.Updated_At}',contents='{post.Content}' where id = {post.Id}";
            var updated = await _context.Connection().ExecuteAsync(sql);
            if(updated > 0) return new Responses<string>("Yet Updated!");
            return new Responses<string>(HttpStatusCode.BadRequest,"Error");
        }
        catch (System.Exception e)
        {
            
            return new Responses<string>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    public async Task<Responses<bool>> DeletePostAsync(int id)
    {
       try
       {
        var sql = @$"delete from posts where id = {@id}";
        var deleted = await _context.Connection().ExecuteAsync(sql);
        if(deleted > 0) return new Responses<bool>(true);
        return new Responses<bool>(HttpStatusCode.BadRequest,"Error",false);
       }
       catch (System.Exception e)
       {
        return new Responses<bool>(HttpStatusCode.InternalServerError,e.Message);
       }
    }

}
