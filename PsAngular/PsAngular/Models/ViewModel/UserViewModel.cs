using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PsAngular.Models.ViewModel
{
    public class UserViewModel
    {
        public int UserId { get; set; }

        
        public string FirstName { get; set; }

     
        public string LastName { get; set; }

       
        public string Email { get; set; }

 

        public int DepartmentId { get; set; }

        public int DesignationId { get; set; }
        public UserType UserType { get; set; }
    }
}