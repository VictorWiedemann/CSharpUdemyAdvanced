using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace CSharpUdemyAdvanced
{
    //public class RichString : String
    //{
        
    //}

    public static class StringExtensions
    {
        //To do this, shorten will extend some string functionality. To do this, the format will look like:
        //this, <class we are extending>, variable name "this String str" argument is the instance of the class. 
        //In the case of the main method, it is the "string post"
        public static string Shorten(this String str, int numberOfWords)
        {
            if (numberOfWords < 0)
            {
                throw new ArgumentOutOfRangeException("numberOfWords shuold be greater than or equal to 0");
            }
            
            if (numberOfWords == 0)
                return "";

            var words = str.Split(' ');
            if (words.Length <= numberOfWords)
                return str;
            

            return string.Join(" ", words.Take(numberOfWords));
        }
    }


}
