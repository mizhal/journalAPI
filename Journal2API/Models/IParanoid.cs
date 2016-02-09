using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Journal2API.Models
{
    public interface IParanoid : IItem
    {
        DateTime? DeletedAt { get; set; }
    }
}
