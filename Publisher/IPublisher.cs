using System.Threading.Tasks;

namespace DesignPatternSamples.Publisher
{
    public interface IPublisher
    {
        Task PublishDataAsync<TMessage>(string eventName, TMessage data);
    }
}
