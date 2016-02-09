using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Journal2API.Models
{
    public interface IRepo: IDisposable
    {
        DbContext CurrentContext();
    }
}