using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectManagementApp.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DisplayName("Select Project")]

        public int ProjctId { get; set; }
        public virtual Projct Projct { get; set; }

        [Required]
        [DisplayName("Select Task")]
        public int TasksId { get; set; }
        public virtual Tasks Tasks { get; set; }

        [Required]
        [StringLength(300)]
        public string Commentt { get; set; }
        public string CommentBy { get; set; }
        public DateTime Time { get; set; }
    }
}