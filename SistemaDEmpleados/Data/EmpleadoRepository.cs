using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using SistemaDEmpleados.Models;

namespace SistemaDEmpleados.Data
{
    public class EmpleadoRepository
    {
        public List<Empleado> GetAll()
        {
            var empleados = new List<Empleado>();
            using (var conn = DbConnection.GetConnection())
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT * FROM Empleado", conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        empleados.Add(new Empleado
                        {
                            EmpleadoID = (int)reader["EmpleadoID"],
                            Nombre = reader["Nombre"].ToString(),
                            DepartamentoID = (int)reader["DepartamentoID"],
                            CargoID = (int)reader["CargoID"],
                            FechaInicio = (DateTime)reader["FechaInicio"],
                            Salario = (decimal)reader["Salario"],
                            Estado = reader["Estado"].ToString()
                        });
                    }
                }
            }
            return empleados;
        }

        public void Add(Empleado empleado)
        {
            using (var conn = DbConnection.GetConnection())
            {
                conn.Open();
                var cmd = new SqlCommand("INSERT INTO Empleado (Nombre, DepartamentoID, CargoID, FechaInicio, Salario, Estado) VALUES (@Nombre, @DepartamentoID, @CargoID, @FechaInicio, @Salario, @Estado)", conn);
                cmd.Parameters.AddWithValue("@Nombre", empleado.Nombre);
                cmd.Parameters.AddWithValue("@DepartamentoID", empleado.DepartamentoID);
                cmd.Parameters.AddWithValue("@CargoID", empleado.CargoID);
                cmd.Parameters.AddWithValue("@FechaInicio", empleado.FechaInicio);
                cmd.Parameters.AddWithValue("@Salario", empleado.Salario);
                cmd.Parameters.AddWithValue("@Estado", empleado.Estado);
                cmd.ExecuteNonQuery();
            }
        }

        public void Update(Empleado empleado)
        {
            using (var conn = DbConnection.GetConnection())
            {
                conn.Open();
                var cmd = new SqlCommand("UPDATE Empleado SET Nombre=@Nombre, DepartamentoID=@DepartamentoID, CargoID=@CargoID, FechaInicio=@FechaInicio, Salario=@Salario, Estado=@Estado WHERE EmpleadoID=@EmpleadoID", conn);
                cmd.Parameters.AddWithValue("@EmpleadoID", empleado.EmpleadoID);
                cmd.Parameters.AddWithValue("@Nombre", empleado.Nombre);
                cmd.Parameters.AddWithValue("@DepartamentoID", empleado.DepartamentoID);
                cmd.Parameters.AddWithValue("@CargoID", empleado.CargoID);
                cmd.Parameters.AddWithValue("@FechaInicio", empleado.FechaInicio);
                cmd.Parameters.AddWithValue("@Salario", empleado.Salario);
                cmd.Parameters.AddWithValue("@Estado", empleado.Estado);
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(int empleadoID)
        {
            using (var conn = DbConnection.GetConnection())
            {
                conn.Open();
                var cmd = new SqlCommand("DELETE FROM Empleado WHERE EmpleadoID=@EmpleadoID", conn);
                cmd.Parameters.AddWithValue("@EmpleadoID", empleadoID);
                cmd.ExecuteNonQuery();
            }
        }
    }
}