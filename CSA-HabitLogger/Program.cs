// See https://aka.ms/new-console-template for more information

using Microsoft.Data.Sqlite;
namespace HabitLogger
{
    class Program

    {
        static string connectionString = @"DataSource = habit-Logger.db";

        static void Main()
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                var tableCmd = connection.CreateCommand();

                tableCmd.CommandText =
                    @"CREATE TABLE IF NOT EXISTS reading_books(
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Date TEXT,
                    Pages INTEGER
                    )";


                tableCmd.ExecuteNonQuery();

                connection.Close();




            }

            GetUserInput();


        }






        static void GetUserInput()

        {
            Console.Clear();

            bool closeApp = false;

            while (closeApp == false)
            {
                Console.WriteLine("\n\nMENU");
                Console.WriteLine("\nChoose one option from below:");
                Console.WriteLine("\nType 0 to close app");
                Console.WriteLine("Type 1 to insert record");
                Console.WriteLine("Type 2 to delete record");
                Console.WriteLine("Type 3 to update record");
                Console.WriteLine("Type 4 to view all records");
                Console.WriteLine("-----------------------------");

                string command = Console.ReadLine();

                switch (command)
                {
                    case "0":
                        Console.WriteLine("Bye, bye...!");
                        closeApp = true;
                        break;

                    case "1":
                        Insert();
                        break;

                    case "2":
                        //Delete();
                        break;

                    case "3":
                        //Update();
                        break;
                    case "4":
                        //ViewAll();
                        break;

                    default:
                        Console.WriteLine("\n Invalid command. Please type a number from 0 to 4. \n");
                        break;




                }


            }



        }

        static void Insert()
        {
            string date = GetDateInput();
            int quantity = GetNumberInput("\n\n Please input number of book pages (no decimal allowed):");


            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                var tableCmd = connection.CreateCommand();

                tableCmd.CommandText =
                    $"INSERT INTO reading_books(Date, Pages) VALUES('{date}', '{quantity}')";

                tableCmd.ExecuteNonQuery();

                connection.Close();




            }

            static string GetDateInput()
            {
                Console.WriteLine("\n\n Please insert date: (Format: dd-mm-yy). Type 0 to return to main menu");
                string dateInput = Console.ReadLine();

                if (dateInput == "0") GetUserInput();

                return dateInput;


            }

            static int GetNumberInput(string message)
            {
                Console.WriteLine(message);

                string numberInput = Console.ReadLine();

                if (numberInput == "0") GetUserInput();
                int finalInput = Convert.ToInt32(numberInput);

                return finalInput;


            }



        }

    }
}







    




    


























