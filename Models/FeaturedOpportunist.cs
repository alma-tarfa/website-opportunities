using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace OpportunitiesDraft1.Models
{
    public class FeaturedOpportunist
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public string Title { get; set; }

        public string VideoUrl { get; set; }

        public string ImageUrl { get; set; }

        public string Description { get; set; }


    }
}
