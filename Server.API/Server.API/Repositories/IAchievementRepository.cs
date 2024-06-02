﻿using Microsoft.AspNetCore.Mvc;
using Server.API.Models;

namespace Server.API.Repositories
{
    public interface IAchievementRepository
    {
        Task AddAchievement(Achievement achievement);
        Task DeleteAchievementAsync(Guid id);
        Task<Achievement> GetAchievementByIdAsync(Guid id);
        Task<List<Achievement>> GetAchievementsAsync();
        Task UpdateAchievementAsync(Guid id, Achievement achievement);
    }
}