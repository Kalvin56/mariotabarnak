using UnityEngine;
using System.Collections.Generic;
using System.Data;
using Mono.Data.Sqlite;

public class SimpleDB : MonoBehaviour
{
    private static string dbName = "URI=file:Assets/Database/marioTabarnak.db";

    public struct LeaderboardEntry
    {
        public string name;
        public string temps;
    }

    // Liste pour stocker toutes les entrées du leaderboard
    private static List<LeaderboardEntry> leaderboardEntries = new List<LeaderboardEntry>();

    void Start()
    {
        CreateDB();
    }

    public static void CreateDB()
    {
        using (var connection = new SqliteConnection(dbName))
        {
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

    public static List<LeaderboardEntry> getScores()
    {
        using (var connection = new SqliteConnection(dbName))
        {
            connection.Open();

            using (var command = connection.CreateCommand())
            {
                // Sélectionnez toutes les colonnes de la table leaderboard
                command.CommandText = "SELECT * FROM leaderboard;";

                using (IDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // Créez une nouvelle entrée de leaderboard à partir des données de la table
                        LeaderboardEntry entry = new LeaderboardEntry
                        {
                            name = reader.GetString(0),
                            temps = reader.GetString(1)
                        };

                        // Ajoutez l'entrée à la liste
                        leaderboardEntries.Add(entry);
                    }
                }
            }

            connection.Close();
        }
        return leaderboardEntries;
    }
}