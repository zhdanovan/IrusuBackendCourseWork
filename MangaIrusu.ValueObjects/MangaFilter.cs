using Ardalis.GuardClauses;
using MangaIrusu.Domain.Enums;
using MangaIrusu.ValueObjects.Base;

namespace MangaIrusu.ValueObjects;

public class MangaFilter : ValueObject
{
    public string? SearchTerm { get; }
    public List<string>? Genres { get; }
    public List<string>? Tags { get; }
    public MangaStatus? Status { get; }
    public MangaType? Type { get; }
    public int? MinYear { get; }
    public int? MaxYear { get; }
    public double? MinRating { get; }
    public bool? SortByRating { get; }
    public bool? SortByViews { get; }
    public bool? SortByYear { get; }
    public bool? SortDescending { get; }

    private MangaFilter(
        string? searchTerm = null,
        List<string>? genres = null,
        List<string>? tags = null,
        MangaStatus? status = null,
        MangaType? type = null,
        int? minYear = null,
        int? maxYear = null,
        double? minRating = null,
        bool? sortByRating = null,
        bool? sortByViews = null,
        bool? sortByYear = null,
        bool? sortDescending = null)
    {
        SearchTerm = searchTerm;
        Genres = genres;
        Tags = tags;
        Status = status;
        Type = type;
        MinYear = minYear;
        MaxYear = maxYear;
        MinRating = minRating;
        SortByRating = sortByRating;
        SortByViews = sortByViews;
        SortByYear = sortByYear;
        SortDescending = sortDescending;
    }

    public static MangaFilter Create(
        string? searchTerm = null,
        List<string>? genres = null,
        List<string>? tags = null,
        MangaStatus? status = null,
        MangaType? type = null,
        int? minYear = null,
        int? maxYear = null,
        double? minRating = null,
        bool? sortByRating = null,
        bool? sortByViews = null,
        bool? sortByYear = null,
        bool? sortDescending = null)
    {
        if (minYear.HasValue && maxYear.HasValue && minYear.Value > maxYear.Value)
        {
            throw new ArgumentException("MinYear cannot be greater than MaxYear");
        }

        if (minRating.HasValue && (minRating.Value < 0 || minRating.Value > 10))
        {
            throw new ArgumentException("MinRating must be between 0 and 10");
        }

        return new MangaFilter(
            searchTerm,
            genres,
            tags,
            status,
            type,
            minYear,
            maxYear,
            minRating,
            sortByRating,
            sortByViews,
            sortByYear,
            sortDescending);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return SearchTerm ?? string.Empty;
        yield return Genres ?? new List<string>();
        yield return Tags ?? new List<string>();
        yield return Status ?? MangaStatus.Ongoing;
        yield return Type ?? MangaType.Manga;
        yield return MinYear ?? 0;
        yield return MaxYear ?? int.MaxValue;
        yield return MinRating ?? 0;
        yield return SortByRating ?? false;
        yield return SortByViews ?? false;
        yield return SortByYear ?? false;
        yield return SortDescending ?? false;
    }
} 