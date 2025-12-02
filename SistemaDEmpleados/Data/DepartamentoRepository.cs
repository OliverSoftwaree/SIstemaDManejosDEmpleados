using System.Collections.Generic;
using System.Data.SqlClient;
using SistemaDEmpleados.Models;

namespace SistemaDEmpleados.Data
{
    public class DepartamentoRepository
    {
        public List<Departamento> GetAll()
        {
            var list = new List<Departamento>();
            using (var conn = DbConnection.GetConnection())
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT * FROM Departamento", conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Departamento
                        {
                            DepartamentoID = (int)reader["DepartamentoID"],
                            Nombre = reader["Nombre"].ToString()
                        });
                    }
                }
            }
            return list;
        }

        public void Add(Departamento departamento)
        {
            using (var conn = DbConnection.GetConnection())
            {
                conn.Open();
                var cmd = new SqlCommand("INSERT INTO Departamento (Nombre) VALUES (@Nombre)", conn);
                cmd.Parameters.AddWithValue("@Nombre", departamento.Nombre);
                cmd.ExecuteNonQuery();
            }
        }

        public void Update(Departamento departamento)
        {
            using (var conn = DbConnection.GetConnection())
            {
                conn.Open();
                var cmd = new SqlCommand("UPDATE Departamento SET Nombre=@Nombre WHERE DepartamentoID=@DepartamentoID", conn);
                cmd.Parameters.AddWithValue("@Nombre", departamento.Nombre);
                cmd.Parameters.AddWithValue("@DepartamentoID", departamento.DepartamentoID);
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(int departamentoID)
        {
            using (var conn = DbConnection.GetConnection())
            {
                conn.Open();
                var cmd = new SqlCommand("DELETE FROM Departamento WHERE DepartamentoID=@DepartamentoID", conn);
                cmd.Parameters.AddWithValue("@DepartamentoID", departamentoID);
                cmd.ExecuteNonQuery();
            }
        }
    }
}