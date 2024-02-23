using Microsoft.AspNetCore.Mvc;
using Vonage;
using Vonage.Request;
using System;

namespace YourNamespace.Controllers
{
    public class app : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SendSMS([FromBody] SmsRequestModel smsRequest)
        {
            try
            {
                var credentials = Credentials.FromApiKeyAndSecret(
                    "bbab309c",
                    "0LnFUFYRk43gINNg"
                );

                var vonageClient = new VonageClient(credentials);

                var response = vonageClient.SmsClient.SendAnSms(new Vonage.Messaging.SendSmsRequest()
                {
                    To = "19086443621", // Replace with the actual phone number
                    From = "15085954121", // Replace with the Vonage virtual number
                    Text = $"{smsRequest.Name} has signed out to {smsRequest.Location}"
                });

                return Json(new { Status = "Success", Response = response });
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine($"Error sending SMS: {ex.Message}");
                return Json(new { Status = "Error", Message = ex.Message });
            }
        }
    }

    public class SmsRequestModel
    {
        public string Name { get; set; }
        public string Location { get; set; }
    }
}
