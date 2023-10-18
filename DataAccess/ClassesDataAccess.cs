using SchoolBeDoo.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Text.Json;
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
        public List<Classes> GetAllByClassName(string className)
        {
            SQLiteCommand comand;
            List<Classes> list = new List<Classes>();
            SQLiteDataReader datareader = null;
            String sql, output = null;
            DataTable dt = new DataTable();

            sql = $"SELECT * FROM {className}";
            comand = new SQLiteCommand(sql, Connection);
            datareader = comand.ExecuteReader();
           while (datareader.Read())
            {
                list.Add(new Classes
                {
                    ClassId = datareader.GetInt32(0),
                    CourseId = datareader.GetInt32(1),
                    StudentId = datareader.GetInt32(2),
                });
            }
            

            datareader.Close();
            comand.Dispose();
            return list;


        }
       
        public string GetClassesById(int class_id)
        {
            SQLiteCommand command;
            SQLiteDataReader dataReader;
            String sql, Output = "";

            sql = ($"SELECT * FROM Classes WHERE Classes.class_id='{class_id}'");

            command = new SQLiteCommand(sql, Connection);
            dataReader = command.ExecuteReader();
            //command.Parameters.Add(new SQLiteParameter("class_id", class_id));

            while (dataReader.Read())
            {
                Output = Output + "class_id=" + dataReader.GetValue(0) + "\n" + "student_id=" + dataReader.GetValue(1) + "\n" + "course_id=" + dataReader.GetValue(2) + "\n";
            }



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

