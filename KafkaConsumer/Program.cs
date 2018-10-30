using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using Confluent.Kafka;
using Confluent.Kafka.Serialization;

namespace KafkaConsumer
{
    public static class Program
    {
        public static void Main()
        {
            var config = new Dictionary<string, object>
      {
          { "group.id", "sample-consumer" },
          { "bootstrap.servers", "localhost:9092" },
          { "enable.auto.commit", "false"}
      };

            using (var consumer = new Consumer<Null, string>(config, null, new StringDeserializer(Encoding.UTF8)))
            {
                consumer.OnError += (_, e) => Console.WriteLine($"Error: {e.Reason}");
                consumer.OnMessage += (_, msg) =>
                {
                    Console.WriteLine($"Topic: {msg.Topic} Partition: {msg.Partition} Offset: {msg.Offset} {msg.Value}");
                    consumer.CommitAsync(msg);
                };
                
                consumer.Subscribe(new [] { "hello-topic" });

                var cancelled = false;

                Console.CancelKeyPress += (_, e) =>
                {
                    e.Cancel = true;
                    cancelled = true;
                };
                
                Console.WriteLine("Ctrl-C to exit.");

                while (!cancelled)
                {
                    consumer.Poll(100);
                }
            }
        }
    }
}