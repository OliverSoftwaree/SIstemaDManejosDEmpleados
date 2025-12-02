using System.Collections.Generic;
using System.Data.SqlClient;
using SistemaDEmpleados.Models;

namespace SistemaDEmpleados.Data
{
    public class CargoRepository
    {
        public List<Cargo> GetAll()
        {
            var list = new List<Cargo>();
            using (var conn = DbConnection.GetConnection())
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT * FROM Cargo", conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Cargo
                        {
                            CargoID = (int)reader["CargoID"],
                            Nombre = reader["Nombre"].ToString()
                        });
                    }
                }
            }
            return list;
        }

        public void Add(Cargo cargo)
        {
            using (var conn = DbConnection.GetConnection())
            {
                conn.Open();
                var cmd = new SqlCommand("INSERT INTO Cargo (Nombre) VALUES (@Nombre)", conn);
                cmd.Parameters.AddWithValue("@Nombre", cargo.Nombre);
                cmd.ExecuteNonQuery();
            }
        }

        public void Update(Cargo cargo)
        {
            using (var conn = DbConnection.GetConnection())
            {
                conn.Open();
                var cmd = new SqlCommand("UPDATE Cargo SET Nombre=@Nombre WHERE CargoID=@CargoID", conn);
                cmd.Parameters.AddWithValue("@Nombre", cargo.Nombre);
                cmd.Parameters.AddWithValue("@CargoID", cargo.CargoID);
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(int cargoID)
        {
            using (var conn = DbConnection.GetConnection())
            {
                conn.Open();
                var cmd = new SqlCommand("DELETE FROM Cargo WHERE CargoID=@CargoID", conn);
                cmd.Parameters.AddWithValue("@CargoID", cargoID);
                cmd.ExecuteNonQuery();
            }
        }
    }
}