using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Channels;

namespace CSharpUdemyAdvanced
{
    public class VideoEncoder
    {

        // Step 1 for Events Define a delegate
        // Step 2, Define an event based on that delegate
        // Step 3, Raise the event

        //1 - being void with object source and EventArgs is standard
        //EventArgs has been replaced by VideoEventArgs which is derived from EventArgs
        //public delegate void VideoEncodedEventHandler(object source, VideoEventArgs args);    ----------

        //2 naming scheme should be past tense
        //public event VideoEncodedEventHandler VideoEncoded;    ----------


        //There is a generic version of event handlers. The below line is identical steps 1 and 2 combined.
        public event EventHandler<VideoEventArgs> VideoEncoded;
        
        //this one means that there is no return args
        public event EventHandler VideoEncoded2; 



        //3 - being protected virtual void is standard.
        //naming scheme should be On<name of event>

        //Video that was encoded was passed by the method Encode(Video video)
        protected virtual void OnVideoEncoded(Video video)
        {
            Console.WriteLine("event handler started");
            //check to see if anyone is subbed
            if (VideoEncoded != null)
            {
                Console.WriteLine("event handler not null");
                
                //use this to call the subscribed. Send EventArgs.Empty instead of "new VideoEventArgs(){Video = video} when you have no payload 
                VideoEncoded(this, new VideoEventArgs(){Video = video});
            }
        }

        public void Encode(Video video) 
        {
            Console.WriteLine("Encoding Video");
            Thread.Sleep(1000);

            //Raise an event
            OnVideoEncoded(video);
        }
    }

    public class Video
    {
        public string Title { get; set; }
    }

    public class MailService
    {
        public void OnVideoEncoded(object source, VideoEventArgs e)
        {
            Console.WriteLine("MailService: Sending an email" + e.Video.Title);
        }
    }

    public class MessageService
    {
        public void OnVideoEncoded(object source, VideoEventArgs e)
        {
            Console.WriteLine("Message Service: Sending a text message..." + e.Video.Title);
        }
    }

    public class VideoEventArgs : EventArgs
    {
        public Video Video { get; set; }
    }


}
