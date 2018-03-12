using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProjectManagementApp.Models
{
    public class AssignPerson
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public int ProjctId { get; set; }
        public virtual Projct Projct { get; set; }
        public string AssignBy { get; set; }
        
    }
}