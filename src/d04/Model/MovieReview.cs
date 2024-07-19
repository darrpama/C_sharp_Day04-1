using System.Text.Json;

public class MovieReview : ISearchable
{
    public Dictionary<string, object> Info { get; private set; }
    public string title { get; set; }
    public string mpaa_rating { get; set; }
    public int critics_pick { get; set; }
    public string byline { get; set; }
    public string headline { get; set; }
    public string summary_short { get; set; }
    public DateTime publication_date { get; set; }
    public DateTime opening_date { get; set; }
    public DateTime date_updated { get; set; }
    public Link link { get; set; }
    public Multimedia multimedia { get; set; }
}

public class Link
{
    public string type { get; set; }
    public string url { get; set; }
    public string suggested_link_text { get; set; }
}

public class Multimedia
{
    public string type { get; set; }
    public string src { get; set; }
    public int height { get; set; }
    public int width { get; set; }
}
