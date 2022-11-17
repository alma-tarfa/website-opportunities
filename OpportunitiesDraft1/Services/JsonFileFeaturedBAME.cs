using Microsoft.AspNetCore.Hosting;
using OpportunitiesDraft1.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace OpportunitiesDraft1.Services
{
    public class JsonFileFeaturedBAME
    {
        public JsonFileFeaturedBAME(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }
        public IWebHostEnvironment WebHostEnvironment { get; }
        private string JsonFileName
        {
            get { return Path.Combine(WebHostEnvironment.WebRootPath, "data", "FeaturedBAME.json"); }
        }

        public IEnumerable<FeaturedBAME> GetFeaturedBAME()
        {
            using (var jsonFileReader = File.OpenText(JsonFileName))
            {
                return JsonSerializer.Deserialize<FeaturedBAME[]>(jsonFileReader.ReadToEnd(),
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
            }
        }
    }
}
