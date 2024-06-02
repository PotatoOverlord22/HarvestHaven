﻿using Microsoft.EntityFrameworkCore;
using GameWorldClassLibrary.Models;
using Server.API.Repositories;
using Server.API.Utils;

public class ChallengeRepository : IChallengeRepository
{
    private readonly GamesContext context;

    public ChallengeRepository(GamesContext context)
    {
        this.context = context;
    }

    public async Task<List<Challenge>> GetChallengeAsync()
    {
        return await context.Challenges.ToListAsync();
    }

    public async Task<Challenge> GetChallengeByIdAsync(Guid id)
    {
        var challenge = await context.Challenges.FindAsync(id);

        if (challenge == null)
        {
            throw new KeyNotFoundException("Challenge not found");
        }

        return challenge;
    }

    public async Task UpdateChallengeAsync(Guid id, Challenge challenge)
    {
        if (context.Challenges.Find(id) == null)
        {
            throw new KeyNotFoundException("Challenge not found");
        }

        context.Challenges.Update(challenge);
        await context.SaveChangesAsync();
    }

    public async Task AddChallengeAsync(Challenge challenge)
    {
        context.Challenges.Add(challenge);
        await context.SaveChangesAsync();
    }

    public async Task DeleteChallengeAsync(Guid id)
    {
        var challenge = context.Challenges.Find(id);
        if (challenge == null)
        {
            throw new KeyNotFoundException("Challenge not found");
        }
        context.Challenges.Remove(challenge);
        await context.SaveChangesAsync();
    }
}
