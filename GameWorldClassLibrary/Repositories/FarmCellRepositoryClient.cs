﻿using GameWorldClassLibrary.Models;
using GameWorldClassLibrary.Utils;
using System.Net.Http.Json;
namespace GameWorldClassLibrary.Repositories
{
    public class FarmCellRepositoryClient : IFarmCellRepository
    {
        private IRequestClient requestClient;
        public FarmCellRepositoryClient(IRequestClient requestClient)
        {
            this.requestClient = requestClient;
        }
        public async Task<List<FarmCell>> GetUserFarmCellsAsync(Guid userId)
        {
            try
            {
                var response = await requestClient.GetAsync($"{Apis.FARM_CELL}/{userId}");
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<List<FarmCell>>() ?? throw new Exception("Response content from getting all farm cells from the backend is invalid: ");
                }
                else
                {
                    throw new Exception($"Error getting farm cells: {response.ReasonPhrase}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("Error getting the farm cells from backend" + exception.Message);
            }
        }

        public async Task<FarmCell> GetUserFarmCellByPositionAsync(Guid userId, int row, int column)
        {
            try
            {
                var response = await requestClient.GetAsync($"{Apis.FARM_CELL}/userId={userId}&row={row}&column={column}");
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<FarmCell>() ?? throw new Exception("Response content from getting all farm cells by user from the backend is invalid: ");
                }
                else
                {
                    throw new Exception($"Error getting user resource by resource ID: {response.ReasonPhrase}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception($"Exception getting user resource by resource ID: {exception.Message}");
            }
        }

        public async Task AddFarmCellAsync(FarmCell farmCell)
        {
            try
            {
                var response = await requestClient.PostAsync(Apis.FARM_CELL, farmCell);
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception($"Error adding farm cell: {response.ReasonPhrase}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception($"Exception adding farm cell: {exception.Message}");
            }
        }

        public async Task UpdateFarmCellAsync(FarmCell farmCell)
        {
            try
            {
                var response = await requestClient.PostAsync($"{Apis.FARM_CELL}/{farmCell.Id}", farmCell);
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception($"Error updating farm cell: {response.ReasonPhrase}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception($"Exception updating farm cell: {exception.Message}");
            }
        }

        public async Task DeleteFarmCellAsync(Guid farmCellId)
        {
            try
            {
                var response = await requestClient.DeleteAsync($"{Apis.FARM_CELL}/{farmCellId}");
                if (!response.IsSuccessStatusCode)
                {
                    Console.Error.WriteLine($"Error deleting farm cell: {response.ReasonPhrase}");
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Exception deleting farm cell: {ex.Message}");
            }
        }
    }
}
