using Microsoft.AspNetCore.Mvc;
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
                int sets = int.Parse(reader["Sets"].ToString());
                int reps = int.Parse(reader["Reps"].ToString());
                int weight = int.Parse(reader["Weight"].ToString());

                training.Add(new Training()
                {
                    Id = id,
                    Exercise = exercise,
                    Sets = sets,
                    Reps = reps,
                    Weight = weight
                });
            }

            return training;

        }

        public void ShowTraining(Training training)
        {
            SqlCommand cmd = GetDbCommand();
            cmd.CommandText = $"SELECT Exercise FROM Training";

            cmd.ExecuteNonQuery();
        }

        public void EditTraining(Training training) 
        {
            SqlCommand cmd = GetDbCommand();

            cmd.CommandText = $"UPDATE * Training(Exercise, Sets, Reps, Weight) VALUES ('{training.Exercise}', {training.Sets}, {training.Reps}, {training.Weight})";

            cmd.ExecuteNonQuery();
            
        }

        
        public void SaveTraining(Training training)
        {
            SqlCommand cmd = GetDbCommand();

            cmd.CommandText = $"INSERT INTO Training (Exercise, Sets, Reps, Weight) VALUES ('{training.Exercise}', {training.Sets}, {training.Reps}, {training.Weight})";
            
            cmd.ExecuteNonQuery();
        }

        public void DeleteTraining(Training training)
        {
            SqlCommand cmd = GetDbCommand();

            cmd.CommandText = $"DELETE FROM Training";
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
