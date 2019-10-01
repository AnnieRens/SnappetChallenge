using System.Collections.Generic;

namespace Snappet.Core.Repository
{
    public interface IStudentsRepository
    {
        List<Student> GetClassStudents();
    }
}
