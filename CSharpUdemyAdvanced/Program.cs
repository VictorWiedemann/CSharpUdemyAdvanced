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
        }


    }
}




//some additional types of T:
//to compare                    > where T : IComparable
//to compare                    > where T : Product
//to say any class or subclass  > where T : struct
//to say T is a class/ref type  > where T : class
//has defualt constructor       > where T : new()


