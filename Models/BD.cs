using System.Data.SqlClient;
using Dapper;
using System;
using System.Collections.Generic;

public class BD{
  private static string _connectionstring = @"Server = localhost; DataBase = JJOO(BD); Trusted_Connection = True;";

    public static void AgregarDeportista(Deportistas dep)
    {
        using (SqlConnection db = new SqlConnection(_connectionstring))
        {
            string query = "INSERT INTO Deportistas (Apellido, Nombre, FechaNacimiento, Foto, IdPais, IdDeporte) VALUES (@Apellido, @Nombre, @FechaNacimiento, @Foto, @IdPais, @IdDeporte)";
            db.Execute(query, dep);
        }
    }

    public static void EliminarDeportista(int idDeportista)
    {
        using (SqlConnection db = new SqlConnection(_connectionstring))
        {
            string query = "DELETE FROM Deportistas WHERE IdDeportista = @IdDeportista";
            db.Execute(query, new { IdDeportista = idDeportista });
        }
    }

    public static Deporte VerInfoDeporte(int idDeporte)
    {
        using (SqlConnection db = new SqlConnection(_connectionstring))
        {
            string query = "SELECT * FROM Deportes WHERE IdDeporte = @IdDeporte";
            return db.QueryFirstOrDefault<Deporte>(query, new { IdDeporte = idDeporte });
        }
    }

    public static Pais VerInfoPais(int idPais)
    {
        using (SqlConnection db = new SqlConnection(_connectionstring))
        {
            string query = "SELECT * FROM Paises WHERE IdPais = @IdPais";
            return db.QueryFirstOrDefault<Pais>(query, new { IdPais = idPais });
        }
    }

    public static Deportistas VerInfoDeportista(int idDeportista)
    {
        using (SqlConnection db = new SqlConnection(_connectionstring))
        {
            string query = "SELECT * FROM Deportistas WHERE IdDeportista = @IdDeportista";
            return db.QueryFirstOrDefault<Deportistas>(query, new { IdDeportista = idDeportista });
        }
    }

    public static List<Pais> ListarPaises()
    {
        using (SqlConnection db = new SqlConnection(_connectionstring))
        {
            string query = "SELECT * FROM Paises";
            return db.Query<Pais>(query).AsList();
        }
    }

    public static List<Deporte> ListarDeportes()
    {
        using (SqlConnection db = new SqlConnection(_connectionstring))
        {
            string query = "SELECT * FROM Deportes";
            return db.Query<Deporte>(query).AsList();
        }
    }

    public static List<Deportistas> ListarDeportistasPorDeporte(int idDeporte)
    {
        using (SqlConnection db = new SqlConnection(_connectionstring))
        {
            string query = "SELECT * FROM Deportistas WHERE IdDeporte = @IdDeporte";
            return db.Query<Deportistas>(query, new { IdDeporte = idDeporte }).AsList();
        }
    }

    public static List<Deportistas> ListarDeportistasPorPais(int idPais)
    {
        using (SqlConnection db = new SqlConnection(_connectionstring))
        {
            string query = "SELECT * FROM Deportistas WHERE IdPais = @IdPais";
            return db.Query<Deportistas>(query, new { IdPais = idPais }).AsList();
        }
    }
}
