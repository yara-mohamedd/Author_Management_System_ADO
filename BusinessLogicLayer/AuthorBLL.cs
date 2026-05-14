using BusinessLogicLayer;
using DataAccessLayer;
using System.Data;

public static class AuthorBLL
{

    public static Author ConvertDataRowToAuthor(DataRow row)
    {
        return new Author
        {
            Id = row["au_id"].ToString(),
            FirstName = row["au_fname"].ToString(),
            LastName = row["au_lname"].ToString(),
            Phone = row["phone"].ToString(),
            Address = row["address"].ToString(),
            City = row["city"].ToString(),
            State = row["state"].ToString(),
            Zip = row["zip"].ToString(),
            Contract = Convert.ToBoolean(row["contract"])
        };
    }

    public static List<Author> ConvertDataTableToList(DataTable dt)
    {
        List<Author> list = new List<Author>();
        foreach (DataRow row in dt.Rows)
            list.Add(ConvertDataRowToAuthor(row));
        return list;
    }

    public static List<Author> GetAuthors()
    {
        DataTable dt = AuthorDAL.GetAllAuthors(); 
        return ConvertDataTableToList(dt);
    }

    public static void AddAuthor(Author a)
    {
        if (string.IsNullOrWhiteSpace(a.Id))
            throw new Exception("ID required");

        AuthorDAL.InsertAuthor(a.Id, a.LastName, a.FirstName,
            a.Phone, a.Address, a.City, a.State, a.Zip, a.Contract);
    }

    public static void RemoveAuthor(string id)
    {
        AuthorDAL.DeleteAuthor(id); 
    }
}