using MangaIrusu.Domain.Entities;
using MangaIrusu.ValueObjects;

namespace MangaIrusu.Domain.Services;

public interface IUserService
{
    Task<User> CreateUserAsync(
        Username username,
        Email email,
        CancellationToken cancellationToken = default);

    Task<User> UpdateUserAsync(
        Guid id,
        Username username,
        Email email,
        CancellationToken cancellationToken = default);

    Task DeleteUserAsync(Guid id, CancellationToken cancellationToken = default);
    Task<User?> GetUserByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<User?> GetUserByEmailAsync(Email email, CancellationToken cancellationToken = default);
    Task<User?> GetUserByUsernameAsync(Username username, CancellationToken cancellationToken = default);
    Task<IEnumerable<User>> GetAllUsersAsync(CancellationToken cancellationToken = default);
    Task AddMangaToFavoritesAsync(Guid userId, Guid mangaId, CancellationToken cancellationToken = default);
    Task RemoveMangaFromFavoritesAsync(Guid userId, Guid mangaId, CancellationToken cancellationToken = default);
    Task<IEnumerable<Guid>> GetUserFavoritesAsync(Guid userId, CancellationToken cancellationToken = default);
    Task<bool> IsMangaInFavoritesAsync(Guid userId, Guid mangaId, CancellationToken cancellationToken = default);
} 