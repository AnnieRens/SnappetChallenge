using System.Collections.Generic;

namespace Snappet.Core.AppService
{
    public interface IStudentsService
    {
        List<Student> GetClassStudents();
    }
}
