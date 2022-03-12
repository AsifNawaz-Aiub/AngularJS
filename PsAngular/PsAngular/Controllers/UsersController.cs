using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using PsAngular.Models;
using PsAngular.Models.ViewModel;

namespace PsAngular.Controllers
{
    [RoutePrefix("api/User")]
   
    [EnableCors(origins: "*", headers: "*", methods: "*")]

    public class UsersController : ApiController
    {
        private PsContext db = new PsContext();
        string error = string.Empty;
        result result = new result();

        [Route("AllUsers", Name = "AllUsers")]
        public IHttpActionResult GetUsers()
        {

          /*    List<Department> dept = db.Departments.ToList();
              List<Designation> desg = db.Designation.ToList();
              
            
            var types = Enum.GetValues(typeof(UserType))
                           .Cast<UserType>()
                           .ToList();
            List<User> usr = db.Users.ToList();
*/
           
            
            /*   var query = from u in usr
                           join tp in types
                           on u.UserType equals tp.types
                    
                           select u;
               Console.WriteLine(query);*/
        return Ok(db.Users.ToList()); 
           
        }


        [Route("CreateUser", Name = "CreateUser")]
        public IHttpActionResult SaveUser(UserViewModel user)
        {
            try
            {
                if (SaveUserLogic(user))
                {
                    Models.User us = new User();
                    us.FirstName = user.FirstName;
                    us.LastName = user.LastName;
                    us.Email = user.Email;
                    us.DepartmentId = user.DepartmentId;
                    us.DesignationId = user.DesignationId;
                    us.UserType = user.UserType;
                    db.Users.Add(us);
                    db.SaveChanges();
                    return Ok("success");
                } else {
                    result.HasError = true;
                    //result.Errors.Add(error);
                    return Ok(error);
                }
            } catch (Exception ex) {
                result.HasError = true;
                (result.Errors).Add(ex.GetBaseException().Message.ToString());
            }
            return Ok("success");
          
        }

        [Route("UpdateUser/{id}", Name = "UpdateUser")]
        public IHttpActionResult PutUsers([FromUri] int id,UserViewModel user)
        {
            try
            {
                if (SaveUserLogic(user))
                {
                    User data = db.Users.Find(id);
                    data.FirstName = user.FirstName;
                    data.LastName = user.LastName;
                    data.Email = user.Email;
                    data.DepartmentId = user.DepartmentId;
                    data.DesignationId = user.DesignationId;
                    data.UserType = user.UserType;
                    db.Entry(data).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    return Ok("success");
                }
                else
                {
                    result.HasError = true;
                    //result.Errors.Add(error);
                    return Ok(error);
                }
            }
            catch (Exception ex)
            {
                result.HasError = true;
                (result.Errors).Add(ex.GetBaseException().Message.ToString());
            }
            return Ok("success");

        }

        [Route("DeleteUser/{id}", Name = "DeleteUser")]
        public IHttpActionResult DeleteUser([FromUri] int id)
        {
            var user = db.Users.Find(id);
            db.Users.Remove(user);
            db.SaveChanges();
            return Ok("success");
        }

        [Route("Departments", Name = "Departments")]
        public IHttpActionResult GetDepartments()
        {
             return Ok(db.Departments.ToList());

        }

        [Route("Designations", Name = "Designations")]
        public IHttpActionResult GetDesignations()
        {
            return Ok(db.Designation.ToList()); 

        }
        [Route("{id}", Name = "UserById")]
        public IHttpActionResult GetUserById([FromUri] int id)
        {
            return Ok(db.Users.Find(id)); 

        }

        [Route("AddEditUser", Name = "AddEditUser")]
        public IHttpActionResult PostAddEditUser(UserViewModel user) {

            if (user.UserId == 0)
            {
                if (!string.IsNullOrEmpty(user.FirstName))
                {

                    if (!Regex.IsMatch(user.FirstName, @"^[a-zA-Z]+(?:[\s.]+[a-zA-Z]+)*$")) { return Ok("Firstame Must Contain a-z ,A-Z"); }
                }
                else { return Ok("Firstname is required"); }
                if (!string.IsNullOrEmpty(user.LastName))
                {
                    if (!Regex.IsMatch(user.LastName, @"^[a-zA-Z]+(?:[\s.]+[a-zA-Z]+)*$")) { return Ok("Lastame Must Contain a-z ,A-Z"); }
                }
                else { return Ok("Lastname is required"); }


                if (!string.IsNullOrEmpty(user.Email))
                {
                    string emailRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                                             @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                                                @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
                    Regex re = new Regex(emailRegex);
                    if (!re.IsMatch(user.Email))
                    {
                        return Ok("Inocrrect Email");
                    }
                }
                else
                {
                    return Ok("Email is Required");
                }
                if (user.DepartmentId == 0)
                {
                    return Ok("Department Required");
                }
                if (user.DesignationId == 0)
                {
                    return Ok("Designation Required");
                }
                if (user.UserType == 0)
                {
                    return Ok("User Type Required");
                }

                Models.User us = new User();
                us.FirstName = user.FirstName;
                us.LastName = user.LastName;
                us.Email = user.Email;
                us.DepartmentId = user.DepartmentId;
                us.DesignationId = user.DesignationId;
                us.UserType = user.UserType;
                db.Users.Add(us);
                db.SaveChanges();
                return Ok("success");
            }
            else {
                //Console.WriteLine(user);
                if (!string.IsNullOrEmpty(user.FirstName))
                {

                    if (!Regex.IsMatch(user.FirstName, @"^[a-zA-Z]+(?:[\s.]+[a-zA-Z]+)*$")) { return Ok("Firstame Must Contain a-z ,A-Z"); }
                }
                else { return Ok("Firstname is required"); }
                if (!string.IsNullOrEmpty(user.LastName))
                {
                    if (!Regex.IsMatch(user.LastName, @"^[a-zA-Z]+(?:[\s.]+[a-zA-Z]+)*$")) { return Ok("Lastame Must Contain a-z ,A-Z"); }
                }
                else { return Ok("Lastname is required"); }


                if (!string.IsNullOrEmpty(user.Email))
                {
                    string emailRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                                             @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                                                @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
                    Regex re = new Regex(emailRegex);
                    if (!re.IsMatch(user.Email))
                    {
                        return Ok("Inocrrect Email");
                    }
                }
                else
                {
                    return Ok("Email is Required");
                }
                if (user.DepartmentId == 0)
                {
                    return Ok("Department Required");
                }
                if (user.DesignationId == 0)
                {
                    return Ok("Designation Required");
                }
                if (user.UserType == 0)
                {
                    return Ok("User Type Required");
                }
                User data = db.Users.Find(user.UserId);
                data.FirstName = user.FirstName;
                data.LastName = user.LastName;
                data.Email = user.Email;
                data.DepartmentId = user.DepartmentId;
                data.DesignationId = user.DesignationId;
                data.UserType = user.UserType;
                db.Entry(data).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return Ok("success");

            }
        
        
        }
        [Route("GetUserTypes", Name = "GetUserTypes")]
        public IHttpActionResult GetUserTypes()
        {
            var types = Enum.GetNames(typeof(Types));
                         
       
            return Ok(types);

        }

        public bool SaveUserLogic(UserViewModel user) {
            error = string.Empty;
            if (!string.IsNullOrEmpty(user.FirstName))
            {

                if (!Regex.IsMatch(user.FirstName, @"^[a-zA-Z]+(?:[\s.]+[a-zA-Z]+)*$")) { error = "Firstame Must Contain a-z ,A-Z"; return false; }
            }
            else { error = "Firstname is required"; return false; }
            if (!string.IsNullOrEmpty(user.LastName))
            {
                if (!Regex.IsMatch(user.LastName, @"^[a-zA-Z]+(?:[\s.]+[a-zA-Z]+)*$")) { error = "Lastame Must Contain a-z ,A-Z"; return false; }
            }
            else { error = "Lastname is required"; return false; }


            if (!string.IsNullOrEmpty(user.Email))
            {
                string emailRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                                         @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                                            @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
                Regex re = new Regex(emailRegex);
                if (!re.IsMatch(user.Email))
                {
                     error = "Inocrrect Email"; return false;
                }
            }
            else
            {
                 error = "Email is Required"; return false;
            }
            if (user.DepartmentId == 0)
            {
              ; error = "Department Required"; return false;
            }
            if (user.DesignationId == 0)
            {
               error = "Designation Required"; return false;
            }
            if (user.UserType == 0)
            {
                error = "User Type Required"; return false;
            }
            return true; 
        }



    }
}