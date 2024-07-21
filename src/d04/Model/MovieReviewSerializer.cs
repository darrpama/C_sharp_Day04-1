using System.Text.Json;


public class MovieReviewSerializer
{
    public MovieReviewSerializer() {}
    public MovieReviews Load(string filePath)
    {
        MovieReviews result = new MovieReviews();
        try
        {
            using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                result = JsonSerializer.Deserialize<MovieReviews>(fs)
                ?? throw new ArgumentException("Invalid data. Check your input and try again.");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            // throw new ArgumentException("Invalid data. Check your input and try again.");
        }
        return result;
    }
}