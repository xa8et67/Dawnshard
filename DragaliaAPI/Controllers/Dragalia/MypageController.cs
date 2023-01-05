using Microsoft.AspNetCore.Mvc;
using MessagePack.Resolvers;
using MessagePack;
using DragaliaAPI.Models.Generated;
using DragaliaAPI.Services;

namespace DragaliaAPI.Controllers.Dragalia;

[Route("mypage")]
[ApiController]
public class MypageController : DragaliaControllerBase
{
    private readonly ISummonService summonService;
    private readonly IFriendService friendService;
    private readonly IPresentService presentService;
    private readonly IMissionService missionService;
    private readonly IGuildService guildService;
    private readonly IShopService shopService;

    public MypageController(
        ISummonService summonService,
        IFriendService friendService,
        IPresentService presentService,
        IMissionService missionService,
        IGuildService guildService,
        IShopService shopService
    )
    {
        this.summonService = summonService;
        this.friendService = friendService;
        this.presentService = presentService;
        this.missionService = missionService;
        this.guildService = guildService;
        this.shopService = shopService;
    }

    [HttpPost("info")]
    public DragaliaResult Info()
    {
        MypageInfoData response =
            new()
            {
                user_summon_list = summonService.GetUserSummonList(),
                is_shop_notification = true,
                is_receive_event_damage_reward = true,
                is_view_start_dash = true,
                is_view_dream_select = true,
                quest_event_schedule_list = new List<QuestEventScheduleList>() { },
                quest_schedule_detail_list = new List<QuestScheduleDetailList>() { },
                update_data_list = new()
                {
                    friend_notice = friendService.GetNotice(),
                    present_notice = presentService.GetNotice(),
                    mission_notice = missionService.GetNotice(),
                    guild_notice = guildService.GetNotice(),
                    shop_notice = shopService.GetNotice(),
                }
            };

        return this.Ok(response);
    }
}
