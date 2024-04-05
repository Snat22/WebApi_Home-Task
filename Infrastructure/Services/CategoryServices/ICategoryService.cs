using Domain.Models;
using Domain.Response;

namespace Infrastructure.Services.CategoryServices;

public interface ICategoryService
{
    Task<Responses<List<Category>>> GetCategoryAsync();
    Task<Responses <Category>> GetCategoryByIdAsync(int id);
    Task<Responses <string>> AddCategoryAsync(Category add);
    Task<Responses<string>> UpdateCategoryAsync(Category upd);
    Task<Responses<bool>> DeleteCategoryAsync(int id);
    
    
    
    
}
