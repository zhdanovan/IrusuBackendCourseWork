using Ardalis.SmartEnum;

namespace MangaIrusu.Domain.Enums;

public class MangaStatus : SmartEnum<MangaStatus>
{
    public static readonly MangaStatus Ongoing = new(nameof(Ongoing), 1);
    public static readonly MangaStatus Completed = new(nameof(Completed), 2);
    public static readonly MangaStatus OnHiatus = new(nameof(OnHiatus), 3);
    public static readonly MangaStatus Cancelled = new(nameof(Cancelled), 4);
    public static readonly MangaStatus Upcoming = new(nameof(Upcoming), 5);

    private MangaStatus(string name, int value) : base(name, value)
    {
    }
} 