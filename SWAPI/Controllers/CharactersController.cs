using Azure.Core;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Nest;
using Newtonsoft.Json;
using SWAPI.Models;
using System;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Text.Json;
using static System.Net.Mime.MediaTypeNames;
using JsonSerializer = Newtonsoft.Json.JsonSerializer;

namespace SWAPI.Controllers
{

    [ApiController]

    public class CharactersController : ControllerBase
    {
        private readonly IConfiguration _config;
        
        public CharactersController(IConfiguration config)
        {
            _config = config;
        }
        [Route("swapi/public/characters")]
        [HttpGet]
        public ActionResult<IEnumerable<ResponseSW>> Characters(int PageNumber)
        {
            if (PageNumber < 1)
            {
                return NotFound();
            }
            var SWAPIBaseUrl = _config.GetValue<string>("SWAPIBaseUrl");
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(SWAPIBaseUrl + "=" + PageNumber);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.GetAsync(SWAPIBaseUrl + "=" + PageNumber).Result;
                var jsonresult = JsonConvert.DeserializeObject<ResponseSW>(response.Content.ReadAsStringAsync().Result.ToString());
                return Ok(jsonresult);

            }

        }

        [Route("swapi/protected/download")]
        [HttpGet]
        public ActionResult<IEnumerable<ResponseSW>> Download(int PageNumber)
        {
            if (PageNumber < 1)
            {
                return NotFound();
            }
            var SWAPIBaseUrl = _config.GetValue<string>("SWAPIBaseUrl");
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(SWAPIBaseUrl + "=" + PageNumber);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.GetAsync(SWAPIBaseUrl + "=" + PageNumber).Result;

                // if (response.IsSuccessStatusCode)

                var jsonresult = JsonConvert.DeserializeObject<ResponseDownload>(response.Content.ReadAsStringAsync().Result.ToString());
                return Ok(jsonresult);

            }
        }
    }
}
