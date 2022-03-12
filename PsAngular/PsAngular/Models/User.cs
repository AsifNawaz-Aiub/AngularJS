using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PsAngular.Models
{
    public enum UserType
    {
        Teacher,
        Student
       
    }
    public partial class User
    {   [Key]
        public int UserId { get; set;}

        [Required]
        [StringLength(20)]
        public string FirstName { get; set;}

        [Required]
        [StringLength(20)]
        public string LastName { get; set; }

        [Required]
        [StringLength(20)]
        public string Email { get; set;}

        public UserType UserType { get; set; }



        public int DepartmentId { get; set; }

        public int DesignationId { get; set; }


        public virtual Department Department { get; set; }
        public virtual Designation Designation { get; set; }

    }
}