using System.ComponentModel.DataAnnotations;

namespace EnrollmentSystem.Web.MVC.ViewModels
{
    public class EditSubjectViewModel
    {
        public int ID { get; set; }
        [Required]
        public string Code { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        [Required]
        public int Unit { get; set; }
    }
}