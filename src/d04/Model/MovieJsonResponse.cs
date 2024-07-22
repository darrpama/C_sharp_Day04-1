using Newtonsoft.Json;

namespace d04.Model
{
public class MovieJsonResponse
{
    public string? Status { get; set; }
    public string? Copyright { get; set; }
    public bool? HasMore { get; set; }
    public int? NumResults { get; set; }
    public List<Result>? Results { get; set; }

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
}  // namespace d04.Model