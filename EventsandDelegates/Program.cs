using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsandDelegates
{
    class Program
    {
        static void Main(string[] args)
        {
            var video = new Video() { Title = "video 1" };
            var videoEncoder = new VideoEncoder(); //publisher
            var mailService = new MailService(); //subscriber
            var msgService = new MessageService(); //subscriber
            // register a handelr to that event
            //subscription
            videoEncoder.VideoEncoded += mailService.OnVideoEncoded;// reference or pointer to that method( mailservice.OnVideoEncoded)
            videoEncoder.VideoEncoded += msgService.OnvideEncoded;
            videoEncoder.Encode(video);
        }
    }
    public class MailService
    {
        public void OnVideoEncoded(object source,EventArgs e)
        {
            Console.WriteLine("MailService: Sending an email..");
        }
    }
    public class MessageService
    {
        public void OnvideEncoded(object source,EventArgs e)
        {
            Console.WriteLine("MessageService: Sending a text message");
        }
    }
}
