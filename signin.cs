using System;
using System.Security.Cryptography;
using Npgsql;

public class UserService
{
    private readonly string _connectionString;

    public UserService(string connectionString)
    {
        _connectionString = connectionString;
    }

    public void Register(string username, string password)
    {
        using (var connection = new NpgsqlConnection(_connectionString))
        {
            connection.Open();

            using (var command = new NpgsqlCommand("INSERT INTO Users (Username, PasswordHash) VALUES (@username, @passwordHash)", connection))
            {
                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@passwordHash", HashPassword(password));
                command.ExecuteNonQuery();
            }
        }
    }

    public bool Login(string username, string password)
    {
        using (var connection = new NpgsqlConnection(_connectionString))
        {
            connection.Open();

            using (var command = new NpgsqlCommand("SELECT PasswordHash FROM Users WHERE Username = @username", connection))
            {
                command.Parameters.AddWithValue("@username", username);
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        string storedPasswordHash = reader.GetString(0);
                        return VerifyPassword(password, storedPasswordHash);
                    }
                }
            }
        }

        return false;
    }

    private string HashPassword(string password)
    {
        using (var sha256 = SHA256.Create())
        {
            var hashedBytes = sha256.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
        }
    }

    private bool VerifyPassword(string password, string storedPasswordHash)
    {
        return HashPassword(password) == storedPasswordHash;
    }
}