using Microsoft.AspNetCore.Mvc.Formatters;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace TrainingMVC.Models
{
    public class Database
    {
        public List<Training> GetTraining()
        {
            SqlCommand cmd = GetDbCommand();

            cmd.CommandText = "SELECT * FROM Training";

            var reader = cmd.ExecuteReader();

            var training = new List<Training>();



            while (reader.Read())
            {
                int id = int.Parse(reader["Id"].ToString());
                string exercise = reader["Exercise"].ToString();
                int set = int.Parse(reader["Set"].ToString());
                int reps = int.Parse(reader["Reps"].ToString());
                int weight = int.Parse(reader["Weight"].ToString());

                training.Add(new Training()
                {
                    Id = id,
                    Exercise = exercise,
                    Set = set,
                    Reps = reps,
                    Weight = weight
                });
            }

            return training;

        }
        public void SaveTraining(string exercise, int set, int reps, int weight)
        {
            SqlCommand cmd = GetDbCommand();

            cmd.CommandText = $"INSERT INTO Training (Exercise, Set, Reps, Weight) VALUES ('{exercise}', {set}, {reps}, {weight})";
            
            cmd.ExecuteNonQuery();
        }

        private static SqlCommand GetDbCommand()
        {
            string connectionString = "Data Source=localhost;Initial Catalog=TrainingDB;Integrated Security=True";

            SqlConnection conn = new SqlConnection(connectionString);

            conn.Open();

            SqlCommand cmd = conn.CreateCommand();

            cmd.CommandType = CommandType.Text;
            return cmd;
        }
    }
}
