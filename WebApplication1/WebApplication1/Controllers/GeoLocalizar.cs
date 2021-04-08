using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;
using Nominatim.API.Address;
using Nominatim.API.Models;
using WebApplication.DAO.Model;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    //
    public class GeoLocalizar : ControllerBase
    {
        Context _context;
        public GeoLocalizar(Context context)
        {
            _context = context;
        }//

        [HttpPost("GeoLocalization")]
        public IActionResult GeoLocalization(Models.GeoLocalizarModel geoLocalizar)
        {
            try
            {
                var requestToSave = new Request
                {
                    State = geoLocalizar.provincia,
                    Street = geoLocalizar.calle,
                    Country = geoLocalizar.pais,
                    City = geoLocalizar.código_postal,
                    PostalCode = geoLocalizar.código_postal
                };

                _context.Requests.Add(requestToSave);

                _context.SaveChanges();
                var x = new AddressSearcher();
                var r = x.Lookup(new AddressSearchRequest
                {
                    OSMIDs = new List<string>(new[] { "R146656", "W104393803", "N240109189" }),
                    BreakdownAddressElements = true,
                    ShowAlternativeNames = true,
                    ShowExtraTags = true
                });
                r.Wait();
                //NUEVO CAMBIO
                var response = new Model.GeoLocalizarResponse();
                response.Id = requestToSave.Id;
                Nominatim.API.Address.AddressSearcher j = new Nominatim.API.Address.AddressSearcher();
                HttpClient clientToken = new HttpClient();
                string url = @"https://nominatim.openstreetmap.org/search?";
                var jsonRequest = new
                {
                    street = "pellegrini",
                    city = "",
                    county = "",
                    state = "",
                    country = "Argentina",
                    postalcode = ""
                };

                var content = new StringContent(JsonConvert.SerializeObject(jsonRequest), System.Text.Encoding.UTF8, "application/json");
                HttpResponseMessage requestResult = clientToken.PostAsync(url, content).Result;
                var resToken = requestResult.Content.ReadAsStringAsync().Result;
                var responseGeoCodificadorObject = JsonConvert.DeserializeObject<Root>(resToken);

                return Accepted(JsonConvert.SerializeObject(response));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
