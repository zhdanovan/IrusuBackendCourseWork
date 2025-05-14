using Ardalis.GuardClauses;
using MangaIrusu.Domain.Entities.Base;
using MangaIrusu.Domain.Enums;
using MangaIrusu.Domain.ValueObjects;

namespace MangaIrusu.Domain.Entities;

public class Manga : Entity
{
    public string Title { get; private set; }
    public string Description { get; private set; }
    public string Author { get; private set; }
    public string Artist { get; private set; }
    public MangaStatus Status { get; private set; }
    public MangaType Type { get; private set; }
    public List<string> Genres { get; private set; }
    public List<string> Tags { get; private set; }
    public string CoverImageUrl { get; private set; }
    public int YearOfRelease { get; private set; }
    public int? TotalChapters { get; private set; }
    public double Rating { get; private set; }
    public int Views { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }
    public bool IsDeleted { get; private set; }

    private Manga() { } // For EF Core

    public Manga(
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
        int? totalChapters = null)
    {
        Guard.Against.NullOrWhiteSpace(title, nameof(title));
        Guard.Against.NullOrWhiteSpace(description, nameof(description));
        Guard.Against.NullOrWhiteSpace(author, nameof(author));
        Guard.Against.NullOrWhiteSpace(artist, nameof(artist));
        Guard.Against.Null(genres, nameof(genres));
        Guard.Against.Null(tags, nameof(tags));
        Guard.Against.NullOrWhiteSpace(coverImageUrl, nameof(coverImageUrl));
        Guard.Against.NegativeOrZero(yearOfRelease, nameof(yearOfRelease));

        Title = title;
        Description = description;
        Author = author;
        Artist = artist;
        Status = status;
        Type = type;
        Genres = genres;
        Tags = tags;
        CoverImageUrl = coverImageUrl;
        YearOfRelease = yearOfRelease;
        TotalChapters = totalChapters;
        Rating = 0;
        Views = 0;
        CreatedAt = DateTime.UtcNow;
        IsDeleted = false;
    }

    public void Update(
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
        int? totalChapters = null)
    {
        Guard.Against.NullOrWhiteSpace(title, nameof(title));
        Guard.Against.NullOrWhiteSpace(description, nameof(description));
        Guard.Against.NullOrWhiteSpace(author, nameof(author));
        Guard.Against.NullOrWhiteSpace(artist, nameof(artist));
        Guard.Against.Null(genres, nameof(genres));
        Guard.Against.Null(tags, nameof(tags));
        Guard.Against.NullOrWhiteSpace(coverImageUrl, nameof(coverImageUrl));
        Guard.Against.NegativeOrZero(yearOfRelease, nameof(yearOfRelease));

        Title = title;
        Description = description;
        Author = author;
        Artist = artist;
        Status = status;
        Type = type;
        Genres = genres;
        Tags = tags;
        CoverImageUrl = coverImageUrl;
        YearOfRelease = yearOfRelease;
        TotalChapters = totalChapters;
        UpdatedAt = DateTime.UtcNow;
    }

    public void UpdateRating(double newRating)
    {
        Guard.Against.OutOfRange(newRating, nameof(newRating), 0, 10);
        Rating = newRating;
        UpdatedAt = DateTime.UtcNow;
    }

    public void IncrementViews()
    {
        Views++;
    }

    public void Delete()
    {
        IsDeleted = true;
        UpdatedAt = DateTime.UtcNow;
    }
} 