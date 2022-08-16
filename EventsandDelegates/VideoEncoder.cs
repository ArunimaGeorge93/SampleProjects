using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EventsandDelegates
{
   public class VideoEncoder
    {
        //1- define a delegate
        //2- define an event based on that delegate
        //3- raise the event
        public delegate void VideoEncodedEventHandler(object source, EventArgs args);
        public event VideoEncodedEventHandler VideoEncoded;
        public void Encode(Video video)
        {
            Console.WriteLine("Encoding video...");
            Thread.Sleep(3000);
            OnVideoEncoded();
        }
        //.net framework suggests event publisher method should be protected, they should be virtual and void.
        //in terms of naming they should start with 'On' then followed with name of event.
        protected virtual void OnVideoEncoded()
        {
            if (VideoEncoded != null)
                VideoEncoded(this, EventArgs.Empty);
        }
    }
}
