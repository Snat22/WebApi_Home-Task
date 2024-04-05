using System.Net;
using Dapper;
using Domain.Models;
using Domain.Response;
using Infrastructure.DataContext;

namespace Infrastructure.Services.RelationsServices;

public class PostTagsSErvice : IPostTagsService
{
    private readonly DapperContext _context;
    public PostTagsSErvice(DapperContext context)
    {
        _context = context;
    }
    public async Task<Responses<string>> AddPostTagsAsync(PostTag add)
    {
        try
        {
            var sql = $@"insert into post_tags(post_id,tag_id)
            values({add.Post_Id},{add.Tag_Id})";
            var inserted = await _context.Connection().ExecuteAsync(sql);
            if(inserted > 0) return new Responses<string>("Added Succesfully!");
            return new Responses<string>(HttpStatusCode.BadRequest,"Error");
        }
        catch (System.Exception e)
        {
            
            return new Responses<string>(HttpStatusCode.InternalServerError,e.Message);
        }
    }

    public async Task<Responses<List<PostTag>>> GetPostTagsAsync()
    {
        try
        {
           var sql = $@"select * from post_tags";
           var selected = await _context.Connection().QueryAsync<PostTag>(sql);
           return new Responses<List<PostTag>>(selected.ToList()); 
        }
        catch (System.Exception e)
        {
            
            return new Responses<List<PostTag>>(HttpStatusCode.InternalServerError,e.Message);
        }
    }

    public async Task<Responses<PostTag>> GetPostTagsByIdAsync(int id)
    {

        try
        {
           var sql = $@"select * from post_tags where id = {@id}";
           var selected = await _context.Connection().QueryFirstOrDefaultAsync<PostTag>(sql);
           if(selected != null) return new Responses<PostTag>(selected);
           return new Responses<PostTag>(HttpStatusCode.BadRequest,"Not Found!"); 
        }
        catch (System.Exception e)
        {
            
            return new Responses<PostTag>(HttpStatusCode.InternalServerError,e.Message);
        }    }

    public async Task<Responses<string>> UpdatePostTagsAsync(PostTag upd)
    {

        try
        {
        var sql = $@"update from post_tags set post_id = {upd.Post_Id},tag_id = {upd.Tag_Id} where id = {upd.Id}";
        var updated = await _context.Connection().ExecuteAsync(sql);
        if( updated > 0) return new Responses<string>("Yet Updated!");
        return new Responses<string>(HttpStatusCode.BadRequest,"Error");
        }
        catch (System.Exception e)
        {
            
            return new Responses<string>(HttpStatusCode.InternalServerError,e.Message);
        }   
        }

        public async Task<Responses<bool>> DeletePostTagsAsync(int id)
    {

        try
        {
           var sql = $@"delete from post_tags where id = {@id}";
            var deleted = await _context.Connection().ExecuteAsync(sql);
        if(deleted > 0) return new Responses<bool>(true);
        return new Responses<bool>(HttpStatusCode.InternalServerError,"Error",false);
        }
        catch (System.Exception e)
        {
            
            return new Responses<bool>(HttpStatusCode.InternalServerError,e.Message);
        }    }

}
