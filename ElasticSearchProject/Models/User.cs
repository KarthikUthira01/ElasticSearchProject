using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElasticSearchProject.Models
{
    /// <summary>
    /// Data Transfer Object for User index.
    /// </summary>
    public class User
    {
        public string Name { get; set; }
        public string Age { get; set; }
        public string Education { get; set; }
    }
}
