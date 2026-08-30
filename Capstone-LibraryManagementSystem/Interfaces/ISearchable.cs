/// <summary>
/// Contract for types that can be located by a free-text query.
/// </summary>
public interface ISearchable
{
    /// <summary>Checks whether this instance matches the given search text.</summary>
    /// <param name="query">The text to search for.</param>
    /// <returns>true if this instance matches; otherwise false.</returns>
    bool Matches(string query);
}