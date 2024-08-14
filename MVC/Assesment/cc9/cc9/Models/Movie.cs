﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace cc9 
{ 
    public class Movie 
    { 
        public int MovieId { get; set; }
        [Required]
        [StringLength(100)] 
        public string MovieName { get; set; }
        [Required] 
        [DataType(DataType.Date)] 
        public DateTime DateOfRelease { get; set; }
    }
}