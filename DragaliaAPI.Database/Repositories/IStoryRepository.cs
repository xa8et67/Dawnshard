using DragaliaAPI.Database.Entities;
using DragaliaAPI.Shared.Definitions.Enums;

namespace DragaliaAPI.Database.Repositories;

public interface IStoryRepository
{
    public IQueryable<DbPlayerStoryState> GetStoryList(string deviceAccountId);
    public Task<DbPlayerStoryState> GetOrCreateStory(
        string deviceAccountId,
        StoryTypes storyType,
        int storyId
    );
}
