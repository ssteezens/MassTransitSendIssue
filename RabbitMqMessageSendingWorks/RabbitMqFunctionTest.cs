﻿using System.IO;
using System.Threading.Tasks;
using MassTransit;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace RabbitMqMessageSendingWorks
{
    public class RabbitMqFunctionTest
    {
        private readonly IAsyncBusHandle _handle;
        private readonly IRequestClient<Message> _client;
        private readonly IMessageSender _messageSender;

        public RabbitMqFunctionTest(IAsyncBusHandle handle, 
            IRequestClient<Message> client, 
            IMessageSender messageSender)
        {
            _handle = handle;
            _client = client;
            _messageSender = messageSender;
        }
        
        [FunctionName("RabbitMqMessageSendingWorks")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            await _messageSender.Send();

            string name = req.Query["name"];

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            name = name ?? data?.name;

            string responseMessage = string.IsNullOrEmpty(name)
                ? "This HTTP triggered function executed successfully. Pass a name in the query string or in the request body for a personalized response."
                : $"Hello, {name}. This HTTP triggered function executed successfully.";

            return new OkObjectResult(responseMessage);
        }
    }
}

