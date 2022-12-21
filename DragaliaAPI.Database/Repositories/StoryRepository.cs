using DragaliaAPI.Database.Entities;
using DragaliaAPI.Shared.Definitions.Enums;
using Microsoft.EntityFrameworkCore;

namespace DragaliaAPI.Database.Repositories;

public class StoryRepository : BaseRepository, IStoryRepository
{
    private readonly ApiContext apiContext;

    public StoryRepository(ApiContext apiContext) : base(apiContext)
    {
        this.apiContext = apiContext;
    }

    public IQueryable<DbPlayerStoryState> GetStoryList(string deviceAccountId)
    {
        return this.apiContext.PlayerStoryState.Where(x => x.DeviceAccountId == deviceAccountId);
    }

    public async Task<DbPlayerStoryState> GetOrCreateStory(
        string deviceAccountId,
        StoryTypes storyType,
        int storyId
    )
    {
        return await apiContext.PlayerStoryState.SingleOrDefaultAsync(
                x => x.DeviceAccountId == deviceAccountId && x.StoryId == storyId
            )
            ?? apiContext.PlayerStoryState
                .Add(
                    new DbPlayerStoryState()
                    {
                        DeviceAccountId = deviceAccountId,
                        StoryId = storyId,
                        StoryType = storyType,
                        State = 0
                    }
                )
                .Entity;
    }
}
