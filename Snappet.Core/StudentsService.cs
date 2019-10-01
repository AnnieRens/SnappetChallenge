using System.Collections.Generic;
using Snappet.Core.Repository;

namespace Snappet.Core
{
    public class StudentsService : IStudentsService
    {
        private readonly IStudentsRepository _studentsRepository;

        public StudentsService(IStudentsRepository studentsRepository)
        {
            _studentsRepository = studentsRepository;
        }

        public List<Student> GetClassStudents()
        {
            return _studentsRepository.GetClassStudents();
        }
    }
}