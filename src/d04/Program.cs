using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Serialization;

var builder = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional:
        true, reloadOnChange: true);

IConfiguration configuration = builder.Build();

string bookJsonPath = configuration.GetSection("FilePaths:Books").Value;
string movieJsonPath = configuration.GetSection("FilePaths:Movies").Value;

BookReviewDeserializer bookDeserializer = new BookReviewDeserializer(new SnakeCaseNamingStrategy());
MovieReviewDeserializer movieDeserializer = new MovieReviewDeserializer(new SnakeCaseNamingStrategy());

List<BookReview> bookReviews = bookDeserializer.Deserialize(bookJsonPath).ToList();
List<MovieReview> movieReviews = movieDeserializer.Deserialize(movieJsonPath).ToList();

if (args.Length == 0)
{
    GlobalSearch(bookReviews, movieReviews);
}
else if (args.Length == 1 && args[0] is "best")
{
    Console.WriteLine("Best in books:");
    var bestBook = bookReviews.GetBest(book => book.Rank == 1);
    if (bestBook != null)
    {
        Console.Write("- ");
        Console.WriteLine(bestBook);
    }

    var bestMovieReview = movieReviews.GetBest(movie => movie.CriticsPick != 0);
    if (bestMovieReview != null)
    {
        Console.WriteLine("\nBest in movie reviews:");
        Console.Write("- ");
        Console.WriteLine(bestMovieReview);
    }
}
else
{
    Console.WriteLine("n/a");
}

static void GlobalSearch(List<BookReview> bookReviews, List<MovieReview> movieReviews)
{
    Console.WriteLine("> Input search text:");
    var searchText = Console.ReadLine();
    var bookSearchResult = bookReviews.Search(searchText);
    var movieSearchResult = movieReviews.Search(searchText);
    int totalResults = bookSearchResult.Count() + movieSearchResult.Count();

    if (totalResults == 0)
    {
        Console.WriteLine($"There are no {searchText} in media today.");
    }
    else
    {
        Console.WriteLine($"Items found: {totalResults}\n");
        Console.WriteLine($"Book search result [{bookSearchResult.Count()}]");
        foreach (var book in bookSearchResult)
        {
            Console.Write("- ");
            Console.WriteLine(book);
        }

        Console.WriteLine();
        Console.WriteLine($"Movie search result [{movieSearchResult.Count()}]");
        foreach (var movie in movieSearchResult)
        {
            Console.Write("- ");
            Console.WriteLine(movie);
        }
    }
}