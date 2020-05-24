using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using CSharpUdemyAdvanced;

namespace CSharpUdemyAdvanced
{
    class Program
    {
        static void Main(string[] args)
        {
            /* Generics
            var book = new Book() {Isbn = "1111", Title = "C# stuff"};
            var numbers = new GenericList<int>();
            numbers.Add(10); //you can see here that after typing numbers.Add(), the autocomplete stated that it was an int

            var books = new GenericList<Book>();
            books.Add(new Book());

            var dictionary = new GenericDictionary<string, Book>();
            dictionary.Add("1234", new Book());
           
            var util = new Utilities<int>();
            var value = util.Max(3, 2);
            Console.WriteLine(value);


            //create with value
            var number = new Nullable<int>(5);
            Console.WriteLine("Has Value ?" + number.HasValue);
            Console.WriteLine("Value: " + number.GetValueOrDefault());


            //create without value
            var withoutNumber = new Nullable<int>();
            Console.WriteLine("Has Value ?" + withoutNumber.HasValue);
            Console.WriteLine("Value: " + withoutNumber.GetValueOrDefault());
            */


            /* Delegates 
            var photoProcessor = new PhotoProcessor();
            var filters = new PhotoFilters();

            //since we made the PhotoFilterHandler become a Generic Delegate, we can change the following line
            //PhotoProcessor.PhotoFilterHandler filterHandler = filters.ApplyBrightness;
            Action<Photo> filterHandler = filters.ApplyBrightness;

            filterHandler += filters.ApplyContrast;
            filterHandler += filters.Resize;
            filterHandler += CustomFilters.RemoveRedEyeFilter; //this one is outside the regular functionality of PhotoFilters class.

            photoProcessor.Process("c", filterHandler);
            */



            //Lambda Expressions
            /*
            //args => expression (read as Arguments goes to Expression)
            //number => number * number;

            //equiv statements:
            //static int Square(int number)
            //{
            //  return number*number
            //}
            static int Square(int number) => number * number;
            Func<int, int> squareLambda = number => number * number;
            Console.WriteLine(squareLambda(5));
            Console.WriteLine(Square(5));


            const int factor = 5;

            Func<int, int> multiplier = n => n * factor;
            Console.WriteLine($"{multiplier(3)} multiplier value");


            var books = new BookRepository().GetBooks();

            //input here is a predicate?

            //replace the below lines of:
            //        static bool IsCheaperThan10Dollars(Book book)
            //{
            //    return book.Price < 10;
            //}
            //with lambda
            //book

            //var cheapbooks = books.FindAll(IsCheaperThan10Dollars);
            //with book => book.Price < 10
            var cheapbooks = books.FindAll(book => book.Price < 10);


            foreach (var book in cheapbooks)
            {
                Console.WriteLine($"{book.Title} is cheaper than 10 dollars");
            }

            */


            //Events
            //events are a pub/sub model
            /*
            var video = new Video() { Title = "Video 1" };
            var videoEncoder = new VideoEncoder(); // publisher
            var mailService = new MailService(); //subscriber
            var messageService = new MessageService(); //subscriber 2

            //Here is how to do the Event subscription
            videoEncoder.VideoEncoded += mailService.OnVideoEncoded;
            videoEncoder.VideoEncoded += messageService.OnVideoEncoded;

            videoEncoder.Encode(video); 
            */






            //Extension Methods
            //most likely only using them and not creating them
            /*
            string post =
                "this is supposed to be a very long blog post ad;lfkja;lksdfkl;ajdsf;lkjasdlfj;laksdjfl;kajsdfkl;jasdl;kfja;lksdjf;lkasjfkalsdf...";
            var shortenedPost = post.Shorten(5);
            Console.WriteLine(shortenedPost);



            //here is a Microsoft generated Extension Methods using IEnumerable
            IEnumerable<int> numbers = new List<int>() { 1,5,3,10,2,18};
            var max = numbers.Max();
            Console.WriteLine(max);
            */





            //Nullable types
            //value types cannot be null
            /*
            //useful for databases, like birthdays
            // cannot do this:
            // DateTime data = null;
            
            DateTime? date = null;

            Console.WriteLine("get value or default: " + date.GetValueOrDefault()); // day 1, month 1, year 0001
            Console.WriteLine("check if it has value: " + date.HasValue); // false
            //Console.WriteLine("get the value: " + date.Value); // null error


            //cannot put a nullable DateTime into a regular DateTime
            //DateTime date2 = date;

            //so we must do some better code:
            DateTime date2 = date.GetValueOrDefault();
            Console.WriteLine(date2);

            //can easily make a new nullable type from an old one
            DateTime? date3 = date;
            DateTime? date4 = date2;

            DateTime date5;


            //Instead of doing this:
            if (date != null)
                date5 = date.GetValueOrDefault();
            else
                date5 = DateTime.Today;

            //or
            DateTime date6 = (date != null) ? date.GetValueOrDefault() : DateTime.Today;
            
            //you can do this:
            DateTime date7 = date ?? DateTime.Today;
            */






            //Dynamic 
            /*
            //dynamic excelObject = "victor";
            //compile time error if excelObject is not dynamic.
            //excelObject.Optimize();

            //this changes type
            dynamic thing = "victor";
            Console.WriteLine(thing);
            thing = 10;
            Console.WriteLine(thing);


            dynamic a = 10;
            dynamic b = 5;
            //siunce a and b are dynamic, this forces c to be dynamic.
            var c = a + b;


            int i = 5;
            dynamic d = i;//d is dynamic, but currently type int
            long l = d; //works since you can cast an int to a long
            */










            //Exception Handling
            //global error catching
            /*
            var streamReader = new StreamReader(@"C:\Users\kirbo\Documents\code_projects\CSharpUdemy\txt.txt");
            try
            {
                int? thing2 = null;
                var calc = new Calculator();
                var value = calc.Divide(1, 0);

            }
            catch (DivideByZeroException ex) // you can pick specific exceptions and get more and more broad from there
            {
                Console.WriteLine("divide by 0 exeption found");
            }
            catch (ArithmeticException ex) // one level up from DivideByZero
            {

            }
            catch (Exception e)
            {
                Console.WriteLine("unknown error: " + e);
            }
            finally
            {
                //IDisposable is a interface that allows for some data to be grabbed by the garbage collector

            }
            */


            /*
            //initalize so the streamReader can be seen by the finally block. Useful maybe?
            StreamReader streamReader = null;
            try
            {
                //if file doesn't exist, this would throw an error
                streamReader = new StreamReader(@"C:\Users\kirbo\Documents\code_projects\CSharpUdemy\txt.txt");
                var content = streamReader.ReadToEnd();
                throw new Exception("oops");
            }
            catch(Exception ex)
            {
                Console.WriteLine("unexpected error" + ex);
            }
            finally
            {
                //If you do not use this, the file will be open for as long as the program is open.
                //also check to see if already null and closed. If not, we will take care of it here.
                if(streamReader != null)
                    streamReader.Dispose();
            }
            */
            /*
            try
            {
                //cleaner way of the above code is with the using keyword so we don't need that finally
                using (var streamReader = new StreamReader(@"C:\Users\kirbo\Documents\code_projects\CSharpUdemy\txt.txt"))
                {

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            */


            //create custom exceptions

            try
            {
                var api = new YouTubeApi();
                api.GetVideos("test");
            }
            catch (Exception e)
            {
                Console.WriteLine("could not grab the videos from YouTube");
                //throw;
            }



        }
    }
}




//some additional types of T:
//to compare                    > where T : IComparable
//to compare                    > where T : Product
//to say any class or subclass  > where T : struct
//to say T is a class/ref type  > where T : class
//has defualt constructor       > where T : new()


