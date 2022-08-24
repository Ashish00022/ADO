using System.Data.SqlClient;
class simple
{
    public static void Main(string[] args)
    {
        Console.WriteLine("--------Student Managaement system--------");
        int choice = 0;
        Console.WriteLine("1. Insert New student details");
        Console.WriteLine("2. Update student details");
        Console.WriteLine("3. Delete student details");
        Console.WriteLine("4. Display student details");
        Console.WriteLine("5. Exit");
        Console.WriteLine("Enter a choice");
        choice = Convert.ToInt32(Console.ReadLine());
        if (choice == 1)
        {
            SqlConnection conn = new SqlConnection("server = NSL-LTRG004\\SQLEXPRESS2019;initial catalog = home; integrated security=True");
            conn.Open();
            int id, age;
            string Name, address;
            Console.WriteLine("Enter a id");
            id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter a Name");
            Name = Console.ReadLine();
            Console.WriteLine("Enter a Age");
            age = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter a address");
            address = Console.ReadLine();
            string query = "insert into Student values(@id,@name,@age,@address)";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@id", id); //inbuilt function of sqlcommand
            cmd.Parameters.AddWithValue("@name", Name);
            cmd.Parameters.AddWithValue("@age", age);
            cmd.Parameters.AddWithValue("@address", address);
            int status = cmd.ExecuteNonQuery();
            if (status > 0)
            {
                Console.WriteLine("record is inserted");
            }
            else
            {
                Console.WriteLine("null");
            }
            conn.Close();
        }
        else if(choice == 2)
        {
            SqlConnection conn = new SqlConnection("server = NSL-LTRG004\\SQLEXPRESS2019;initial catalog = home; integrated security=True");
            conn.Open();
            int id, Age;
            string name, Address;
            Console.WriteLine("Enter a id of record to be updated");
            id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter a Name to be updated");
            name = Console.ReadLine();
            Console.WriteLine("Enter a Age to be updated");
            Age = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter a address to be updated");
            Address = Console.ReadLine();
            string query = "update Student set Name =@name,age =@Age,address =@Address where Id =@id";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@id", id); //inbuilt function of sqlcommand
            cmd.Parameters.AddWithValue("@Name", name);
            cmd.Parameters.AddWithValue("@age", Age);
            cmd.Parameters.AddWithValue("@address", Address);
            int status = cmd.ExecuteNonQuery();
            if (status > 0)
            {
                Console.WriteLine("record is updated");
            }
            else
            {
                Console.WriteLine("null");
            }
            conn.Close();
        }
        else if (choice == 3)
        {
            SqlConnection conn = new SqlConnection("server = NSL-LTRG004\\SQLEXPRESS2019;initial catalog = home; integrated security=True");
            conn.Open();
            int id;
            Console.WriteLine("Enter a id of record to be Deleted");
            id = Convert.ToInt32(Console.ReadLine());
            string query = "delete from Student where Id =@id";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@id", id); //inbuilt function of sqlcommand
            int status = cmd.ExecuteNonQuery();
            if (status > 0)
            {
                Console.WriteLine("record is deleted");
            }
            else
            {
                Console.WriteLine("record is not found");
            }
            conn.Close();
        }
        else if (choice == 4)
        {
            SqlConnection conn = new SqlConnection("server = NSL-LTRG004\\SQLEXPRESS2019;initial catalog = home; integrated security=True");
            conn.Open();
            string qyery = "Select * from Student"; //sql query
            SqlCommand cmd = new SqlCommand(qyery, conn); //pass in sqlcommand object
            SqlDataReader read = cmd.ExecuteReader(); //execute a command and stored in sqldatareader object
            if (read.HasRows == true)
            {
                while (read.Read())
                {
                    //Console.WriteLine(read[0].ToString());.tostring to display intothe console
                    Console.WriteLine(read[0].ToString() + " " + read[1].ToString() + " " + read[2].ToString() + " " + read[3].ToString()); //to display a record on console
                }
            }
            else
            {
                Console.WriteLine("No record has found");
            }
            conn.Close();
        }
        else if(choice == 5)
        {
            SqlConnection conn = new SqlConnection("server = NSL-LTRG004\\SQLEXPRESS2019;initial catalog = home; integrated security=True");
            conn.Open();
            conn.Close();
        }
        else
        {
            Console.WriteLine("Invalied choice");
        }
    }
}