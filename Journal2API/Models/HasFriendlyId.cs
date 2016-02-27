using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Journal2API.Models
{
    public interface HasFriendlyId
    {
        string Slug { get; set; }

        // <summary>
        // Implement this function to generate slugs from instance properties
        // </summary>
        string GenerateSlug();
    }
}
