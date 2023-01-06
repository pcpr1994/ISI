using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ISIParkAPI.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    public class APISOAPController
    {
        private readonly IHttpClientFactory _clientFactory;
        public APISOAPController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        [HttpGet("qrcode")]
        public async Task<string> UsingGet(int value1, int value2)
        {
            
            var client = _clientFactory.CreateClient();
            var response = await client.GetAsync($"http://api.qrserver.com/v1/create-qr-code/?data={"ola"}&size=100x100", HttpCompletionOption.ResponseHeadersRead);

            //NULL check, HTTP Status Check....
            return await response.Content.ReadAsStringAsync();
        }
        public async Task<string> UsingPost(int value1, int value2)
        {
            try
            {
                var content = new StringContent($"value1={value1}&value2={value2}", Encoding.UTF8, "application/x-www-form-urlencoded");

                var client = _clientFactory.CreateClient();
                var response = await client.PostAsync("https://hostname.com/webservice.asmx/SampleMethod", content);

                //NULL check, HTTP Status Check....

                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Oops! Something went wrong");
                return ex.Message;
            }
        }
    }
}
