using Ardalis.GuardClauses;
using MangaIrusu.ValueObjects.Base;
using MangaIrusu.ValueObjects.Exceptions;
using MangaIrusu.ValueObjects.Validators;

namespace MangaIrusu.ValueObjects;

public class Username : ValueObject
{
    public string Value { get; }

    private Username(string value)
    {
        Value = value;
    }

    public static Username Create(string username)
    {
        Guard.Against.NullOrWhiteSpace(username, nameof(username));
        
        if (!UsernameValidator.IsValid(username))
        {
            throw new ValueObjectException($"Invalid username format: {username}");
        }

        return new Username(username);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    public static implicit operator string(Username username) => username.Value;
} 