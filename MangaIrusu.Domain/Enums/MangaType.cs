using Ardalis.SmartEnum;

namespace MangaIrusu.Domain.Enums;

public class MangaType : SmartEnum<MangaType>
{
    public static readonly MangaType Manga = new(nameof(Manga), 1);
    public static readonly MangaType Manhwa = new(nameof(Manhwa), 2);
    public static readonly MangaType Manhua = new(nameof(Manhua), 3);
    public static readonly MangaType Webtoon = new(nameof(Webtoon), 4);
    public static readonly MangaType Doujinshi = new(nameof(Doujinshi), 5);

    private MangaType(string name, int value) : base(name, value)
    {
    }
} 