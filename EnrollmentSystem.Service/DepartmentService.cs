using EnrollmentSystem.Data.EF.Infrastructure;
using EnrollmentSystem.Data.EF.Repositories;
using EnrollmentSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnrollmentSystem.Service
{
    public interface IDepartmentService
    {
        IEnumerable<DepartmentModel> GetDepartments();
        DepartmentModel GetDepartment(int id);
        DepartmentModel GetDepartment(string code);
        IEnumerable<DepartmentModel> GetDepartments(string keyword);
        void CreateDepartment(DepartmentModel department);
        void UpdateDepartment(DepartmentModel department);
        void SoftRemoveDepartment(DepartmentModel department);
        void RemoveDepartment(DepartmentModel department);
        void RecoverDepartment(DepartmentModel department);
        void SaveDepartment();
    }

    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository departmentRepository;
        private readonly IUnitOfWork unitOfWork;

        public DepartmentService(IDepartmentRepository departmentRepository, IUnitOfWork unitOfWork)
        {
            this.departmentRepository = departmentRepository;
            this.unitOfWork = unitOfWork;
        }

        public void CreateDepartment(DepartmentModel department)
        {
            departmentRepository.Add(department);
        }

        public DepartmentModel GetDepartment(int id)
        {
            return departmentRepository.GetById(id);
        }

        public DepartmentModel GetDepartment(string code)
        {
            return departmentRepository.GetDepartmentByCode(code);
        }

        public IEnumerable<DepartmentModel> GetDepartments()
        {
            return departmentRepository.GetAll();
        }

        public IEnumerable<DepartmentModel> GetDepartments(string keyword)
        {
            if (string.IsNullOrEmpty(keyword))
            {
                return GetDepartments();
            }
            else
            {
                return departmentRepository.GetMany(x =>
                    x.Code.Contains(keyword) ||
                    x.Title.Contains(keyword) ||
                    x.Description.Contains(keyword)
                );
            }
        }

        public void RecoverDepartment(DepartmentModel department)
        {
            department.Removed = null;
            departmentRepository.Update(department);
        }

        public void RemoveDepartment(DepartmentModel department)
        {
            departmentRepository.Delete(department);
        }

        public void SaveDepartment()
        {
            unitOfWork.Commit();
        }

        public void SoftRemoveDepartment(DepartmentModel department)
        {
            department.Removed = DateTime.UtcNow;
            departmentRepository.Update(department);
        }

        public void UpdateDepartment(DepartmentModel department)
        {
            departmentRepository.Update(department);
        }
    }
}
