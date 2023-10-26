using MQTTnet;
using MQTTnet.Client;
using System;
using System.Threading.Tasks;
namespace Client
{
    public class MqttClient
    {
        private readonly IMqttClient _mqttClient;

        public MqttClient(IConfiguration configuration)
        {
            _mqttClient = new MqttFactory().CreateMqttClient();
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }
        public async Task ConnectAsync()
        {
            string hostIp = Configuration["MqttOption:HostIp"];
            int hostPort = int.Parse(Configuration["MqttOption:HostPort"]);
           
            var options = new MqttClientOptionsBuilder()
                .WithClientId(Guid.NewGuid().ToString())
                .WithTcpServer(hostIp, hostPort) // Адрес и порт MQTT-брокера
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
