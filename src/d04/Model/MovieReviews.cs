public class MovieReviews
{
    public string status { get; set; }
    public string copyright { get; set; }
    public bool has_more { get; set; }
    public int num_results { get; set; }
    public List<MovieReview> results { get; set; }
}