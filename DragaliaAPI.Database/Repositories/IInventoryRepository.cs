using DragaliaAPI.Database.Entities;
using DragaliaAPI.Shared.Definitions.Enums;

namespace DragaliaAPI.Database.Repositories;

public interface IInventoryRepository : IBaseRepository
{
    DbPlayerCurrency AddCurrency(string deviceAccountId, CurrencyTypes type);
    IQueryable<DbPlayerCurrency> GetCurrencies(string deviceAccountId);
    Task<DbPlayerCurrency?> GetCurrency(string deviceAccountId, CurrencyTypes type);
    DbPlayerMaterial AddMaterial(string deviceAccountId, Materials type);
    Task<DbPlayerMaterial?> GetMaterial(string deviceAccountId, Materials materialId);
    IQueryable<DbPlayerMaterial> GetMaterials(string deviceAccountId);
    DbPlayerDragonGift AddDragonGift(string deviceAccountId, DragonGifts type);
    Task<DbPlayerDragonGift?> GetDragonGift(string deviceAccountId, DragonGifts materialId);
    IQueryable<DbPlayerDragonGift> GetDragonGifts(string deviceAccountId);
}
