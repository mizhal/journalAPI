﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Journal2API.Models
{
    public interface ISortable
    {
        ulong Position { get; set; }
    }
}
