using System.Net;
using Dapper;
using Domain.Models;
using Domain.Response;
using Infrastructure.DataContext;

namespace Infrastructure.Services.UserServices;

public class UserService : IUserService
{
    private readonly DapperContext _context;
    public UserService(DapperContext context)
    {
        _context = context;
    }
    public async Task<Responses<string>> AddUserAsync(User user)
    {
        try
        {
            var sql = $@"insert into users(firstname,lastname,phone,email,address)
            
                values('{user.FirstName}','{user.LastName}','{user.Phone}','{user.Email}','{user.Address}')";
                var inserted = await _context.Connection().ExecuteAsync(sql);
                if(inserted > 0 ) return new Responses<string>("Added Succesfully!");
                return new Responses<string>(HttpStatusCode.BadRequest,"Error");
        }
        catch (System.Exception e)
        {
            
            return new Responses<string>(HttpStatusCode.InternalServerError,e.Message);
        }
    }


    public async Task<Responses<User>> GetUserByIdAsync(int id)
    {
        try
        {
            
            var sql = $@"select * from users where id = {@id}";
            var selected = await _context.Connection().QueryFirstOrDefaultAsync<User>(sql);
            if(selected != null) return new Responses<User>(selected);
            return new Responses<User>(HttpStatusCode.BadRequest,"Not found!");
        }
        catch (System.Exception e)
        {
            
            return new Responses<User>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    public async Task<Responses<List<User>>> GetUsersAsync()
    {
        try
        {
            
        var sql = $@"select * from users";
        var selected = await _context.Connection().QueryAsync<User>(sql);
        return new Responses<List<User>>(selected.ToList());
        }
        catch (System.Exception e)
        {
            
            return new Responses<List<User>>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    public async Task<Responses<string>> UpdateUserAsync(User user)
    {
        try
        {
            var sql = $@"update users set firstname='{user.FirstName}',lastname='{user.LastName}',phone='{user.Phone}',email='{user.Email}',address='{user.Address}' where id ={user.Id}";
            var updateed = await _context.Connection().ExecuteAsync(sql);
            if(updateed > 0 ) return new Responses<string>("Yet Updated !");
            return new Responses<string>(HttpStatusCode.BadRequest,"Not Found!");

        }
        catch (System.Exception e)
        {
            
            return new Responses<string>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    
    public async Task<Responses<bool>> DeleteUserAsync(int id)
    {
        try
        {
            var sql = @$"delete from users where where id = {@id}";
            var deleted = await _context.Connection().ExecuteAsync(sql);
            if(deleted > 0) return new Responses<bool>(true);
            return new Responses<bool>(HttpStatusCode.BadRequest,"Error",false);
        }
        catch (System.Exception e)
        {
            
            return new Responses<bool>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

}
