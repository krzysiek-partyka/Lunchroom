﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lunchroom.Application.Lunchroom
{
    public class LunchroomDto
    {
        public string Name { get; set; } = default!;

        public string? Description { get; set; }
        public string? EncodedName { get; set; }
        
        public string? City { get; set; }
        public string? Street { get; set; }
        public string? PostalCode { get; set; }
        public string? Phone { get; set; }
        public bool IsEditable { get; set; }

    }
}
