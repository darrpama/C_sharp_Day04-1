using d04.Model;
using Microsoft.Extensions.Configuration;


ConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
configurationBuilder.SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("Config.json", true, reloadOnChange: true);
IConfiguration config = configurationBuilder.Build();

string bookJsonPath = config.GetSection("file_paths:books").Value;
string movieJsonPath = config.GetSection("file_paths:movies").Value;

BookReviewDeserializer bookdeserializer = new BookReviewDeserializer();
MovieReviewDeserializer moviedeserializer = new MovieReviewDeserializer();
try
{
    var bookReviews = bookdeserializer.Deserialize(bookJsonPath);
    var movieReviews = moviedeserializer.Deserialize(movieJsonPath);

    if (args.Length == 0)
    {
        SearchGlobal(bookReviews, movieReviews);
    }
    else if (args.Length == 1 && args[0] == "best")
    {
        Console.WriteLine("Best in books:");
        var bestBook = bookReviews.GetBest(rev => rev.Rank);
        if (bestBook != null) {
            Console.Write("- ");
            Console.WriteLine(bestBook);
        }

        Console.WriteLine("Best in movie reviews:");
        var bestMovie = movieReviews.GetBest(rev => rev.CriticsPick);
        if (bestMovie != null) {
            Console.Write("- ");
            Console.WriteLine(bestMovie);
        }

    }
    else
    {
        Console.WriteLine("n/a");
    }

    static void SearchGlobal(IEnumerable<BookReview> bookReviews, IEnumerable<MovieReview> movieReviews)
    {
        Console.WriteLine("> Input search text:");
        string? search = Console.ReadLine();
        var books = bookReviews.Search(search);
        var movies = movieReviews.Search(search);
        var itemsCount = books.Count() + movies.Count();
        if (itemsCount == 0)
        {
            Console.WriteLine($"There are no {search} in media today.");
        }
        else
        {
            Console.WriteLine($"Items found: {itemsCount}\n");
            Console.WriteLine($"Book search result [{books.Count()}]");
            foreach (var book in books)
            {
                Console.Write("- ");
                Console.WriteLine(book);
            }
            Console.WriteLine();
            Console.WriteLine($"Movie search result [{movies.Count()}]");
            foreach (var movie in movies)
            {
                Console.Write("- ");
                Console.WriteLine(movie);
            }
        }
    }
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}

