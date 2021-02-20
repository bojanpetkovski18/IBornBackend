using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Entities
{
    public class Program
    {
        [Key]
        public int ProgramId { get; set; }
        [Required(ErrorMessage = "The Program title is required.")]
        [Column(TypeName = "nvarchar(100)")]
        public string Title { get; set; }
        [Required(ErrorMessage = "The Program video url is required.")]
        [Column(TypeName = "nvarchar(1000)")]
        [Display(Name = "Video Url")]
        public string VideoUrl { get; set; }
        [Required(ErrorMessage = "The rating of the program is required.")]
        [Range(1, 5, ErrorMessage = "The rating must be between 1 and 5 stars.")]
        public int Rating { get; set; }
        [Column(TypeName = "nvarchar(4000)")]
        public string Description { get; set; }
    }
}
