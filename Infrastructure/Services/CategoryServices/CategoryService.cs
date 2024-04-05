using System.Net;
using Dapper;
using Domain.Models;
using Domain.Response;
using Infrastructure.DataContext;

namespace Infrastructure.Services.CategoryServices;

public class CategoryService : ICategoryService
{
    private readonly DapperContext _context;
    public CategoryService(DapperContext context)
    {
        _context =context;
    }
    public async Task<Responses<string>> AddCategoryAsync(Category add)
    {
        try
        {
            var sql = $@"insert into categories(title)
            values('{add.Title}')";
            var inserted = await _context.Connection().ExecuteAsync(sql);
            if(inserted > 0) return new Responses<string>("Added Succesfully ! ");
            return new Responses<string>(HttpStatusCode.BadRequest,"Error");
        }
        catch (System.Exception e)
        {
            
            return new Responses<string>(HttpStatusCode.InternalServerError,e.Message);
        }
    }


    public async Task<Responses<List<Category>>> GetCategoryAsync()
    {
    try
        {
            var sql = $@"select * from categories";
            var selected = await _context.Connection().QueryAsync<Category>(sql);
            return new Responses<List<Category>>(selected.ToList());
        }
        catch (System.Exception e)
        {
            
            return new Responses<List<Category>>(HttpStatusCode.InternalServerError,e.Message);
        }   
     }

    public async Task<Responses<Category>> GetCategoryByIdAsync(int id)
    {
        try
        {
            var sql = $@"select * from categories where id = {@id}";
            var selected = await _context.Connection().QueryFirstOrDefaultAsync<Category>(sql);
            if(selected != null) return new Responses<Category>(selected);
            return new Responses<Category>(HttpStatusCode.BadRequest,"Not Found!");
        }
        catch (System.Exception e)
        {
            
            return new Responses<Category>(HttpStatusCode.InternalServerError,e.Message);
        } 
    }

    public async Task<Responses<string>> UpdateCategoryAsync(Category upd)
    {
try
        {
            var sql = $@"update categories set title = '{upd.Title}' where id = {upd.Id}";
            var updated = await _context.Connection().ExecuteAsync(sql);
            if(updated > 0) return new Responses<string>("Yet Updated!");
            return new Responses<string>(HttpStatusCode.BadRequest,"Error");
        }
        catch (System.Exception e)
        {
            
            return new Responses<string>(HttpStatusCode.InternalServerError,e.Message);
        }  
    }

    
    public async Task<Responses<bool>> DeleteCategoryAsync(int id)
    {
try
        {
            var sql = $@"delete from categories where id = {@id}";
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
