using EnrollmentSystem.Data.EF.Infrastructure;
using EnrollmentSystem.Data.EF.Repositories;
using EnrollmentSystem.Model;
using System;
using System.Collections.Generic;
using System.Net;

namespace EnrollmentSystem.Service
{
    public interface ISubjectService
    {
        IEnumerable<SubjectModel> GetSubjects();
        SubjectModel GetSubject(int id);
        SubjectModel GetSubject(string code);
        IEnumerable<SubjectModel> GetSubjects(string keyword);
        void CreateSubject(SubjectModel subject);
        void UpdateSubject(SubjectModel subject);
        void RemoveSubject(SubjectModel subject);
        void RecoverSubject(SubjectModel subject);
        void SaveSubject();
    }

    public class SubjectService : ISubjectService
    {
        private readonly ISubjectRepository subjectRepository;
        private readonly IUnitOfWork unitOfWork;

        public SubjectService(ISubjectRepository subjectRepository, IUnitOfWork unitOfWork)
        {
            this.subjectRepository = subjectRepository;
            this.unitOfWork = unitOfWork;
        }

        public void CreateSubject(SubjectModel subject)
        {
            subjectRepository.Add(subject);
        }

        public SubjectModel GetSubject(int id)
        {
            return subjectRepository.GetById(id);
        }

        public SubjectModel GetSubject(string code)
        {
            return subjectRepository.GetSubjectByCode(code);
        }

        public IEnumerable<SubjectModel> GetSubjects()
        {
            return subjectRepository.GetAll();
        }

        public IEnumerable<SubjectModel> GetSubjects(string keyword)
        {
            if (string.IsNullOrEmpty(keyword))
            {
                return GetSubjects();
            }
            else
            {
                return subjectRepository.GetMany(x =>
                    x.Code.Contains(keyword) ||
                    x.Title.Contains(keyword) ||
                    x.Description.Contains(keyword)
                );
            }
        }

        public void RecoverSubject(SubjectModel subject)
        {
            throw new NotImplementedException();
        }

        public void RemoveSubject(SubjectModel subject)
        {
            throw new NotImplementedException();
        }

        public void SaveSubject()
        {
            unitOfWork.Commit();
        }

        public void UpdateSubject(SubjectModel subject)
        {
            subjectRepository.Update(subject);
        }
    }
}
