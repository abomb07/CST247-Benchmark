using Bible.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Bible.Services
{
    public class VerseDataService
    {
        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Bible;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public bool createVerse(BibleVerse bv)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO dbo.Verse (Testament, Book, Chapter, Verse, Text) VALUES (@Testament, @Book, @Chapter, @Verse, @Text)";

                SqlCommand myCommand = new SqlCommand(query, connection);

                myCommand.Parameters.AddWithValue("@Testament", bv.testament);
                myCommand.Parameters.AddWithValue("@Book", bv.book);
                myCommand.Parameters.AddWithValue("@Chapter", bv.chapter);
                myCommand.Parameters.AddWithValue("@Verse", bv.verse);
                myCommand.Parameters.AddWithValue("@Text", bv.text);

                try
                {
                    connection.Open();

                    if (myCommand.ExecuteNonQuery() > 0)
                        return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                return false;
            }
        }

        public List<BibleVerse> readAll()
        {
            List<BibleVerse> verses = new List<BibleVerse>();
            string query = "SELECT * FROM dbo.Verse";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        verses.Add(new BibleVerse((string)reader[1], (string)reader[2], (int)reader[3], (int)reader[4], (string)reader[5]));
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                };
            }
            return verses;
        }

        public BibleVerse searchVerses(BibleVerse bv)
        {
            string sqlStatement = "SELECT * FROM dbo.Verse WHERE Testament LIKE @Testament AND Book LIKE @Book AND Chapter=@Chapter AND Verse=@Verse";
            //  AND Book='@Book' AND Chapter='1' AND Verse='1'
            BibleVerse bibleV = null;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);

                command.Parameters.AddWithValue("@Testament", '%' + bv.testament + '%');
                command.Parameters.AddWithValue("@Book", '%' + bv.book + '%');
                command.Parameters.AddWithValue("@Chapter", bv.chapter);
                command.Parameters.AddWithValue("@Verse", bv.verse);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        bibleV = new BibleVerse((string)reader[1], (string)reader[2], (int)reader[3], (int)reader[4], (string)reader[5]);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return bibleV;
        }
    }
}
