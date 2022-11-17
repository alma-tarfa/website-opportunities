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
    public class JsonFileFeaturedOpportunists
    {
        public JsonFileFeaturedOpportunists(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }

        public IWebHostEnvironment WebHostEnvironment { get; }

        private string JsonFileName
        {
            get { return Path.Combine(WebHostEnvironment.WebRootPath, "data", "FeaturedOpportunists.json"); }
        }

        public IEnumerable<FeaturedOpportunist> GetFeaturedOpportunists()
        {
            using (var jsonFileReader = File.OpenText(JsonFileName))
            {
                return JsonSerializer.Deserialize<FeaturedOpportunist[]>(jsonFileReader.ReadToEnd(),
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
            }
        }

    }
}
