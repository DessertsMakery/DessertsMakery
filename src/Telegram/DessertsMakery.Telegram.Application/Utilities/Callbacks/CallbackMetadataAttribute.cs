namespace DessertsMakery.Telegram.Application.Utilities.Callbacks;

[AttributeUsage(AttributeTargets.Class, Inherited = false)]
internal sealed class CallbackMetadataAttribute : Attribute
{
    public const int MaxShortnameLength = 5;

    public string Shortname { get; }

    public CallbackMetadataAttribute(string shortname)
    {
        if (string.IsNullOrWhiteSpace(shortname))
        {
            throw new ArgumentException("Value cannot be null or whitespace.", nameof(shortname));
        }

        if (shortname.Length > MaxShortnameLength)
        {
            throw new ArgumentException(
                $"Value cannot be longer than {MaxShortnameLength} symbols of length.",
                nameof(shortname)
            );
        }

        Shortname = shortname;
    }
}
