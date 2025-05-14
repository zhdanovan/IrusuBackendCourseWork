using Ardalis.GuardClauses;
using MangaIrusu.Domain.Entities.Base;
using MangaIrusu.ValueObjects;

namespace MangaIrusu.Domain.Entities;

public class User : Entity
{
    public Username Username { get; private set; }
    public Email Email { get; private set; }
    public List<Guid> FavoriteMangaIds { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }
    public bool IsDeleted { get; private set; }

    private User() { } // For EF Core

    public User(Username username, Email email)
    {
        Guard.Against.Null(username, nameof(username));
        Guard.Against.Null(email, nameof(email));

        Username = username;
        Email = email;
        FavoriteMangaIds = new List<Guid>();
        CreatedAt = DateTime.UtcNow;
        IsDeleted = false;
    }

    public void Update(Username username, Email email)
    {
        Guard.Against.Null(username, nameof(username));
        Guard.Against.Null(email, nameof(email));

        Username = username;
        Email = email;
        UpdatedAt = DateTime.UtcNow;
    }

    public void AddToFavorites(Guid mangaId)
    {
        Guard.Against.Default(mangaId, nameof(mangaId));
        
        if (!FavoriteMangaIds.Contains(mangaId))
        {
            FavoriteMangaIds.Add(mangaId);
            UpdatedAt = DateTime.UtcNow;
        }
    }

    public void RemoveFromFavorites(Guid mangaId)
    {
        Guard.Against.Default(mangaId, nameof(mangaId));
        
        if (FavoriteMangaIds.Contains(mangaId))
        {
            FavoriteMangaIds.Remove(mangaId);
            UpdatedAt = DateTime.UtcNow;
        }
    }

    public bool IsInFavorites(Guid mangaId)
    {
        return FavoriteMangaIds.Contains(mangaId);
    }

    public void Delete()
    {
        IsDeleted = true;
        UpdatedAt = DateTime.UtcNow;
    }
} 