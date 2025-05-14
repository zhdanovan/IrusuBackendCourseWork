using System.Text.RegularExpressions;

namespace MangaIrusu.ValueObjects.Validators;

public static class EmailValidator
{
    private const string EmailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

    public static bool IsValid(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
            return false;

        return Regex.IsMatch(email, EmailPattern);
    }
} 