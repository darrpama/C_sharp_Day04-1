# Day 04 – .NET Boot camp
### Time to have a rest

# Contents
1. [Chapter I](#chapter-i) \
	[General Rules](#general-rules)
2. [Chapter II](#chapter-ii) \
	[Rules of the Day](#rules-of-the-day)
3. [Chapter III](#chapter-iii) \
	[Intro](#intro)
4. [Chapter IV](#chapter-iv) \
	[Exercise 00 – Books](#exercise-00-books)
5. [Chapter V](#chapter-v) \
  [Exercise 01 – Movies](#exercise-01-movies) 
6. [Chapter VI](#chapter-vi) \
  [Exercise 02 – Search](#exercise-02-search) 
7. [Chapter VII](#chapter-vii) \
  [Exercise 03 – The best version](#exercise-03-the-best-version)
8. [Chapter VIII](#chapter-viii) \
  [Exercise 04 – Configuration](#exercise-04-configuration)
9. [In addition](#in-addition)

# Chapter I 

## General Rules
- Make sure you have [the .NET 5 SDK](<https://dotnet.microsoft.com/download>) installed on your computer and use it.
- Remember, your code will be read! Pay special attention to the design of your code and the naming of variables. Adhere to commonly accepted [C# Coding Conventions](<https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/coding-style/coding-conventions>).
- Choose your own IDE that is convenient for you.
- The program must be able to run from the dotnet command line.
- Each of the exercise contains examples of input and output. The solution should use them as the correct format.
- At the beginning of each task, there is a list of allowed language constructs.
- If you find the problem difficult to solve, ask questions to other piscine participants, the Internet, Google or go to StackOverflow.
- You may see the main features of C# language in [official specification](<https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/language-specification/introduction>).
- Avoid **hard coding** and **"magic numbers"**.
- You demonstrate the complete solution, the correct result of the program is just one of the ways to check its correct operation. Therefore, when it is necessary to obtain a certain output as a result of the work of your programs, it is forbidden to show a pre-calculated result.
- Pay special attention to the terms highlighted in **bold** font: their study will be useful to you both in performing the current task, and in your future career of a .NET developer.
- Have fun :)


# Chapter II
##  Rules of the Day

- All projects must be in the same solution.
- Use a console application created based on a standard .NET SDK template.
- Use **top-level-statements**  and **var**.
- The name of the solution and its project (and its separate catalog) is d_{xx}, where xx are the digits of the current day.
- To format the output data, use the en-GB **culture**: N2 for the output of monetary amounts, d for dates.
- Data files in exercises are considered correct and do not need validation. The files can be found in the example files folders corresponding to the exercises number.

## What's new

- Generic types, constraints on type parameters
- LINQ, extension methods
- Application configuration
- Expression trees
- Liskov substitution principle
- Algorithmic complexity

## Project structure:
```
d04/
      Program.cs
      appsettings.json
      Model/
            ISearchable.cs
            BookReview.cs
            MovieReview.cs
```
# Chapter III
## Intro
Life at work and school is getting better, but having a rest is also important. So you think, how great it would be, if it could be easier to decide. Just open a ready-made list and choose.

This is where the New York Times archive comes for you - the publication constantly publishes bestseller lists and reviews of the best movies, so why not use it? There’s only one thing left to do - compile it into a single catalog of amusements.

So, you need to develop a console application. When it is launched, it will collect information from two **JSON** files into two different collections with elements.

# Chapter IV
## Exercise 00 – Books

Now you have an upload of this week's best-selling books taken from different categories. We believe the file is periodically updated and contains up-to-date information. From the information given in the list, we are interested in: the title of the book, its author, description, place in the rating and its (rating) title, as well as a link to a page in the store.

The list of books must be loaded from the book_reviews.json file, they must be **deserialized** from **JSON** into the [corresponding entities](<https://docs.microsoft.com/en-us/dotnet/standard/serialization/system-text-json-customize-properties>).

Implement a separate output format for the resulting *BookReview* class by **overriding** the ToString() method. Let it output:

```
{book.Title} by {book.Author} [{book.Rank} on NYT’s {book.ListName}]
{book.SummaryShort}
{book.Url}
```

Output the list of books to the console.

# Chapter V
## Exercise 01 – Movies

For a movie mood, there is an upload of fresh movie reviews nearby. We believe that this file is also updated and contains up-to-date information. From the data given in this list, we need: the title of the movie, its rating, whether the movie is a critics' choice, the summary of its review and a link to the publication page.

The list of movies should be loaded from the movie_reviews.json file, they need to be **deserialized** from **JSON** into the [corresponding entities](<https://docs.microsoft.com/en-us/dotnet/standard/serialization/system-text-json-customize-properties>).

Implement a separate output format for the resulting *MovieReview* class by **overriding** the ToString() method. Let it output:

```
{movie.Title} {movie.IsCriticsPick ? “[NYT critic’s pick]” : “”}
{movie.SummaryShort}
{movie.Url}
```
Output the list of movies to the console.

# Chapter VI
## Exercise 02 – Search

Now that we have all our media in one place, let’s implement the search functionality. We will be searching the media by its title.

It would be great to implement the search in one method - you will have to search by the title both among books and movies, but duplicating the code is [a bad manner](<https://x-team.com/blog/principles-clean-code/>). Which means you’ll need **the Liskov substitution principle** here.

We implement the search by the title in the **static extension method** - *Search*. So that *Search* method doesn’t care whether the search is for books or for movies, make the type of T **generic**. However, this type must have a title to search for. Let's add [a constraint](<https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/where-generic-type-constraint>):

```
static T[] Search<T>(this IEnumerable<T> list, string search)
where T : ISearchable
```
Implement a search for the entered string, the method should return a list of all found elements: books and movie reviews.

The *BookReview* and *MovieReview* elements should implement the same *ISearchable* interface: books as well as movies will be searched by the title they have.

The search result should be grouped by media type (movie/book). Don't use loops for searching, look towards **LINQ!** Pay attention to the **LINQ extension methods** - **Any, Count, GroupBy, OrderBy, Where,** they make the code much more readable and easier to understand. Use [lambda expressions](<https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/lambda-expressions>).

The search should not be case-sensitive. The results in each group should be sorted by title.

If there are no elements matching the search, the application should display the message “There are no "{search}” in media today.”

In case of an empty search string, the application should return all the elements.

### Input parameters

```
> Input search text:
```

|Argument|Type|Description|
|---|---|---|
| search |string | Search string |

### Example of launching an application from the project folder

```
$ dotnet run
> Input search text:
ar

Items found: 6

Book search result [3]:
- THE MIDNIGHT LIBRARY by Matt Haig [6 on NYT's Hardcover Fiction]
Nora Seed finds a library beyond the edge of the universe that contains books with multiple possibilities of the lives one could have lived.
https://www.amazon.com/dp/0525559477?tag=NYTBSREV-20
- THE INVISIBLE LIFE OF ADDIE LARUE by V.E. Schwab [9 on NYT's Hardcover Fiction]
A Faustian bargain comes with a curse that affects the adventure Addie LaRue has across centuries.
https://www.amazon.com/dp/0765387565?tag=NYTBSREV-20
- KLARA AND THE SUN by Kazuo Ishiguro [13 on NYT's Hardcover Fiction]
An "Artificial Friend" named Klara is purchased to serve as a companion to an ailing 14-year-old girl.
https://www.amazon.com/dp/059331817X?tag=NYTBSREV-20

Movie search result [3]:
- IN OUR MOTHERS' GARDENS
The Netflix documentary sets out to show how maternal lineages have shaped generations of Black women.
https://www.nytimes.com/2021/05/06/movies/in-our-mothers-gardens-review.html
- MARIGHELLA [NYT critic's pick]
Wagner Moura's provocative feature debut chronicles the armed struggle led by Carlos Marighella against Brazil's military dictatorship in the 1960s.
https://www.nytimes.com/2021/04/29/movies/marighella-review.html
- THINGS HEARD & SEEN
Amanda Seyfried and James Norton move into a haunted house in this busy, creaky Netflix thriller.
https://www.nytimes.com/2021/04/29/movies/things-heard-and-seen-review.html

```

# Chapter VII
## Exercise 03 – The best version

If the “best” argument is specified when launching the application, implement the output of the best version of the book and movie instead of searching by title.

We consider the first book with the highest place in the rating to be the best and the first review of the movie, which is the critic's choice.

Don't use loops for searching, look towards **LINQ!** Pay attention to the **LINQ extension methods**, they make the code much more readable and easier to understand. Use [lambda expressions](<https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/lambda-expressions>).

Note: methods for selecting a single item like First() have First()/FirstOrDefault() pairs. Think about the difference and the applicability of each of them.

### Example of launching an application from the project folder

```
$ dotnet run best
Best in books:
- SOOLEY by John Grisham [1 on NYT's Hardcover Fiction]
Samuel Sooleymon receives a basketball scholarship to North Carolina Central and determines to bring his family over from a civil war-ravaged South Sudan.
https://www.amazon.com/dp/0385547684?tag=NYTBSREV-20

Best in movie reviews:
- MARIGHELLA [NYT critic's pick]
Wagner Moura's provocative feature debut chronicles the armed struggle led by Carlos Marighella against Brazil's military dictatorship in the 1960s.
https://www.nytimes.com/2021/04/29/movies/marighella-review.html
```

### Note. Efficiency on the example of the Last() method

Every collection in C# has an extension method called Last(). However, it works in **O(1)** only for collections that implement the IList interface (**a list with access to items by index**). For the rest of the collections, it works in **O(N)**, iterating through its items to the end. Be careful.

Always consider how LINQ methods and iteration through items work. Especially if you use them inside loops.

# Chapter VIII
## Exercise 04 – Configuration

The day before, we already wrote our own **configuration**, but in fact, there are ready-made tools for this in .NET Core. Let's use them: the ***appsettings.json*** configuration file and **nuget packages** for configuration management.

Install [Microsoft.Extensions.Configuration.Json](<https://www.nuget.org/packages/Microsoft.Extensions.Configuration.Json/6.0.0-preview.4.21253.7>) and pay attention to the dependency packages that the nuget manager will install for it. An example of setting up and using application configurations can be found in [the article](<https://docs.microsoft.com/en-us/archive/msdn-magazine/2016/february/essential-net-configuration-in-net-core>). Additional settings can also be taken out in there.

Set up the application configuration so that the path to the files is taken from appsettings.json. 

# Chapter IX
## In addition

For a deeper understanding of the LINQ query language, it will be very useful to understand what [expression trees](<https://docs.microsoft.com/en-us/dotnet/csharp/expression-trees>) are and how they work. Be sure to read it.
