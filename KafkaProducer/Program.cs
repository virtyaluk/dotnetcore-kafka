using System;
using System.Collections.Generic;
using System.Text;
using Confluent.Kafka;
using Confluent.Kafka.Serialization;

namespace KafkaProducer
{
    public static class Program
    {
        public static void Main()
        {
            var config = new Dictionary<string, object>
            {
                { "bootstrap.servers", "localhost:9092" }
            };

            using (var producer = new Producer<Null, string>(config, null, new StringSerializer(Encoding.UTF8)))
            {
                producer.OnError += (_, e) => Console.WriteLine($"Error: {e.Reason}");
                
                string text = null;

                while (text != "exit")
                {
                    text = Console.ReadLine();
                    producer.ProduceAsync("hello-topic", null, text);
                }

                producer.Flush(100);
            }
        }
    }
}