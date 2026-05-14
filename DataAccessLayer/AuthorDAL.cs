using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DataAccessLayer
{
    public static class AuthorDAL
    {
        public static DataTable GetAllAuthors()
        {
            using SqlConnection con = new SqlConnection(DBHelper.conStr);

            string query = "SELECT * FROM authors";
            SqlDataAdapter da = new SqlDataAdapter(query, con);

            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;
        }

        public static int InsertAuthor(string id, string lname, string fname,
    string phone, string address, string city,
    string state, string zip, bool contract)
        {
            using SqlConnection con = new SqlConnection(DBHelper.conStr);

            string query = @"INSERT INTO authors 
        VALUES (@id,@lname,@fname,@phone,@address,@city,@state,@zip,@contract)";

            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@lname", lname);
            cmd.Parameters.AddWithValue("@fname", fname);
            cmd.Parameters.AddWithValue("@phone", phone);
            cmd.Parameters.AddWithValue("@address", (object?)address ?? DBNull.Value); 
            cmd.Parameters.AddWithValue("@city", (object?)city ?? DBNull.Value); 
            cmd.Parameters.AddWithValue("@state", (object?)state ?? DBNull.Value); 
            cmd.Parameters.AddWithValue("@zip", (object?)zip ?? DBNull.Value); 
            cmd.Parameters.AddWithValue("@contract", contract);

            con.Open();
            return cmd.ExecuteNonQuery();
        }

        public static int DeleteAuthor(string id)
        {
            using SqlConnection con = new SqlConnection(DBHelper.conStr);
            con.Open();


            string deleteTitleAuthor = "DELETE FROM titleauthor WHERE au_id = @id";
            SqlCommand cmd1 = new SqlCommand(deleteTitleAuthor, con);
            cmd1.Parameters.AddWithValue("@id", id);
            cmd1.ExecuteNonQuery();

          
            string deleteAuthor = "DELETE FROM authors WHERE au_id = @id";
            SqlCommand cmd2 = new SqlCommand(deleteAuthor, con);
            cmd2.Parameters.AddWithValue("@id", id);
            return cmd2.ExecuteNonQuery();
        }
    }
}
