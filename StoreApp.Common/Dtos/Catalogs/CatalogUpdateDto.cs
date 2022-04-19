﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.Common.Dtos.Catalogs
{
    public class CatalogUpdateDto
    {
        [Required]
        public string Name { get; set; }
        public string Avatar { get; set; }
    }
}
