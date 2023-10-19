using DataAccess.ClassesDataAccess;
using SchoolBeDoo.Model;
using System.Data.SQLite;

namespace BusinnesLayer
{
    public class StudentBusinnes
    {
        StudentDataAccess crudStudent = new StudentDataAccess();
        public string GetRequestByIdStudent(int student_iid)
        {
            if (student_iid == null)
            {
                return crudStudent.Exception();
            }
            else
            {
                var result = crudStudent.GetStudentById(student_iid);
                if (result == null)
                {
                    return crudStudent.Exception();
                }
                return result;

            }


        }
        public List<Student> GetAllRequestByStudentName()
        {
         
                var result = crudStudent.GetAllByStudentName();
                if (result == null)
                {
                    return null;
                }
                return result;

            


        }
        public string CreateRequestStudent(Student model)
        {
            if (model == null)
            {
                return crudStudent.Exception();
            }
            else
            {
                var result = crudStudent.CreateStudent(model);
                if (result == null)
                {
                    return crudStudent.Exception();
                }


                return "başarılı";

            }

        }
        public string UptadeRequestByIdStudent(Student model)
        {
            if (model == null)
            {
                return crudStudent.Exception();
            }
            else
            {
                var result = crudStudent.UpdateStudenntById(model);
                if (result == null)
                {
                    return crudStudent.Exception();

                }

            }
            return "Güncelleme işlemi başarılı!";
        }

        public string DeleteRequestByIdStudent(int student_id)
        {
            if (student_id == null)
            {
                return crudStudent.Exception();
            }
            else
            {
                var result = crudStudent.DeleteStudentById(student_id);
                if (result == null)
                {
                    return crudStudent.Exception();
                }
            }
            return "Silme işlemi başarılı";

        }
    }
}