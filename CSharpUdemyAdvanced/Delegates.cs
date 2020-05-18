using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpUdemyAdvanced
{
    public class CustomFilters
    {
        public static void RemoveRedEyeFilter(Photo photo)
        {
            Console.WriteLine("removed redeye");
        }
    }

    public class Photo
    {
        public static Photo Load(string path)
        {
            return new Photo();
        }

        public void Save()
        {

        }
    }

    public class PhotoProcessor
    {
        
        //replacing PhotoFilterHandler with the System Action delegate


        //public delegate void PhotoFilterHandler(Photo photo);
        public void Process(string path, Action<Photo> filterHandler)
        {
            var photo = Photo.Load(path);

            //this is a system delegate
            //this delegate can be Generic
            //action can be generic with 16 overloads
            //System.Action<>

            //Action is similar to func
            //func can return a value
            //System.Func<>
            
            //remove the 4 lines below and replace with a delegate
            //var filters = new PhotoFilters();
            //filters.ApplyBrightness(photo);
            //filters.ApplyContrast(photo);
            //filters.Resize(photo);

            filterHandler(photo);


            photo.Save();
        }
    }

    public class PhotoFilters
    {
        public void ApplyBrightness(Photo photo)
        {
            Console.WriteLine("Apply brightness");
        }

        public void ApplyContrast(Photo photo)
        {
            Console.WriteLine("apply contrast");
        }

        public void Resize(Photo photo)
        {
            Console.WriteLine("resize photo");
        }


    }
}
