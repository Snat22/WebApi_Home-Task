using Domain.Models;
using Domain.Response;

namespace Infrastructure.Services.TagServices;

public interface ITegService
{
    Task<Responses<List<Tag>>> GetTagsAsync();
    Task<Responses<Tag>> GetTagByIdAsync(int id);
    Task<Responses<string>> AddTagsAsync(Tag tag);
    Task<Responses<string>> UpdatedTagAsync(Tag tag);
    Task<Responses<bool>> DeleteTags(int id);
}
