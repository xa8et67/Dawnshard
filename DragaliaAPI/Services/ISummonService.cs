using DragaliaAPI.Database.Entities;
using DragaliaAPI.Models;
using DragaliaAPI.Models.Generated;

namespace DragaliaAPI.Services;

public interface ISummonService
{
    List<AtgenRedoableSummonResultUnitList> GenerateSummonResult(int numSummons);

    IEnumerable<UserSummonList> GetUserSummonList();
}
