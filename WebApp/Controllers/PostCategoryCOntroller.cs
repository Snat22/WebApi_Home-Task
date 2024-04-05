using Domain.Response;
using Infrastructure.Services.RelationsServices;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;

[Route("/api/PostCategory")]
[ApiController]
public class PostCategoryCOntroller(IPostCategoryService postCategoryService) :ControllerBase
{
    private readonly IPostCategoryService _postCategoryService = postCategoryService;

    
    [HttpGet]
    public async Task<Responses<List<PostCategoryService>>> GetPostCategoryServices()
    {
        return await _postCategoryService.GetPostCategoryAsync();
    }
    
    [HttpGet("CAPostCategoryServicesId:int")]
    public async Task<Responses<PostCategoryService>> GetCAPostCategoryServicesById(int CAPostCategoryServicesId)
    {
        return await _postCAPostCategoryServiceService.GetPostCategoryServiceByIdAsync(CAPostCategoryServicesId);
    }

    
    [HttpPost]
    public async Task<Responses<string>> AddCAPostCategoryServices(PostCategoryService add)
    {
        return await _postCAPostCategoryServiceService.AddPostsCAPostCategoryServiceAsync(add);
    }

    
    [HttpPut]
    public async Task<Responses<string>> UpdateCAPostCategoryServices(PostCategoryService upd)
    {
        return await _postCAPostCategoryServiceService.UpdatePostsCAPostCategoryServiceAsync(upd);
    }

    
    [HttpDelete("{CAPostCategoryServicesyId:int}")]
    public async Task<Responses<bool>> DeleteCAPostCategoryServices(int CAPostCategoryServicesyId)
    {
        return await _postCAPostCategoryServiceService.DeletePostsCAPostCategoryServiceAsync(CAPostCategoryServicesyId);
    }

}
