using System.Net;
using Dapper;
using Domain.Models;
using Domain.Response;
using Infrastructure.DataContext;

namespace Infrastructure.Services.CommentServices;

public class CommentService : ICommentService
{
     private readonly DapperContext _context;
        public CommentService(DapperContext context)
        {
            _context = context;
        }

    public async Task<Responses<string>> AddCommentsAsync(PostComment comment)
    {
        try
        {
            var sql = $@"insert into post_comments(post_id,title,published)
                values({comment.Post_Id},'{comment.Title}','{comment.Published}')";
                    var inserted = await _context.Connection().ExecuteAsync(sql);
                    if(inserted > 0) return new Responses<string>("Added succesfylly !");
                    return new Responses<string>(HttpStatusCode.BadRequest,"Error");
        }
        catch (System.Exception e)
        {
            
            return new Responses<string>(HttpStatusCode.InternalServerError,e.Message);
        }
    }


    public async Task<Responses<PostComment>> GetCommentByIdAsync(int id)
    {
try
        {
            var sql = $@"select * from post_comment where id = {@id}";
            var selected = await _context.Connection().QueryFirstOrDefaultAsync<PostComment>(sql);
            if(selected != null ) return new Responses<PostComment>(selected);
            return new Responses<PostComment>(HttpStatusCode.BadRequest,"Not found");
        }
        catch (System.Exception e)
        {
            
            return new Responses<PostComment>(HttpStatusCode.InternalServerError,e.Message);
        }    }

    public async Task<Responses<List<PostComment>>> GetCommentsAsync()
    {
  try
        {
            var sql = $@"select * from posts";
            var selected = await _context.Connection().QueryAsync<PostComment>(sql);
            return new Responses<List<PostComment>>(selected.ToList());
        }
        catch (System.Exception e)
        {
          return new Responses<List<PostComment>>(HttpStatusCode.InternalServerError,e.Message);
        }    }

    public async Task<Responses<string>> UpdatedCommentAsync(PostComment comment)
    {
  try
        {
            var sql = $@"update post_comments set post_id = {comment.Post_Id} ,title='{comment.Title}' where id = {comment.Id}";
            var updated = await _context.Connection().ExecuteAsync(sql);
            if(updated > 0) return new Responses<string>("Yet Updated!");
            return new Responses<string>(HttpStatusCode.BadRequest,"Error");
        }
        catch (System.Exception e)
        {
            
            return new Responses<string>(HttpStatusCode.InternalServerError, e.Message);
        }    }

        public async Task<Responses<bool>> DeleteCommentsAsync(int id)
    {
 try
       {
        var sql = @$"delete from post_comments where id = {@id}";
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



