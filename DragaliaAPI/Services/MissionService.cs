using DragaliaAPI.Models.Generated;

namespace DragaliaAPI.Services;

public class MissionService
{
    public IEnumerable<MissionNotice> GetNotice() { }

    private static class StubData
    {
        public static readonly MissionGetMissionListData MissionList =
            new()
            {
                normal_mission_list = NormalMissions,
                daily_mission_list = DailyMissions,
                period_mission_list = PeriodMissions,
                beginner_mission_list = new List<BeginnerMissionList>(),
                special_mission_list = SpecialMissions,
                special_mission_purchased_group_id_list = new List<int>(),
                main_story_mission_list = new List<MainStoryMissionList>(),
                current_main_story_mission = new CurrentMainStoryMission()
                {
                    main_story_mission_group_id = 0,
                    main_story_mission_state_list = new List<AtgenMainStoryMissionStateList>()
                },
                memory_event_mission_list = new List<MemoryEventMissionList>(),
                album_mission_list = AlbumMissions,
                mission_notice = EmptyMissionNoticeData
            };

        public static readonly MissionNotice EmptyMissionNoticeData =
            new(
                EmptyMissionNotice,
                EmptyMissionNotice,
                EmptyMissionNotice,
                EmptyMissionNotice,
                EmptyMissionNotice,
                EmptyMissionNotice,
                EmptyMissionNotice,
                EmptyMissionNotice,
                EmptyMissionNotice
            );

        public static readonly List<DrillMissionList> DrillMissions = new();

        private static readonly DateTimeOffset StartDate = DateTime.UtcNow.AddDays(-1);
        private static readonly DateTimeOffset EndDate = DateTime.UtcNow.AddDays(365);

        private static readonly List<NormalMissionList> NormalMissions =
            new()
            {
                new()
                {
                    normal_mission_id = 10000101,
                    progress = 0,
                    state = 0,
                    start_date = StartDate,
                    end_date = EndDate
                }
            };

        private static readonly List<DailyMissionList> DailyMissions =
            new()
            {
                new()
                {
                    daily_mission_id = 15070101,
                    progress = 100,
                    state = 1,
                    day_no = 0,
                    week_no = 0,
                    start_date = DateTimeOffset.UtcNow.AddDays(-1),
                    end_date = DateTimeOffset.UtcNow.AddDays(365),
                    is_lock_receive_reward = true,
                    is_pickup = true,
                }
            };

        private static readonly List<PeriodMissionList> PeriodMissions =
            new()
            {
                new()
                {
                    period_mission_id = 12050101,
                    progress = 30,
                    state = 2,
                    start_date = StartDate,
                    end_date = EndDate
                }
            };
        private static readonly List<SpecialMissionList> SpecialMissions =
            new() { new(10000101, 0, 0, 0, 0) };
        private static readonly List<AlbumMissionList> AlbumMissions =
            new() { new(10010101, 0, 0, 0, 0) };
        private static readonly AtgenNormalMissionNotice EmptyMissionNotice =
            new(0, 0, 0, 0, 0, 0, new List<int>());
    }
}
