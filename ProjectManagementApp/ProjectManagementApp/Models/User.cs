using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectManagementApp.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1)]
        [DisplayName("Name")]
        public string Name { get; set; }

        [Required]
        [StringLength(40, MinimumLength = 5)]
        [DisplayName("Email")]
        [Index("Ix_Email", 1, IsUnique = true)]
       // [Remote("IsEmailExist", "Users", ErrorMessage = "This Email already exists!")]
        public string Email { get; set; }

        [DisplayName("Default Password")]
        public string DefaultPassword { get; set; }

        [Required]
        [StringLength(500, MinimumLength = 1)]
        [DisplayName("Status")]
        public string Status { get; set; }

        [Required]
        [DisplayName("Designation")]
        public int DesignationId { get; set; }
        public virtual Designation Designation { get; set; }

        
        public virtual ICollection<AssignPerson> AssignPersons { get; set; }
        public virtual ICollection<Tasks> Taskss { get; set; }
       
    }
}