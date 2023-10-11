using System.Data.Entity;
using System.Data.SqlClient;
using System.Data.SQLite;

namespace DataAccess
{
    public class DBConnection

    {
        public static SQLiteConnection SqLiteConnection()
        {
            /*
            SQLiteConnection sqlite_conn;
            sqlite_conn = CreateConnection;
        }
        public static SQLiteConnection CreateConnection()
        {
            SQLiteConnection sqlite_conn;
            sqlite_conn = new SQLiteConnection("Data Source= database.db; Version = 3; New = True; Compress = True;" );
        
            */

            SQLiteConnection sqlite_cnn;
            string connectionString;

            connectionString = @"Data Source=C:\Program Files\DB Browser for SQLite\SchoolBeDoo.db;Version=3;";
            sqlite_cnn = new SQLiteConnection(connectionString);

            sqlite_cnn.Open();
            Console.WriteLine("Connection openned !");

            /*
                        SqlCommand command;
                        SqlDataReader dataReader;
                        String sql,Output;

                        sql = "Select student_id, student_name, student_surname From SchoolBeDoo";
                        command= new SqlCommand(sql);
                        dataReader = command.ExecuteReader();

                        while (dataReader.Read())
                        {
                            Output = Output + dataReader.GetValue(0) + "-" + dataReader.GetValue(1) + "\n";
                        }
                        Console.WriteLine(Output);


                        dataReader.Close();
                        command.Dispose();




            */

            //sqlite_cnn.Close();


            return sqlite_cnn;





        }
    }
}