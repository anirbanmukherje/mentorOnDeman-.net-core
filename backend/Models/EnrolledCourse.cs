using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MentorOnDemand.Models
{
    public class EnrolledCourse
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        public string MentorEmail { get; set; }

        [Required]
        [MaxLength(50)]
        public string Description { get; set; }

        [Required]
        [MaxLength(50)]
        public string Duration { get; set; }

        [Required]
        [MaxLength(50)]
        public string CourseFee { get; set; }

        [Required]
        [MaxLength(50)]
        public string StudentEmail { get; set; }



    }
}
