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
    public class CoursesDataAccess
    {
        SQLiteConnection Connection = DBConnection.SqLiteConnection();

        public string Exception()
        {
            string exeptionText = "Boş bırakma!";
            return exeptionText;
        }
        public List<Courses> GetAllByCourseName()
        {
            SQLiteCommand comand;
            List<Courses> list = new List<Courses>();
            SQLiteDataReader datareader = null;
            String sql, output = null;


            sql = $"SELECT * FROM Courses";
            comand = new SQLiteCommand(sql, Connection);
            datareader = comand.ExecuteReader();
            while (datareader.Read())
            {
                list.Add(new Courses
                {
                    CourseId = datareader.GetInt32(0),
                    CourseName = datareader.GetString(1),
                    Teacher = datareader.GetString(2),
                });
            }


            datareader.Close();
            comand.Dispose();
            return list;


        }

        public string GetCoursesById(int course_id)
        {
            SQLiteCommand command;
            SQLiteDataReader dataReader;
            String sql, Output = "";

            sql = ($"SELECT * FROM Courses WHERE course_id='{course_id}'");

            command = new SQLiteCommand(sql, Connection);
            dataReader = command.ExecuteReader();


            while (dataReader.Read())
            {
                Output = Output + "course_id:" + dataReader.GetValue(0) + "\n" + "course_name:" + dataReader.GetValue(1) + "\n" + "teacher:" + dataReader.GetValue(2) + "\n";
            }



            dataReader.Close();
            command.Dispose();
            return Output;



        }
        public Courses CreateCourse(Courses model)
        {
            SQLiteCommand comand;
            SQLiteDataAdapter adapter = new SQLiteDataAdapter();
            string sql;


            sql = $"INSERT INTO Courses (course_id, course_name, teacher) VALUES ({model.CourseId}," + '"' + model.CourseName + '"' + "," + '"' + model.Teacher + '"' + ')';
            //$"INSERT INTO Courses (course_id, course_name, teacher) VALUES ({model.CourseId}," + '"' + model.CourseName + '"' + "," + '"' + model.Teacher + '"';
            // $"INSERT INTO Courses (course_id, course_name, teacher) VALUES ({model.CourseId}, {model.CourseName}, {model.Teacher})";

            comand = new SQLiteCommand(sql, Connection);
            int result = comand.ExecuteNonQuery();
            // başarısız olursa -1 dönecek --- başarılı olursa +1 dönecek

            comand.Dispose();
            if (result < 0)
            {
                return null;
            }
            return model;



        }
        public Courses UpdateCoursesById(Courses model)
        {
            SQLiteCommand comand;
            SQLiteDataAdapter adapter = new SQLiteDataAdapter();
            string sql;

            sql = $"UPDATE Courses SET course_name =" + '"' + model.CourseName + '"' + ", teacher =" + '"' + model.Teacher + '"' + " WHERE course_id= " + '"' +model.CourseId + '"';
            comand = new SQLiteCommand(sql, Connection);
            int result = comand.ExecuteNonQuery();
            comand.Dispose();
            if (result < 0)
            {
                return null;
            }
            return model;


        }
        public string DeleteCoursesById(int course_id)
        {
            SQLiteCommand command;
            SQLiteDataAdapter adapter = new SQLiteDataAdapter();
            string sql;

            sql = $"DELETE FROM Courses WHERE course_id= {course_id}";

            command = new SQLiteCommand(sql, Connection);
            int result = command.ExecuteNonQuery();
            command.Dispose();
            if (result < 0)
            {
                return null;

            }
            return "Silme işlemi başarılı!";


        }
    }
}

