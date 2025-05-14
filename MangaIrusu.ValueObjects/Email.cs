using Ardalis.GuardClauses;
using MangaIrusu.ValueObjects.Base;
using MangaIrusu.ValueObjects.Exceptions;
using MangaIrusu.ValueObjects.Validators;

namespace MangaIrusu.ValueObjects;

public class Email : ValueObject
{
    public string Value { get; }

    private Email(string value)
    {
        Value = value;
    }

    public static Email Create(string email)
    {
        Guard.Against.NullOrWhiteSpace(email, nameof(email));
        
        if (!EmailValidator.IsValid(email))
        {
            throw new ValueObjectException($"Invalid email format: {email}");
        }

        return new Email(email.ToLowerInvariant());
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    public static implicit operator string(Email email) => email.Value;
} 