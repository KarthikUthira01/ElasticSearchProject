﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElasticSearchProject.Models
{
    /// <summary>
    /// Data Transfer Object for Book index.
    /// </summary>
    public class Book
    {
        public string Title { get; set; }
        public string ISBN { get; set; }
        public int PageCount { get; set; }
        public string ThumbNailURL { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public string Status { get; set; }
        public string Authors { get; set; }
        public string Categories { get; set; }
        public string Name { get; set; }
        public string Age { get; set; }
        public string Education { get; set; }

    }
}
