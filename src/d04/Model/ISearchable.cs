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
            return [];
        }

        return list
            .Where(item => item.Title.Contains(search, StringComparison.OrdinalIgnoreCase))
            .OrderBy(item => item.Title)
            .ToList();
    }

    public static T? GetBest<T>(this IEnumerable<T> list, Func<T, bool> predicate)
    {
        return list.FirstOrDefault(predicate);
    }
}
}  // namespace d04.Model