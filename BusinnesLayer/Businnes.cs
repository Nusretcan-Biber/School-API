using DataAccess.ClassesDataAccess;
using SchoolBeDoo.Model;

namespace BusinnesLayer
{
    public class Businnes
    {
        ClassesDataAccess crudClasses = new ClassesDataAccess();
        public string GetRequest(int class_id)
        {
            if (class_id == null) {
                return crudClasses.Exception();
            }
            else
            {
                var result = crudClasses.GetClasses(class_id);
                if (result == null)
                {
                    return crudClasses.Exception();
                }
                return "başarılı";
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