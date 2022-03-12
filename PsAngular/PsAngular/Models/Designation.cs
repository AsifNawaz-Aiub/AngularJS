using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace PsAngular.Models
{
    public class Designation
    {
        [ForeignKey("User")]
        public int DesignationId { get; set; }
        [Required]
        [StringLength(20)]
        public string DesignationName { get; set; }
        [JsonIgnore, XmlIgnore]
        public ICollection<User> User { get; set; }
        //public virtual User UserId { get; set; }
    }
}