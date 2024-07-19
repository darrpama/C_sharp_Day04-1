
public class MovieReviewSerializer
{
    public MovieReviewSerializer()
    {}

    public IEnumerable<MovieReview> Deserialize(string filePath)
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

namespace MovieJsonStruct
{
    public class MovieReview
    {
        public string? Status { get; set; }
        public string? Copyright { get; set; }
        public bool? HasMore { get; set; }
        public int? NumResults { get; set; }
        public List<Result>? Results { get; set; }
    }

    public class Result
    {
        public string? Title { get; set; }
        public string? MpaaRating { get; set; }
        public int CriticsPick { get; set; }
        public string? Byline { get; set; }
        public string? Headline { get; set; }

        public string? SummaryShort { get; set; }
        public DateTime? PublicationDate { get; set; }
        public DateTime? OpeningDate { get; set; }
        public DateTime? DateUpdated { get; set; }

        public Link? Link { get; set; }
    }

    public class Link
    {
        public string? Type { get; set; }
        public string? Url { get; set; }
        public string? SuggestedLinkText { get; set; }
    }
}