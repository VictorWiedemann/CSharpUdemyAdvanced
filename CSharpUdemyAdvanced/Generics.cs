using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;




//some additional types of T:
//to compare                    > where T : IComparable
//to compare                    > where T : Product
//it is a value type, not ref   > where T : struct
//to say T is a class/ref type  > where T : class
//has defualt constructor       > where T : new()

namespace CSharpUdemyAdvanced
{
    public class DiscountCalculator<TProduct> where TProduct : Product
    {
        public float CalculateDiscount(TProduct product)
        {
            return product.Price;
        }

    }

    public class Product
    {
        public float Price { get; set; }
        public string Title { get; set; }
    }

    public class Utilities<T> where T : IComparable, new()
    {
        public int CompareTo(object? obj)
        {
            throw new NotImplementedException();
        }

        public int Max(int a, int b)
        {
            return a > b ? a : b;
        }

        //public T Max<T>(T a, T b) : IComparable //can also put IComparable at the util class level instead.
        public T Max (T a, T b)
        {
            return a.CompareTo(b) > 0 ? a : b;
        }

        public void DoSomething(T value)
        {
            var obj = new T();
        }
    }


    public class Book : Product
    {
        public string Isbn { get; set; }
    }


    public class GenericDictionary<TKey, TValue>
    {
        public void Add(TKey key, TValue value)
        {

        }
    }

    public class GenericList<T>
    {
        public void Add(T value)
        {

        }

        public T this[int index] => throw new NotImplementedException();
    }


    //this is the same thing as System.Nullable<T>
    public class Nullable<T> where T : struct //struct means it has to be a a value type, not a ref type.
    {
        private object _value;

        public Nullable(T value)
        {
            _value = value;
        }

        public bool HasValue => _value != null;

        public T GetValueOrDefault()
        {
            if (HasValue)
                return (T)_value;

            return default(T);
        }

        public Nullable()
        {
            
        }
    }

}
