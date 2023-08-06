using UnityEngine;
using System.Data;
using Mono.Data.Sqlite;

public class TestDB : MonoBehaviour
{
    //*****private variables*****
    private string dbName = "URI=file:Vars.db"; //created DB is in the top level of the project folder.


    //*****public methods*****

    void Start()
    {
        CreateDB();
        AddFriendshipLevel("Tina", 4);
        AddFriendshipLevel("BlondeFriend", 10);
        AddFriendshipLevel("Friend2", 6);
        DisplayTest();

    }


    public void CreateDB()
    {
        // set up connection object
        using (var connection = new SqliteConnection(dbName))
        {
            // open connection
            connection.Open();
            // set up command object
            using (var command = connection.CreateCommand())
            {
                // write sql statement in command.CommandText
                command.CommandText = "CREATE TABLE IF NOT EXISTS friendshipLevels (name VARCHAR(50), level INT);";
                command.ExecuteNonQuery();
            }
            // close connection
            connection.Close();
        }
    }

    public void AddFriendshipLevel(string friendName, int friendshipLevel)
    {
        using (var connection = new SqliteConnection(dbName))
        {
            connection.Open();
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "INSERT INTO friendshipLevels (name, level) VALUES ('" + friendName + "', '" + friendshipLevel + "'); ";
                command.ExecuteNonQuery();
            }
            connection.Close();
        }
    }

    public void DisplayTest()
    {
        using (var connection = new SqliteConnection(dbName))
        {
            connection.Open();
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "SELECT * FROM friendshipLevels;";

                using (IDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Debug.Log("Friend Name: " + reader["name"] + ", Friendship Level: " + reader["level"]);
                    }
                    reader.Close();
                }

            }
            connection.Close();
        }
    }
}
