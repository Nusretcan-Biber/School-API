using DataAccess.ClassesDataAccess;
using SchoolBeDoo.Model;
using System.Data.SQLite;

namespace BusinnesLayer
{
    public class ClassesBusinnes
    {
        ClassesDataAccess crudClasses = new ClassesDataAccess();
        public string GetRequestById(int class_id)
        {
            if (class_id == null)
            {
                return crudClasses.Exception();
            }
            else
            {
                var result = crudClasses.GetClassesById(class_id);
                if (result == null)
                {
                    return crudClasses.Exception();
                }
                return result;

            }


        }
        public List<Classes> GetAllRequestByClassName()
        {
          
                var result = crudClasses.GetAllByClassName();
                if (result == null)
                {
                    return null;
                }
                return result;

            


        }
        public string CreateRequest(Classes model)
        {
            if (model == null)
            {
                return crudClasses.Exception();
            }
            else
            {
                var result = crudClasses.CreateClass(model);
                if (result == null)
                {
                    return crudClasses.Exception();
                }


                return "başarılı";

            }
            
        }
        public string UptadeRequestByIdClasses(Classes model)
        {
            if (model == null)
            {
                return crudClasses.Exception();
            }
            else
            {
                var result = crudClasses.UpdateClassesById(model);
                if (result == null)
                {
                    return crudClasses.Exception();

                }

            }
            return "Güncelleme işlemi başarılı!";
        }

        public string DeleteRequestByIdClasses(int class_id) {
            if (class_id == null)
            {
                return crudClasses.Exception();
            }
            else
            {
                var result = crudClasses.DeleteClassesById(class_id);
                if (result == null)
                {
                    return crudClasses.Exception();
                }
            }
            return "Silme işlemi başarılı";
        
        }
    }
}