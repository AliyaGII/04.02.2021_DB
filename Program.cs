using System;
using System.Data.SqlClient;

namespace _04._02._2021
{
    class Program
    {
        static void Main(string[] args)
        {


            string conString = @"Data Source=ALIYA\SQLEXPRESS; Initial Catalog=AlifAcademy;Integrated Security=True";
            SqlConnection connection = new SqlConnection(conString);

            try
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "use AlifAcademy";

                if (connection.State == System.Data.ConnectionState.Open)
                {
                    Console.WriteLine("Successfully connected to AlifAcademy");
                }

                Console.WriteLine("Chooose action :");
                Console.WriteLine("1. Insert (Add)");
                Console.WriteLine("2. Select All (Select all)");
                Console.WriteLine("3. Select by Id (Chose by Id)");
                Console.WriteLine("4. Update (Update every column expect Id)");
                Console.WriteLine("5. Delete (Delete by Id)");
                Console.WriteLine("6. Exit");

                var action = Console.ReadLine();

                switch (action)
                {
                    case "1":
                        Console.WriteLine("You have chosen Insert.");
                        Console.Write("Enter the Second Name of the person you want to add: ");
                        var lastName = Console.ReadLine();
                        Console.Write("Enter the First Name of the person you want to add: ");
                        var firstName = Console.ReadLine();
                        Console.Write("Enter the Middle Name of the person you want to add: ");
                        var middleName = Console.ReadLine();
                        Console.Write("Enter the Data of Birth of the person you want to add: ");
                        var birthDate = Console.ReadLine();

                        command.CommandText = "insert into Person(" +
                            "LastName," +
                            "FirstName," +
                            "MiddleName," +
                            "BirthDate) " +
                            "Values(" +
                            $"'{lastName}'," +
                            $"'{firstName}'," +
                            $"'{middleName}'," +
                            $"'{birthDate}')";

                        var result = command.ExecuteNonQuery();

                        if (result > 0)
                        {
                            Console.WriteLine("You successefully have chosen the person");
                        }
                        Console.WriteLine();
                        break;

                    case "2":
                        Console.WriteLine("You chosed 'Select All'.");

                        command.CommandText = "select * from Person ";
                        var Reader1 = command.ExecuteReader();
                        while (Reader1.Read())
                        {
                            Console.WriteLine("ID = " + Reader1["id"]);
                            Console.WriteLine("FirstName: " + Reader1["LastName"]);
                            Console.WriteLine("LastName: " + Reader1["FirstName"]);
                            Console.WriteLine("MiddleName: " + Reader1["MiddleName"]);
                            Console.WriteLine("MiddleName: " + Reader1["BirthDate"]);
                            Console.WriteLine();
                        }


                        break;
                    case "3":
                        Console.WriteLine("You choosed  'Select by Id'.");
                        Console.Write("Enter ID of the person you want: ");
                        var id = int.Parse(Console.ReadLine());
                        command.CommandText = $"select * from Person where Id={id}";
                        SqlDataReader Reader2 = command.ExecuteReader();
                        while (Reader2.Read())
                        {
                            Console.WriteLine($"" +
                                $"Id: {Reader2["Id"]}, " +
                                $"LastName: {Reader2["LastName"]}, " +
                                $"FirstName: {Reader2["FirstName"]}, " +
                                $"MiddleName: {Reader2["MiddleName"]}, " +
                                $"BirthDate {Reader2["BirthDate"]}");
                        }
                        Reader2.Close();
                        break;
                    case "4":
                        Console.WriteLine("You choosed 'Update'.");
                        Console.Write("Enter ID of whom you want to update the data: ");
                        id = int.Parse(Console.ReadLine());
                        Console.Write("Enter Last Name of whom you want to update the data: ");
                        var last_Name = Console.ReadLine();
                        Console.Write("Enter First Name of whom you want to update the data: ");
                        var first_Name = Console.ReadLine();
                        Console.Write("Enter Middle Name of whom you want to update the data: ");
                        var middle_Name = Console.ReadLine();
                        Console.Write("Enter Date of Birth of whom you want to update the data: ");
                        var birth_Date = Console.ReadLine();

                        command.CommandText =
                            $"update Person set " +
                            $"LastName='{last_Name}', " +
                            $"FirstName='{first_Name}', " +
                            $"MiddleName='{middle_Name}', " +
                            $"BirthDate='{birth_Date}' " +
                            $"where Id={id}";
                        var result2 = command.ExecuteNonQuery();

                        if (result2 > 0)
                        {
                            Console.WriteLine("Data updateded successfully");
                        }
                        Console.WriteLine();

                        break;
                    case "5":
                        Console.WriteLine("You have chosen an action 'Delete'");
                        Console.Write("Enter 'Id' whom you want to remove: ");
                        id = int.Parse(Console.ReadLine());
                        command.CommandText = $"delete from Person where Id={id}";

                        var result3 = command.ExecuteNonQuery();

                        if (result3 > 0)
                        {
                            Console.WriteLine("Data updatede successfully!");
                        }
                        Console.WriteLine();

                        break;
                    case "6":
                        Console.WriteLine("Bye, bye");
                        return;
                    default:
                        Console.WriteLine("Wrong input");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            finally
            {
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }

                if (connection.State == System.Data.ConnectionState.Closed)
                {
                    Console.WriteLine("Disconnected to AlifAcademy");
                }

            }
            Console.ReadKey();
        }
    }
}
