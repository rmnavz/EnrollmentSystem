using EnrollmentSystem.Model;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EnrollmentSystem.ViewModels
{
    public class EditSubjectFormViewModel
    {
        public EditSubjectFormViewModel()
        {
            this.AllSubjects = new List<SubjectModel>();
            this.PrerequisiteIDs = new List<int>();
        }

        public int ID { get; set; }
        [Required]
        public string Code { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        [Required]
        public int Unit { get; set; }
        public bool Lecture { get; set; }
        public bool Laboratory { get; set; }

        public ICollection<SubjectModel> AllSubjects { get; set; }
        public ICollection<int> PrerequisiteIDs { get; set; }
    }
}