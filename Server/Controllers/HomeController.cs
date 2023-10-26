using Microsoft.AspNetCore.Mvc;

namespace Client.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly MqttClient _mqttClient;
        public HomeController(ILogger<HomeController> logger, MqttClient mqttClient)
        {
            _logger = logger;
            _mqttClient = mqttClient;
        }
        public IActionResult Index()
        {
            return View();
        }
        
    }
}
