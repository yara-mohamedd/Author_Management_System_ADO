using BusinessLogicLayer;

class Program
{
    static void Main()
    {
    
        while (true)
        {
            Console.WriteLine("\n1. View Authors");
            Console.WriteLine("2. Add Author");
            Console.WriteLine("3. Delete Author");

            int choice = int.Parse(Console.ReadLine());

            if (choice == 1)
            {
                var authors = AuthorBLL.GetAuthors(); 

                foreach (var a in authors)
                {
                    Console.WriteLine($"{a.Id} - {a.FirstName} {a.LastName}");
                }
            }

            else if (choice == 2)
            {
                Author a = new Author();

                Console.Write("ID: ");
                a.Id = Console.ReadLine();

                Console.Write("First Name: ");
                a.FirstName = Console.ReadLine();

                Console.Write("Last Name: ");
                a.LastName = Console.ReadLine();

                Console.Write("Phone: ");
                a.Phone = Console.ReadLine();

                a.Contract = true;

                AuthorBLL.AddAuthor(a); 

                Console.WriteLine("Added ");
            }

            else if (choice == 3)
            {
                Console.Write("Enter ID: ");
                string id = Console.ReadLine();

                AuthorBLL.RemoveAuthor(id); 

                Console.WriteLine("Deleted ");
            }
        }
    }
}