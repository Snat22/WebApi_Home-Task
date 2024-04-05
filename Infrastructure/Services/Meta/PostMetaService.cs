using System.Net;
using Dapper;
using Domain.Models;
using Domain.Response;
using Infrastructure.DataContext;

namespace Infrastructure.Services.Meta;

public class PostMetaService : IPostMetaService
{
    private readonly DapperContext _context;
    public PostMetaService(DapperContext context)
    {
        _context = context; 
    }
    public async Task<Responses<string>> AddPostsMetaAsync(PostMeta add)
    {
        try
        {
            var sql = $@"insert into post_metas(post_id)
                values({add.Post_Id})";
                var inserted = await _context.Connection().ExecuteAsync(sql);
                if(inserted > 0) return new Responses<string>("Added succesfully !");
                return new Responses<string>(HttpStatusCode.BadRequest,"Error");
        }
        catch (System.Exception e)
        {
            return new Responses<string>(HttpStatusCode.InternalServerError,e.Message);
        }
    }

    

    public async Task<Responses<PostMeta>> GetPostMetaByIdAsync(int id)
    {
try
        {
            var sql = $@"select * from post_metas where id = {@id}";
                var selected = await _context.Connection().QueryFirstOrDefaultAsync<PostMeta>(sql);
                if(selected != null) return new Responses<PostMeta>(selected);
                return new Responses<PostMeta>(HttpStatusCode.BadRequest,"Not Found! ");
        }
        catch (System.Exception e)
        {
            return new Responses<PostMeta>(HttpStatusCode.InternalServerError,e.Message);
        }   
    }

    public async Task<Responses<List<PostMeta>>> GetPostsMetaAsync()
    {
try
        {
            var sql = $@"select * from post_metas";
                var selected = await _context.Connection().QueryAsync<PostMeta>(sql);
            return new Responses<List<PostMeta>>(selected.ToList());
        }
        catch (System.Exception e)
        {
            return new Responses<List<PostMeta>>(HttpStatusCode.InternalServerError,e.Message);
        }   
        }

    public async Task<Responses<string>> UpdatePostsMetaAsync(PostMeta upd)
    {
        try
        {
            var sql = $@"Update post_metas set post_id = {upd.Post_Id} where id = {upd.Id}";
                var updated = await _context.Connection().ExecuteAsync(sql);
                if(updated > 0) return new Responses<string>("Yet Updated !");
                return new Responses<string>(HttpStatusCode.BadRequest,"Not Found! ");
        }
        catch (System.Exception e)
        {
            return new Responses<string>(HttpStatusCode.InternalServerError,e.Message);
        }   
    }
    public async Task<Responses<bool>> DeletePostsMetaAsync(int id)
    {
try
        {
            var sql = $@"delete from post_metas where id = {@id}";
                var selected = await _context.Connection().ExecuteAsync(sql);
                if(selected != null) return new Responses<bool>(true);
                return new Responses<bool>(HttpStatusCode.BadRequest,"Not Found! ",false);
        }
        catch (System.Exception e)
        {
            return new Responses<bool>(HttpStatusCode.InternalServerError,e.Message);
        }  
        }

}
