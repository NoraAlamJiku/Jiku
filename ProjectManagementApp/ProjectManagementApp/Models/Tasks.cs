using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectManagementApp.Models
{
    public class Tasks
    {
        [Key]
        public int Id { get; set; }

        public int ProjctId { get; set; }
        public virtual Projct Projct { get; set; }

        public int UserId { get; set; }
        public virtual User User { get; set; }

        [Required]
        [StringLength(300, MinimumLength = 3)]
        public string Description { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DueDate { get; set; }

        public int PriorityId { get; set; }
        public virtual Priority Priority { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}