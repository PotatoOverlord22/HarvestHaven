﻿using Microsoft.AspNetCore.Mvc;
using Server.API.Models;
using Server.API.Services;

namespace Server.API.Controllers
{
    public class MarketSellResourceController : ControllerBase
    {
        private readonly MarketSellResourceService marketSellResourceService;

        public MarketSellResourceController(MarketSellResourceService marketSellResourceService)
        {
            this.marketSellResourceService = marketSellResourceService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MarketSellResource>>> GetAllMarketSellResourcesAsync()
        {
            var marketSellResources = await marketSellResourceService.GetAllMarketSellResourcesAsync();
            return marketSellResources;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MarketBuyItem>> GetMarketSellResourceByResourceIdAsync(Guid marketSellResourceId)
        {
            var marketSellResource = await marketSellResourceService.GetMarketBuyItemByItemIdAsync(marketSellResourceId);

            if (marketSellResource == null)
            {
                return NotFound();
            }

            return marketSellResource;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMarketSellResource(Guid marketSellResourceId, MarketSellResource marketSellResource)
        {
            try
            {
                await marketSellResourceService.UpdateMarketSellResourceAsync(marketSellResource);
            }
            catch (KeyNotFoundException e)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> AddMarketSellResource(MarketSellResource marketSellResource)
        {
            try
            {
                await marketSellResourceService.AddMarketSellResourceAsync(marketSellResource);
            }
            catch (Exception e)
            {
                return BadRequest();
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMarketSellResource(Guid marketSellResourceId)
        {
            try
            {
                await marketSellResourceService.DeleteMarketSellResourceAsync(marketSellResourceId);
            }
            catch (KeyNotFoundException e)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}