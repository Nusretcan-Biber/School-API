using DataAccess.ClassesDataAccess;
using SchoolBeDoo.Model;
using System.Data.SQLite;

namespace BusinnesLayer
{
    public class CoursesBusinnes
    {
        CoursesDataAccess crudCourses = new CoursesDataAccess();
        public string GetRequestByIdCourses(int course_id)
        {
            if (course_id == null)
            {
                return crudCourses.Exception();
            }
            else
            {
                var result = crudCourses.GetCoursesById(course_id);
                if (result == null)
                {
                    return crudCourses.Exception();
                }
                return result;

            }


        }
        public List<Courses> GetAllRequestByCourseName()
        {

            var result = crudCourses.GetAllByCourseName();
            if (result == null)
            {
                return null;
            }
            return result;


        }
        public string CreateRequestCourses(Courses model)
        {
            if (model == null)
            {
                return crudCourses.Exception();
            }
            else
            {
                var result = crudCourses.CreateCourse(model);
                if (result == null)
                {
                    return crudCourses.Exception();
                }


                return "başarılı";

            }

        }
        public string UptadeRequestByIdCourses(Courses model)
        {
            if (model == null)
            {
                return crudCourses.Exception();
            }
            else
            {
                var result = crudCourses.UpdateCoursesById(model);
                if (result == null)
                {
                    return crudCourses.Exception();

                }

            }
            return "Güncelleme işlemi başarılı!";
        }

        public string DeleteRequestByIdCourses(int course_id)
        {
            if (course_id == null)
            {
                return crudCourses.Exception();
            }
            else
            {
                var result = crudCourses.DeleteCoursesById(course_id);
                if (result == null)
                {
                    return crudCourses.Exception();
                }
            }
            return "Silme işlemi başarılı";

        }
    }
}