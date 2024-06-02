﻿using GameWorldClassLibrary.Models;

namespace GameWorldClassLibrary.Repositories
{
    public interface IMarketSellResourceRepository
    {
        Task<List<MarketSellResource>> GetAllMarketSellResourcesAsync();
        Task<MarketSellResource> GetMarketSellResourceByResourceIdAsync(Guid resourceId);
        Task AddMarketSellResourceAsync(MarketSellResource marketSellResource);
        Task UpdateMarketSellResourceAsync(MarketSellResource marketSellResource);
        Task DeleteMarketSellResourceAsync(Guid marketSellResourceId);
    }
}
