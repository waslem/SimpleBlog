using SimpleBlog.Web.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SimpleBlog.Web.Areas.Admin.ViewModels
{
    public class UsersIndex
    {
        public IEnumerable<User> Users { get; set; }
    }

    // simple data transfer object created here
    public class RoleCheckBox
    {
        public int Id { get; set; }
        public bool IsChecked { get; set; }
        public string Name { get; set; }
    }

    public class UsersNew
    {
        [Required]
        [MaxLength(128)]
        public string Username { get; set; }

        [Required]
        [DataType(dataType: DataType.Password)]
        public string Password { get; set; }

        [Required]
        [MaxLength(256)]
        [DataType(dataType: DataType.EmailAddress)]
        public string Email { get; set; }

        public IList<RoleCheckBox> Roles { get; set; }
    }

    public class UsersEdit
    {
        [Required]
        [MaxLength(128)]
        public string Username { get; set; }

        [Required]
        [MaxLength(256)]
        [DataType(dataType: DataType.EmailAddress)]
        public string Email { get; set; }

        public IList<RoleCheckBox> Roles { get; set; }
    }

    public class UsersResetPassword
    {
        public string Username { get; set; }

        [Required]
        [DataType(dataType: DataType.Password)]
        public string Password { get; set; }
    }
}