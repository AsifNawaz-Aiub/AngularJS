using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;
using System.Xml.Serialization;

namespace PsAngular.Models
{
    public class Department
    {
        [ForeignKey("User")]
        public int DepartmentId {get; set;}
        [Required]
        [StringLength(80)]
        public string DepartmentName {get; set;}
        [JsonIgnore, XmlIgnore]
        public ICollection<User> User { get; set; }
        //public virtual User UserId { get; set; }
    }
}