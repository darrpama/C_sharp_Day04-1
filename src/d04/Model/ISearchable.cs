namespace d04.Model
{
public interface ISearchable
{
    string Title { get; set; }
}

public static class SearchableExtensions
{
    public static IEnumerable<T> Search<T>(this IEnumerable<T> list, string? search)
        where T : ISearchable
    {
        if (string.IsNullOrWhiteSpace(search))
        {
            return Enumerable.Empty<T>();
        }

        return list
            .Where(item => item.Title.Contains(search, StringComparison.OrdinalIgnoreCase))
            .OrderBy(item => item.Title)
            .ToList();
    }

    public static T? GetBest<T>(this IEnumerable<T> list, Func<T, int> rankSelector)
    {
        return list
            .OrderByDescending(rankSelector)
            .FirstOrDefault();
    }
}
}  // namespace d04.Model