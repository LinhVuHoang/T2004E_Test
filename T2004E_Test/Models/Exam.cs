using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace T2004E_Test.Models
{
    public class Exam
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập Giờ thi")]
        public string StartTime { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập Ngày thi")]
        public string ExamDate { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập Thời gian thi")]
        public int ExamDuration { get; set; }
        public virtual ICollection<ClassRoom> ClassRoom { get; set; }
        public virtual ICollection<Faculty> Facultie { get; set; }
        public virtual ICollection<Subject> Subject { get; set; }
    }
}