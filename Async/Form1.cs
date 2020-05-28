using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Async
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //This causes the window to be unresponsive
        private void button1_Click(object sender, EventArgs e)
        {
            DownloadHtml("http://msdn.microsoft.com");
        }

        

        public void DownloadHtml(string url)
        {
            var webClient = new WebClient();
            var html = webClient.DownloadString(url);
            using (var streamWriter = new StreamWriter(@"C:\\steamcmd\\randomFile.html"))
            {
                
                streamWriter.Write(html);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            _ = DownloadHtmlAsync("http://msdn.microsoft.com");
        }

        //async version uses task.
        //there is async and async<>
        //if you want a return value, use the async<>
        //adding Async suffix is best practice.
        public async Task DownloadHtmlAsync(string url)
        {
            //.DownloadString and .Write are not async. So these will also be blocking (?)
            var webClient = new WebClient();
            
            //await tells the compiler that the code will jump out of the function and continue.
            //It will come back to this line as soon as this Async call is done.
            var html =  await webClient.DownloadStringTaskAsync(url);
            using (var streamWriter = new StreamWriter(@"C:\\steamcmd\\randomFile.html"))
            {

                await streamWriter.WriteAsync(html);
            }
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            //html below is actually not the string, it is now the task of a string
            var html = await GetHtmlAsync("http://msdn.microsoft.com");
            MessageBox.Show(html);
        }





        public async Task<string> GetHtmlAsync(string url)
        {
            //.DownloadString and .Write are not async. So these will also be blocking (?)
            var webClient = new WebClient();

            //await tells the compiler that the code will jump out of the function and continue.
            //It will come back to this line as soon as this Async call is done.
            var html = await webClient.DownloadStringTaskAsync(url);
            var htmlSubstring = html.Substring(0, 10);

            return htmlSubstring;
        }

        //This code will run the exact same as button3
        private async void button4_ClickAsync(object sender, EventArgs e)
        {
            //This line will run in a new task and then move to the next line
            var htmlTask = GetHtmlAsync("http://msdn.microsoft.com");
            MessageBox.Show("Click here to wait for the return value.");

            /*
             *
             *you can do a bunch of buisness logic here before needing the return value of the task.
             *
             */
            //because of the await keyword here, we will wait for the return of the async task to finish before we can keep moving.
            var html = await htmlTask;
            MessageBox.Show(html);
        }
    }
}
