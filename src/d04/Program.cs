using d04.Model;

BookReviewDeserializer bookdeserializer = new BookReviewDeserializer();
var res1 = bookdeserializer.Deserialize("../book_reviews.json");

MovieReviewDeserializer moviedeserializer = new MovieReviewDeserializer();
var res2 = moviedeserializer.Deserialize("../movie_reviews.json");

foreach (var tmp in res1)
{
    Console.WriteLine(tmp.ToString());
}


foreach (var tmp in res2)
{
    Console.WriteLine(tmp.ToString());
}