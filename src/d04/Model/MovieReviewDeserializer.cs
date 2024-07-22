using MovieJsonStruct;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

public class MovieReviewDeserializer
{
    private NamingStrategy _namingStrategy;

    public MovieReviewDeserializer(NamingStrategy namingStrategy)
    {
        _namingStrategy = namingStrategy;
    }

    public IEnumerable<MovieReview> Deserialize(string jsonPath)
    {
        var json = File.ReadAllText(jsonPath);
        var settings = new JsonSerializerSettings()
        {
            ContractResolver = new DefaultContractResolver() { NamingStrategy = _namingStrategy }
        };
        var root = JsonConvert.DeserializeObject<MovieJsonStruct.MovieReview>(json, settings);
        if (root?.Results != null)
        {
            foreach (var result in root.Results)
            {
                yield return new MovieReview
                {
                    Title = result.Title ?? "",
                    CriticsPick = result.CriticsPick,
                    SummaryShort = result.SummaryShort ?? "",
                    Url = result.Link?.Url ?? ""
                };
            }
        }
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