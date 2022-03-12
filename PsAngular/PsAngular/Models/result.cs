using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PsAngular.Models
{
    public class result
    {
        public bool HasError { get; set; }
        public List<string> Errors { get; set; }
    }
}