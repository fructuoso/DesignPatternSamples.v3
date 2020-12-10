using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace DesignPatternSamples.Publisher.Fake
{
    public class PublisherFake : IPublisher
    {
        protected readonly ILogger _Logger;

        public PublisherFake(ILogger<PublisherFake> logger)
        {
            _Logger = logger;
        }

        public Task PublishDataAsync<TMessage>(string eventName, TMessage data)
        {
            _Logger.LogInformation($"EVENT: {eventName} DATA: {JsonConvert.SerializeObject(data, Formatting.None)}");
            return Task.CompletedTask;
        }
    }
}
