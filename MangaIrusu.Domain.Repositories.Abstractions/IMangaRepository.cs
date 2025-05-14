using MangaIrusu.Domain.Entities;
using MangaIrusu.ValueObjects;

namespace MangaIrusu.Domain.Repositories.Abstractions;

public interface IMangaRepository
{
    Task<Manga?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<IEnumerable<Manga>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<IEnumerable<Manga>> GetByFilterAsync(MangaFilter filter, CancellationToken cancellationToken = default);
    Task<IEnumerable<string>> GetAllGenresAsync(CancellationToken cancellationToken = default);
    Task<IEnumerable<string>> GetAllTagsAsync(CancellationToken cancellationToken = default);
    Task<IEnumerable<Manga>> GetFavoritesAsync(Guid userId, CancellationToken cancellationToken = default);
    Task AddAsync(Manga manga, CancellationToken cancellationToken = default);
    Task UpdateAsync(Manga manga, CancellationToken cancellationToken = default);
    Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);
    Task<bool> ExistsAsync(Guid id, CancellationToken cancellationToken = default);
} 