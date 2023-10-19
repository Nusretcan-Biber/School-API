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
    public class StudentDataAccess
    {
        SQLiteConnection Connection = DBConnection.SqLiteConnection();

        public string Exception()
        {
            string exeptionText = "Boş bırakma!";
            return exeptionText;
        }
        public List<Student> GetAllByStudentName()
        {
            SQLiteCommand comand;
            List<Student> list = new List<Student>();
            SQLiteDataReader datareader = null;
            String sql, output = null;


            sql = "SELECT * FROM Students";
            comand = new SQLiteCommand(sql, Connection);
            datareader = comand.ExecuteReader();
            while (datareader.Read())
            {
                list.Add(new Student
                {
                    StudentId = datareader.GetInt32(0),
                    StudentName = datareader.GetString(1),
                    StudentSurname= datareader.GetString(2),
                });
            }


            datareader.Close();
            comand.Dispose();
            return list;


        }

        public string GetStudentById(int student_id)
        {
            SQLiteCommand command;
            SQLiteDataReader dataReader;
            String sql, Output = "";

            sql = ($"SELECT * FROM Students WHERE student_id='{student_id}'");

            command = new SQLiteCommand(sql, Connection);
            dataReader = command.ExecuteReader();


            while (dataReader.Read())
            {
                Output = Output + "student_id:" + dataReader.GetValue(0) + "\n" + "student_name:" + dataReader.GetValue(1) + "\n" + "student_surname:" + dataReader.GetValue(2) + "\n";
            }



            dataReader.Close();
            command.Dispose();
            return Output;



        }
        public Student CreateStudent(Student model)
        {
            SQLiteCommand comand;
            SQLiteDataAdapter adapter = new SQLiteDataAdapter();
            string sql;


            sql = $"INSERT INTO Students (student_id, student_name, student_surname) VALUES ({model.StudentId}," + '"' + model.StudentName + '"' + "," + '"'+ model.StudentSurname +'"' + ')';

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
        public Student UpdateStudenntById(Student model)
        {
            SQLiteCommand comand;
            SQLiteDataAdapter adapter = new SQLiteDataAdapter();
            string sql;

            sql = "UPDATE Students SET student_name=" + '"' + model.StudentName + '"' + "," + " student_surname =" + '"' + model.StudentSurname + '"' + $" WHERE student_id=  {model.StudentId}";
            comand = new SQLiteCommand(sql, Connection);
            int result = comand.ExecuteNonQuery();
            comand.Dispose();
            if (result < 0)
            {
                return null;
            }
            return model;


        }
        public string DeleteStudentById(int student_id)
        {
            SQLiteCommand command;
            SQLiteDataAdapter adapter = new SQLiteDataAdapter();
            string sql;

            sql = $"DELETE FROM Students WHERE student_id= {student_id}";

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

