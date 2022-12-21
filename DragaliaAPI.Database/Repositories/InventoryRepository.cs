using DragaliaAPI.Database.Entities;
using DragaliaAPI.Shared.Definitions.Enums;
using Microsoft.EntityFrameworkCore;

namespace DragaliaAPI.Database.Repositories;

public class InventoryRepository : BaseRepository, IInventoryRepository
{
    private readonly ApiContext apiContext;

    public InventoryRepository(ApiContext apiContext) : base(apiContext)
    {
        this.apiContext = apiContext;
    }

    public DbPlayerCurrency AddCurrency(string deviceAccountId, CurrencyTypes type)
    {
        return apiContext.PlayerWallet
            .Add(
                new DbPlayerCurrency()
                {
                    DeviceAccountId = deviceAccountId,
                    CurrencyType = type,
                    Quantity = 0
                }
            )
            .Entity;
    }

    public async Task<DbPlayerCurrency?> GetCurrency(string deviceAccountId, CurrencyTypes type)
    {
        return await this.apiContext.PlayerWallet.FirstOrDefaultAsync(
            entry => entry.DeviceAccountId == deviceAccountId && entry.CurrencyType == type
        );
    }

    public IQueryable<DbPlayerCurrency> GetCurrencies(string deviceAccountId)
    {
        return this.apiContext.PlayerWallet.Where(
            wallet => wallet.DeviceAccountId == deviceAccountId
        );
    }

    public DbPlayerMaterial AddMaterial(string deviceAccountId, Materials type)
    {
        return apiContext.PlayerStorage
            .Add(
                new DbPlayerMaterial()
                {
                    DeviceAccountId = deviceAccountId,
                    MaterialId = type,
                    Quantity = 0
                }
            )
            .Entity;
    }

    public async Task<DbPlayerMaterial?> GetMaterial(string deviceAccountId, Materials materialId)
    {
        return await this.apiContext.PlayerStorage.FirstOrDefaultAsync(
            entry => entry.DeviceAccountId == deviceAccountId && entry.MaterialId == materialId
        );
    }

    public IQueryable<DbPlayerMaterial> GetMaterials(string deviceAccountId)
    {
        return this.apiContext.PlayerStorage.Where(
            storage => storage.DeviceAccountId == deviceAccountId
        );
    }

    public DbPlayerDragonGift AddDragonGift(string deviceAccountId, DragonGifts giftId)
    {
        return apiContext.PlayerDragonGifts
            .Add(
                new DbPlayerDragonGift()
                {
                    DeviceAccountId = deviceAccountId,
                    DragonGiftId = giftId,
                    Quantity = 0
                }
            )
            .Entity;
    }

    public async Task<DbPlayerDragonGift?> GetDragonGift(string deviceAccountId, DragonGifts giftId)
    {
        return await this.apiContext.PlayerDragonGifts.FirstOrDefaultAsync(
            entry => entry.DeviceAccountId == deviceAccountId && entry.DragonGiftId == giftId
        );
    }

    public IQueryable<DbPlayerDragonGift> GetDragonGifts(string deviceAccountId)
    {
        return this.apiContext.PlayerDragonGifts.Where(
            gifts => gifts.DeviceAccountId == deviceAccountId
        );
    }
}
