using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace d04.Model
{
public class BookReviewDeserializer
{
    public BookReviewDeserializer() {}

    public IEnumerable<BookReview> Deserialize(string filepath)
    {
        if (filepath is null)
        {
            throw new ArgumentException("Invalid data. Check your input and try again.");
        }
        string fileText = File.ReadAllText(filepath);
        BookJsonResponse? response = new BookJsonResponse();
        var settings = new JsonSerializerSettings
        {
            ContractResolver = new DefaultContractResolver { NamingStrategy = new SnakeCaseNamingStrategy() }
        };
        response = JsonConvert.DeserializeObject<BookJsonResponse>(fileText, settings);
        
        if (response == null || response.Results == null)
        {
            throw new ArgumentException("Invalid data. Check your input and try again.");
        }

        foreach (var result in response.Results)
        {
            var bookDetail = result.BookDetails?.FirstOrDefault();
            if (bookDetail != null)
            {
                yield return new BookReview
                {
                    Title = bookDetail.Title ?? "",
                    Author = bookDetail.Author ?? "",
                    Rank = result.Rank,
                    ListName = result.ListName ?? "",
                    SummaryShort = bookDetail.SummaryShort ?? "",
                    Url = result.AmazonProductUrl ?? ""
                };
            }
        }
    }
}
}  // namespace d04.Movie