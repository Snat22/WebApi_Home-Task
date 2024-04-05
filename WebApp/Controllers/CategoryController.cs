using Domain.Models;
using Domain.Response;
using Infrastructure.Services.CategoryServices;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;

[Route("/api/Category")]
[ApiController]
public class CategoryController(ICategoryService categoryService) :ControllerBase
{
    private readonly ICategoryService _categoryService = categoryService;

    [HttpGet]
    public async Task<Responses<List<Category>>> GetCategories()
    {
        return await _categoryService.GetCategoryAsync();
    }
    
    [HttpGet("categoryId:int")]
    public async Task<Responses<Category>> GetCategoriesById(int categoryId)
    {
        return await _categoryService.GetCategoryByIdAsync(categoryId);
    }

    
    [HttpPost]
    public async Task<Responses<string>> AddCategories( Category add)
    {
        return await _categoryService.AddCategoryAsync(add);
    }

    
    [HttpPut]
    public async Task<Responses<string>> UpdateCategories( Category upd)
    {
        return await _categoryService.UpdateCategoryAsync(upd);
    }

    
    [HttpDelete("{categoryId:int}")]
    public async Task<Responses<bool>> DeleteCategory(int categoryId)
    {
        return await _categoryService.DeleteCategoryAsync(categoryId);
    }
}
