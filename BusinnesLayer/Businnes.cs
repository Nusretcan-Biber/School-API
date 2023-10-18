using DataAccess.ClassesDataAccess;
using SchoolBeDoo.Model;
using System.Data.SQLite;

namespace BusinnesLayer
{
    public class Businnes
    {
        ClassesDataAccess crudClasses = new ClassesDataAccess();
        public string GetRequestById(int class_id)
        {
            if (class_id == null) {
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
        public List<Classes> GetAllRequestByClassName(string class_Name)
        {
            if (class_Name == null)
            {
                return null;
            }
            else
            {
                var result = crudClasses.GetAllByClassName(class_Name);
                if (result == null)
                {
                    return null;
                }
                return result;

            }
           

        }
        public string CreateRequest(Classes model)
        {
            if (model == null ) 
            {
                crudClasses.Exception();
            }
            else
            {
                 var result =crudClasses.CreateClass(model);
                if (result ==null)
                {
                   return  crudClasses.Exception();
                }

            }
            return "başarılı";
    
        }
    }
}