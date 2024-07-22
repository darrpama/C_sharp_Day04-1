using Newtonsoft.Json;

public class BookJsonResponse
{
    public string Status { get; set; } = "";
    public string Copyright { get; set; } = "";
    public int NumResults { get; set; }
    public string LastModified { get; set; } = "";
    public List<Result> Results { get; set; } = new List<Result>{};

    public class Result
    {
        public string ListName { get; set; } = "";
        public int Rank { get; set; }
        public string AmazonProductUrl { get; set; } = "";
        public List<BookDetail> BookDetails { get; set; } = new List<BookDetail>{};

        public class BookDetail
        {
            public string Title { get; set; } = "";
            [JsonProperty("description")]
            public string SummaryShort { get; set; } = "";
            public string Author { get; set; } = "";
        }
    }
}