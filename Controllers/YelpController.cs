// YelpController.cs
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace YelpProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class YelpController : ControllerBase
    {
        private readonly HttpClient _httpClient;

        public YelpController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
        }

        [HttpGet]
        public async Task<IActionResult> GetBusinesses()
        {
            try
            {
                string apiKey = "6c0rdzcdivWItL4kmlpfNYhyqipK9mXbaBTsQsr1QD6o2tXmbUClZr4SVGDJF3wRDqbGQxSYct4mgdHKri3XrxqiPEVaPb--tOqrOXEBnmFjCFv_EPLI6oVnNAe4ZXYx";
                string location = "New York"; // Cambia esto según tu ubicación

                string url = $"https://api.yelp.com/v3/businesses/search?location={location}";

                _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");

                HttpResponseMessage response = await _httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject(json);
                    return Ok(result);
                }
                else
                {
                    return StatusCode((int)response.StatusCode);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
