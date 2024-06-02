using GameWorldClassLibrary.Models;

namespace GameWorldClassLibrary.Repositories
{
    public interface ITitleRepository
    {
        Task<Title> GetTitleByIdAsync(Guid id);
        Task<List<Title>> GetTitleAsync();
        Task AddTitleAsync(Title title);
        Task DeleteTitleAsync(Guid id);
        Task UpdateTitleAsync(Guid id, Title title);
    }
}