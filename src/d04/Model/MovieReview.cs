namespace d04.Model
{
public class MovieReview : ISearchable
{
    public string Title { get; set; } = "";
    public int CriticsPick { get; set; } = 0;
    public string SummaryShort { get; set; } = "";
    public string Url { get; set; } = "";

    public override string ToString()
    {
        string result = $"{Title}" + ' ' + $"[NYT critic's pick] : \"{CriticsPick}\"\n" +
                        $"{SummaryShort}\n" +
                        $"{Url}";
        return result;
    }
}
}