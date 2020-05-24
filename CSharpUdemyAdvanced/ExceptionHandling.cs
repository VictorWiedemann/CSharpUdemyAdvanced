using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpUdemyAdvanced
{
    public class Calculator
    {
        public int Divide(int num, int den)
        {
            try
            {
                return num / den;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw (e);
            }
        }
    }


    //don't make your Api's exceptions viewable from outside the class/namespace. Makes it easier for your program
    //to be encapsulated.

    //It looks very basic:
    public class YouTubeException : Exception
    {
        public YouTubeException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }

    public class YouTubeApi
    {
        public List<Video> GetVideos(string user)
        {
            try
            {
                //access Youtube web service
                //read data
                //create list of video objects
                throw new Exception("Some low level YouTube Error.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new YouTubeException("Couldn't not fetch the videos from YouTube.", e);
            }

            return new List<Video>();
        }
    }
}
