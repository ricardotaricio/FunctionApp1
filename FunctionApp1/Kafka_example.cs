using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Kafka;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace FunctionApp1
{
    //public static class Kafka_example
    //{
    //    [FunctionName("Kafka_example")]
    //    public static void Run([QueueTrigger("myqueue-items", Connection = "adsfasdf")]string myQueueItem, ILogger log)
    //    {
    //        log.LogInformation($"C# Queue trigger function processed: {myQueueItem}");
    //    }
    //}

    public static class kafka_example
    {
        [FunctionName("kafkaApp")]
        public static void ConfluentCloudStringTrigger(
             [KafkaTrigger(
                "BootstrapServer",
                "users",
                ConsumerGroup = "<ConsumerGroup>",
                Protocol = BrokerProtocol.SaslSsl,
                AuthenticationMode = BrokerAuthenticationMode.Plain,
                Username = "<APIKey>",
                Password = "<APISecret>",
                SslCaLocation = "confluent_cloud_cacert.pem")]

        KafkaEventData<string> kafkaEvent,
        ILogger logger)
        {
            logger.LogInformation(kafkaEvent.Value.ToString());
        }
    }
}
