using System.ComponentModel.DataAnnotations;

namespace EnrollmentSystem.ViewModels
{
    public class EditDepartmentFormViewModel
    {
        public int ID { get; set; }
        [Required]
        public string Code { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
