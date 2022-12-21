﻿using System.Text.Json.Serialization;
using DragaliaAPI.Shared.Definitions.Enums;

namespace DragaliaAPI.Shared.Definitions;

public record DataDragon(
    int Id,
    string FullName,
    int Rarity,
    [property: JsonConverter(typeof(JsonStringEnumConverter))] UnitElement ElementalType,
    int MinHp,
    int MaxHp,
    int AddMaxHp1,
    int MinAtk,
    int MaxAtk,
    int AddMaxAtk1,
    int SkillID,
    int Skill2ID,
    int Abilities11,
    int Abilities12,
    int Abilities13,
    int Abilities14,
    int Abilities15,
    int Abilities16,
    int Abilities21,
    int Abilities22,
    int Abilities23,
    int Abilities24,
    int Abilities25,
    int Abilities26,
    int DmodePassiveAbilityId,
    int MaxLimitBreakCount,
    int LimitBreakTypeId,
    Materials LimitBreakMaterialId,
    int? FavoriteType,
    int SellCoin,
    int SellDewPoint,
    string Availability
);
