using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _18_events
{


    internal class Author
    {
        private Action<string> published;
        public event Action<string> Published         //after publish
        {
            //subscribe [+=] 
            add 
            {
                published += value;
            }
            //unsubscribe [-=]
            remove
            {
                published += value;
            }

        }
        public void Publish(string topic)
        {
            Console.WriteLine($"Publisher the new article with topic: {topic}");

            published?.Invoke(topic);
        }

    }
}
