using MangaIrusu.Domain.Entities;
using MangaIrusu.Domain.Enums;

namespace MangaIrusu.Domain.Services;

public interface IMangaService
{
    Task<Manga> CreateMangaAsync(
        string title,
        string description,
        string author,
        string artist,
        MangaStatus status,
        MangaType type,
        List<string> genres,
        List<string> tags,
        string coverImageUrl,
        int yearOfRelease,
        int? totalChapters = null,
        CancellationToken cancellationToken = default);

    Task<Manga> UpdateMangaAsync(
        Guid id,
        string title,
        string description,
        string author,
        string artist,
        MangaStatus status,
        MangaType type,
        List<string> genres,
        List<string> tags,
        string coverImageUrl,
        int yearOfRelease,
        int? totalChapters = null,
        CancellationToken cancellationToken = default);

    Task DeleteMangaAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Manga?> GetMangaByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<IEnumerable<Manga>> GetAllMangaAsync(CancellationToken cancellationToken = default);
    Task<IEnumerable<Manga>> SearchMangaAsync(string searchTerm, CancellationToken cancellationToken = default);
    Task<IEnumerable<Manga>> GetMangaByGenreAsync(string genre, CancellationToken cancellationToken = default);
    Task<IEnumerable<Manga>> GetMangaByAuthorAsync(string author, CancellationToken cancellationToken = default);
    Task UpdateMangaRatingAsync(Guid id, double rating, CancellationToken cancellationToken = default);
    Task IncrementMangaViewsAsync(Guid id, CancellationToken cancellationToken = default);
} 