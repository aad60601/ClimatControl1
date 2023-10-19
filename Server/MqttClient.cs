using MQTTnet;
using MQTTnet.Client;
using System;
using System.Threading.Tasks;
namespace Client
{
    public class MqttClient
    {
        private readonly IMqttClient _mqttClient;

        public MqttClient()
        {
            _mqttClient = new MqttFactory().CreateMqttClient();
        }

        public async Task ConnectAsync()
        {
            var options = new MqttClientOptionsBuilder()
                .WithClientId(Guid.NewGuid().ToString())
                .WithTcpServer("127.0.0.1", 1883) // Адрес и порт MQTT-брокера
                .WithCleanSession()
                .Build();

            await _mqttClient.ConnectAsync(options);
        }

        public async Task PublishAsync(string topic, string message)
        {
            var mqttApplicationMessage = new MqttApplicationMessageBuilder()
                .WithTopic(topic)
                .WithPayload(message)
                .Build();

            await _mqttClient.PublishAsync(mqttApplicationMessage);
        }

        public async Task SubscribeAsync(string topic)
        {
            await _mqttClient.SubscribeAsync(topic);
        }

        public async Task UnsubscribeAsync(string topic)
        {
            await _mqttClient.UnsubscribeAsync(topic);
        }
    }
}
