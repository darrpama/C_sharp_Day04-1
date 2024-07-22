using System.Text;

namespace d04.Model
{
public class MovieReview : ISearchable
{
    public string Title { get; set; } = "";
    public int CriticsPick { get; set; } = -1;
    public string SummaryShort { get; set; } = "";
    public string Url { get; set; } = "";

    public override string ToString()
    {
        string criticsPick = CriticsPick > 0 ? $"[NYT critic's pick]\n" : "\n";
        return $"{Title}" + ' ' + criticsPick +
               $"{SummaryShort}\n" +
               $"{Url}";
    }
}
}