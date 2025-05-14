using System.Text.RegularExpressions;

namespace MangaIrusu.ValueObjects.Validators;

public static class UsernameValidator
{
    private const string UsernamePattern = @"^[a-zA-Z][a-zA-Z0-9_]{2,19}$";

    public static bool IsValid(string username)
    {
        if (string.IsNullOrWhiteSpace(username))
            return false;

        return Regex.IsMatch(username, UsernamePattern);
    }
} 