using DogQuiz.Data.Dtos;

namespace DogQuiz.API.Services.Interfaces;

public interface ITagService
{
	Task<IEnumerable<TagDto>> GetAllTagsAsync();
	Task<TagDto> AddTagAsync(TagCreateDto tagCreateDto);
	Task<bool> DeleteTagAsync(int tagId);
	Task<IEnumerable<TagGroupDto>> GetTagGroupsAsync();
}
