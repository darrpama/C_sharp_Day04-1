using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace d04.Model
{
public class MovieReviewDeserializer
{
    public MovieReviewDeserializer(){}

    public IEnumerable<MovieReview> Deserialize(string filepath)
    {
        string fileText = File.ReadAllText(filepath);
        MovieJsonResponse? response = new MovieJsonResponse();
        var settings = new JsonSerializerSettings
        {
            ContractResolver = new DefaultContractResolver { NamingStrategy = new SnakeCaseNamingStrategy() }
        };
        response = JsonConvert.DeserializeObject<MovieJsonResponse>(fileText, settings);
        
        if (response == null || response.Results == null)
        {
            throw new ArgumentException("Invalid data. Check your input and try again.");
        }

        foreach (var result in response.Results)
        {
            var link = result.Link?.FirstOrDefault();
            if (link != null)
            {

            }
            yield return new MovieReview
            {
                Title = result.Title ?? "",
                CriticsPick  = result.CriticsPick,
                SummaryShort = result.SummaryShort ?? "",
                Url = link.Url ?? ""
            };
        }
    }
}


}  // namespace d04.Model
