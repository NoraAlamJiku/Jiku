using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectManagementApp.Models
{
    public class Projct
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3)]
        [DisplayName("Name")]
        public string Name { get; set; }

        [Required]
        [StringLength(12)]
        [DisplayName("Code Name")]
        public string CodeName { get; set; }

        [Required]
        [StringLength(300, MinimumLength = 5)]
        [DisplayName("Description")]
        public string Description { get; set; }

        [Required]
        [DisplayName("Possible Start Date")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [Required]
        [DisplayName("Possible End Date")]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        [Required]
        [DisplayName("Duration ( in days)")]
       // [DataType(DataType.Duration)]
        public int Duration { get; set; }
        public string UploadFile { get; set; }
       // [Required]
       // public string UploadFile { get; set; }
       // public HttpPostedFileBase UploadFile { get; set; }

        [Required]
        [DisplayName("Status")]
        public string Status { get; set; }

        public virtual ICollection<AssignPerson> AssignPersons { get; set; }
        public virtual ICollection<Tasks> Taskss { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}