using DragaliaAPI.Shared.Definitions;
using DragaliaAPI.Shared.Definitions.Enums;

namespace DragaliaAPI.Shared.Services;

public interface ICharaDataService
{
    IEnumerable<DataAdventurer> AllData { get; }

    DataAdventurer GetData(Charas id);
    DataAdventurer GetData(int id);
    int[] GetStoryData(Charas id);
    int[] GetStoryData(int id);
    public IEnumerable<DataAdventurer> getByRarity(int rarity);
}
