using System.Collections.Generic;
using Snappet.Core.Repository;

namespace Snappet.Core
{
    public class StudentsRepository : IStudentsRepository
    {
        private readonly ClassContext _dbContext;

        public StudentsRepository(ClassContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Student> GetClassStudents()
        {
            return _dbContext.Students;
        }
    }
}