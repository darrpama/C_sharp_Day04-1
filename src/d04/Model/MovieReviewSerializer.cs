
public class MovieReviewSerializer
{
    public Dictionary<string, object> LoadParams()
    {
        Dictionary<string, object> result = new Dictionary<string, object>();
        try
        {
            using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                result = JsonSerializer.Deserialize<Dictionary<string, object>>(fs)
                ?? throw new ArgumentException("Invalid data. Check your input and try again.");
            }
        }
        catch
        {
            throw new ArgumentException("Invalid data. Check your input and try again.");
        }
        return result;
    }
}