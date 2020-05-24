using System;
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

            var video = new Video() { Title = "Video 1" };
            var videoEncoder = new VideoEncoder(); // publisher
            var mailService = new MailService(); //subscriber
            var messageService = new MessageService(); //subscriber 2

            //Here is how to do the Event subscription
            videoEncoder.VideoEncoded += mailService.OnVideoEncoded;
            videoEncoder.VideoEncoded += messageService.OnVideoEncoded;

            videoEncoder.Encode(video); 

        }



    }
}




//some additional types of T:
//to compare                    > where T : IComparable
//to compare                    > where T : Product
//to say any class or subclass  > where T : struct
//to say T is a class/ref type  > where T : class
//has defualt constructor       > where T : new()


