using UnityEngine;
using System.Data;
using Mono.Data.Sqlite;

public class SimpleDB : MonoBehaviour
{
    private static string dbName = "URI=file:Assets/Database/marioTabarnak.db";

    void Start()
    {
        CreateDB();
    }

    public static void CreateDB()
    {
        using (var connection = new SqliteConnection(dbName))
        {
            print(connection);
            connection.Open();
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "CREATE TABLE IF NOT EXISTS leaderboard (name TEXT, temps TEXT);";
                command.ExecuteNonQuery();
            }
            connection.Close();
        }
    }

    public static void addScore(string name, string chrono)
    {
        using (var connection = new SqliteConnection(dbName))
        {
            connection.Open();
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "INSERT INTO leaderboard (name, temps) VALUES ('" + name + "','" + chrono + "');";
                command.ExecuteNonQuery();
            }
            connection.Close();
        }
    }
}