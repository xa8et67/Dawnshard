﻿using DragaliaAPI.Shared.Definitions;
using DragaliaAPI.Shared.Definitions.Enums;
using System.Reflection;
using System.Text.Json;

namespace DragaliaAPI.Shared.Services;

// Tables to use for this CargoQuery:
// Dragons.Id, Dragons.FullName, Dragons.Rarity, Dragons.ElementalType, Dragons.MinHp, Dragons.MaxHp, Dragons.AddMaxHp1, Dragons.MinAtk, Dragons.MaxAtk, Dragons.AddMaxAtk1, Dragons.SkillID, Dragons.Skill2ID, Dragons.Abilities11, Dragons.Abilities12, Dragons.Abilities13, Dragons.Abilities14, Dragons.Abilities15, Dragons.Abilities16, Dragons.Abilities21, Dragons.Abilities22, Dragons.Abilities23, Dragons.Abilities24, Dragons.Abilities25, Dragons.Abilities26, Dragons.DmodePassiveAbilityId, Dragons.MaxLimitBreakCount, Dragons.LimitBreakMaterialId, Dragons.FavoriteType, Dragons.SellCoin, Dragons.SellDewPoint, Dragons.Availability, Dragons.DraconicEssenceLocation,
public class DragonDataService : IDragonDataService
{
    private const string _filename = "dragons.json";
    private const string _filenameStories = "DragonStories.json";
    private const string _folder = "Resources";

    private readonly Dictionary<int, DataDragon> _dictionary;
    private readonly Dictionary<Dragons, int[]> _dragonStories;

    public IEnumerable<DataDragon> AllData => _dictionary.Values;

    public DragonDataService()
    {
        string json = File.ReadAllText(
            Path.Join(
                Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                _folder,
                _filename
            )
        );
        List<DataDragon> deserialized =
            JsonSerializer.Deserialize<List<DataDragon>>(json)
            ?? throw new JsonException("Deserialization failure");

        _dragonStories =
            JsonSerializer.Deserialize<Dictionary<Dragons, int[]>>(
                File.ReadAllText(
                    Path.Join(
                        Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                        _folder,
                        _filenameStories
                    )
                )
            ) ?? throw new JsonException("Deserialization failure");

        _dictionary = deserialized
            .Select(x => new KeyValuePair<int, DataDragon>(x.Id, x))
            .ToDictionary(x => x.Key, x => x.Value);
    }

    public DataDragon GetData(Dragons id) => _dictionary[(int)id];

    public DataDragon GetData(int id) => _dictionary[id];

    public int[] GetStoryData(Dragons id) => _dragonStories[id];

    public int[] GetStoryData(int id) => _dragonStories[(Dragons)id];

    public IEnumerable<DataDragon> getByRarity(int rarity) =>
        _dictionary.Values.Where(x => x.Rarity == rarity);
}
