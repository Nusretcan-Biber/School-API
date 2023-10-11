using SchoolBeDoo.Model;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.ClassesDataAccess
{
    public class ClassesDataAccess
    {
        SQLiteConnection Connection = DBConnection.SqLiteConnection();

        public string Exception()
        {
            string exeptionText = "Boş bırakma skerim";
            return exeptionText;
        }
        public string GetClasses(int class_id)
        {
            SQLiteCommand command;
            SQLiteDataReader dataReader;
            String sql, Output = "";

             sql = ($"SELECT * FROM Classes WHERE Classes.class_id='{class_id}'");
           
            command = new SQLiteCommand(sql, Connection);
            dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                Output = Output + dataReader.GetValue(0) + "-" + dataReader.GetValue(1) + "-" + dataReader.GetValue(2) + "\n";
            }
            Console.WriteLine(Output);


            dataReader.Close();
            command.Dispose();
            return Output;

        }
        public Classes CreateClass(Classes model)
        {
            SQLiteCommand comand;
            SQLiteDataAdapter adapter = new SQLiteDataAdapter();
            string sql;
            /*
                        switch (tableName)
                        {
                            case "students":

                                column1 = "student_id";
                                column2 = "student_name";
                                column3 = "student_surname";
                                break;

                            case "courses":

                                column1 = "course_id";
                                column2 = "course_name";
                                column3 = "teacher";
                                break;

                            case "classes":

                                column1 = "class_id";
                                column2 = "student_id";
                                column3 = "course_id";
                                break;
                        }

            */


            sql = $"INSERT INTO Classes (class_id, student_id,course_id) VALUES ({model.ClassId}, {model.StudentId}, {model.CourseId})";

            comand = new SQLiteCommand(sql, Connection);

            //       adapter.InsertCommand = new SQLiteCommand(sql);
            //       var result = adapter.InsertCommand.ExecuteNonQuery();
            int result = comand.ExecuteNonQuery();

            comand.Dispose();
            if (result < 0)
            {
                return null;
            }
            return model;



        }
        public void UpdateClass()
        {
            SQLiteCommand comand;
            SQLiteDataAdapter adapter = new SQLiteDataAdapter();
            String sql = "";

            sql = "";
            comand = new SQLiteCommand(sql, Connection);

            adapter.UpdateCommand = new SQLiteCommand(sql);
            adapter.UpdateCommand.ExecuteNonQuery();
            comand.Dispose();
        }
        public void DeleteClass()
        {
            SQLiteCommand comand;
            SQLiteDataAdapter adapter = new SQLiteDataAdapter();
            String sql = "";
            sql = "";

            comand = new SQLiteCommand(sql, Connection);

            adapter.DeleteCommand = new SQLiteCommand(sql, Connection);
            adapter.DeleteCommand.ExecuteNonQuery();
            comand.Dispose();



        }
    }
}

