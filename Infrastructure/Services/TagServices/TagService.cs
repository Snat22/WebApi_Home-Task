using System.Net;
using Dapper;
using Domain.Models;
using Domain.Response;
using Infrastructure.DataContext;

namespace Infrastructure.Services.TagServices;

public class TagService : ITegService
{
        private readonly DapperContext _context;
        public TagService(DapperContext context)
        {
            _context = context;
        }
    public async Task<Responses<string>> AddTagsAsync(Tag tag)
    {
        try
        {
            var sql = $@"insert into tags(title)
            values('{tag.Title}')";
            var inserted = await _context.Connection().ExecuteAsync(sql);
            if(inserted > 0) return new Responses<string>("Added succesfully !");
            return new Responses<string>(HttpStatusCode.BadRequest,"Error");
        }
        catch (System.Exception e)
        {
            
            return new Responses<string>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    

    public async Task<Responses<Tag>> GetTagByIdAsync(int id)
    {
        try
        {
        var sql = $@"select * from tags where id={@id}";
        var selected = await _context.Connection().QueryFirstOrDefaultAsync<Tag>(sql);
        if(selected != null) return new Responses<Tag>(selected);
        return new Responses<Tag>(HttpStatusCode.BadRequest,"Not Found");   
        }
        catch (System.Exception e)
        {
            return new Responses<Tag>(HttpStatusCode.InternalServerError,e.Message);
        }
    }

    public async Task<Responses<List<Tag>>> GetTagsAsync()
    {
        try
        {
            var sql = $@"select * from tags";
            var selected = await _context.Connection().QueryAsync<Tag>(sql);
            return new Responses<List<Tag>>(selected.ToList());
        }
        catch (System.Exception e)
        {
            return new Responses<List<Tag>>(HttpStatusCode.InternalServerError,e.Message);
        }
    }

    public async Task<Responses<string>> UpdatedTagAsync(Tag tag)
    {
        try
        {
        var sql = $@"update tags set title='{tag.Title}' where id = {tag.Id}";
        var updated = await _context.Connection().ExecuteAsync(sql);
        if(updated > 0) return new Responses<string>("Yet Updated");
        return new Responses<string>(HttpStatusCode.BadRequest,"Error");   
        }
        catch (System.Exception e)
        {
            
            return new Responses<string>(HttpStatusCode.InternalServerError,e.Message);
        }
    }

    public async Task<Responses<bool>> DeleteTags(int id)
    {
        try
        {
            var sql = @$"delete from tags where id = {@id}";
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
