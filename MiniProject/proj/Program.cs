using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data; 
using System.Data.SqlClient;

namespace proj
{
    class Program
    {
        static string connectionString = "Data Source=ICS-LT-B84DBC3\\SQLEXPRESS;Initial Catalog=Projectdb;User ID=sa;Password=Bindu@123";

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Welcome to the Railway Reservation System");
                Console.WriteLine("=============================================");
                Console.WriteLine("1. Login as Admin");
                Console.WriteLine("2. Login as User");
                Console.WriteLine("3. Exit");
                Console.Write("Enter your choice: ");
                int choice = Convert.ToInt32(Console.ReadLine());

                if (choice == 1)
                {
                    Console.WriteLine("Admin Login");
                    Console.Write("Enter username: ");
                    string username = Console.ReadLine();
                    Console.Write("Enter password: ");
                    string password = Console.ReadLine();

                    string role = AuthenticateUser(username, password);
                    if (role == "admin")
                    {
                        Console.WriteLine($"Login successful. Welcome, {username} (Admin)");
                        AdminMenu();
                    }
                    else
                    {
                        Console.WriteLine("Invalid username, password, or role.");
                    }
                }
                else if (choice == 2)
                {
                    Console.WriteLine("User Login");
                    Console.Write("Enter username: ");
                    string username = Console.ReadLine();
                    Console.Write("Enter password: ");
                    string password = Console.ReadLine();

                    string role = AuthenticateUser(username, password);
                    if (role == "user")
                    {
                        Console.WriteLine($"Login successful. Welcome, {username} (User)");
                        UserMenu();
                    }
                    else
                    {
                        Console.WriteLine("Invalid username, password, or role.");
                    }
                }
                else if (choice == 3)
                {
                    Console.WriteLine("Exiting the Railway Reservation System. Goodbye!");
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please try again.");
                }
            }
        }

        static string AuthenticateUser(string username, string pasword)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("select roles from Users where username = @username and pasword = @password", con);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", pasword);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    return reader["roles"].ToString();
                }
                else
                {
                    return null;
                }
            }
        }

        static void AdminMenu()
        {
            while (true)
            {
                Console.WriteLine("Admin Menu");
                Console.WriteLine("1. View Bookings");
                Console.WriteLine("2. View Cancellations");
                Console.WriteLine("3. Add Train");
                Console.WriteLine("4. Update Train");
                Console.WriteLine("5. Logout");
                Console.Write("Enter your choice: ");
                int choice = Convert.ToInt32(Console.ReadLine());

                if (choice == 1)
                {
                    ViewBookings();
                }
                else if (choice == 2)
                {
                    ViewCancellations();
                }
                else if (choice == 3)
                {
                    AddTrain();
                }
                else if (choice == 4)
                {
                    UpdateTrain();
                }
                else if (choice == 5)
                {
                    break;
                }
                
                else
                {
                    Console.WriteLine("Invalid choice. Please try again.");
                }
            }
        }

        static void UserMenu()
        {
            while (true)
            {
                Console.WriteLine("User Menu");
                Console.WriteLine("1. Book Tickets");
                Console.WriteLine("2. Cancel Tickets");
                Console.WriteLine("3. Logout");
                Console.Write("Enter your choice: ");
                int choice = Convert.ToInt32(Console.ReadLine());

                if (choice == 1)
                {
                    BookTickets();
                }
                else if (choice == 2)
                {
                    CancelTickets();
                }
                else if (choice == 3)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please try again.");
                }
            }
        }

        static void BookTickets()
        {
            Console.Write("Enter your User ID: ");
            int userid = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Train Number: ");
            int trainNumber = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter number of seats to book: ");
            int seatsToBook = Convert.ToInt32(Console.ReadLine());

            try
            {
                BookTickets(userid, trainNumber, seatsToBook);
                Console.WriteLine("Booking successful.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        static void CancelTickets()
        {
            Console.Write("Enter Booking ID: ");
            int bookingId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter number of seats to cancel: ");
            int seatsToCancel = Convert.ToInt32(Console.ReadLine());

            try
            {
                CancelTickets(bookingId, seatsToCancel);
                Console.WriteLine("Cancellation successful.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        static void ViewBookings()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from Bookings", con);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine($"Booking ID: {reader["booking_id"]}, Train Number: {reader["tno"]}, User ID: {reader["userid"]}, Seats Booked: {reader["seats_booked"]}, Booking Date: {reader["booking_date"]}");
                }
            }
        }

        static void ViewCancellations()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("select * from Cancellations", con);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine($"Cancellation ID: {reader["cancellation_id"]}, Booking ID: {reader["booking_id"]}, Seats Cancelled: {reader["seats_cancelled"]}, Cancellation Date: {reader["cancellation_date"]}");
                }
            }
        }
        static void AddTrain()
        {
            Console.Write("Enter Train Number: ");
            int trainNumber = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Train Name: ");
            string trainName = Console.ReadLine();
            Console.Write("Enter From Station: ");
            string from = Console.ReadLine();
            Console.Write("Enter Destination Station: ");
            string dest = Console.ReadLine();
            Console.Write("Enter Price: ");
            decimal price = decimal.Parse(Console.ReadLine());
            Console.Write("Enter Class of Travel: ");
            string classOfTravel = Console.ReadLine();
            Console.Write("Enter Train Status (active/inactive): ");
            string trainStatus = Console.ReadLine();
            Console.Write("Enter Number of Seats Available: ");
            int seatsAvailable = Convert.ToInt32(Console.ReadLine());

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                

                SqlCommand cmd = new SqlCommand("insert into Trains (tno, tname, [from], dest, price, class_of_travel, train_status, seats_available) values (@tno, @tname, @from, @dest, @price, @class_of_travel, @train_status, @seats_available)", con);
                cmd.Parameters.AddWithValue("@tno", trainNumber);
                cmd.Parameters.AddWithValue("@tname", trainName);
                cmd.Parameters.AddWithValue("@from", from);
                cmd.Parameters.AddWithValue("@dest", dest);
                cmd.Parameters.AddWithValue("@price", price);
                cmd.Parameters.AddWithValue("@class_of_travel", classOfTravel);
                cmd.Parameters.AddWithValue("@train_status", trainStatus);
                cmd.Parameters.AddWithValue("@seats_available", seatsAvailable);
                con.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                con.Close();

                if (rowsAffected > 0)
                {
                    Console.WriteLine("Train added successfully.");
                }
                else
                {
                    Console.WriteLine("Train adding failed. Please check the train number.");
                }

            }
        }

        static void UpdateTrain()
        {
            Console.Write("Enter Train Number to update: ");
            int trainNumber = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Train Name: ");
            string trainName = Console.ReadLine();
            Console.Write("Enter From Station: ");
            string fromStation = Console.ReadLine();
            Console.Write("Enter Destination Station: ");
            string destination = Console.ReadLine();
            Console.Write("Enter Price: ");
            decimal price = decimal.Parse(Console.ReadLine());
            Console.Write("Enter Class of Travel: ");
            string classOfTravel = Console.ReadLine();
            Console.Write("Enter Train Status (active/inactive): ");
            string trainStatus = Console.ReadLine();
            Console.Write("Enter Number of Seats Available: ");
            int seatsAvailable = Convert.ToInt32(Console.ReadLine());

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                

                SqlCommand cmd = new SqlCommand("update Trains set tname = @tname, [from] = @from, dest = @dest, price = @price, class_of_travel = @class_of_travel, train_status = @train_status, seats_available = @seats_available where tno = @tno", con);
                cmd.Parameters.AddWithValue("@tno", trainNumber);
                cmd.Parameters.AddWithValue("@tname", trainName);
                cmd.Parameters.AddWithValue("@from", fromStation);
                cmd.Parameters.AddWithValue("@dest", destination);
                cmd.Parameters.AddWithValue("@price", price);
                cmd.Parameters.AddWithValue("@class_of_travel", classOfTravel);
                cmd.Parameters.AddWithValue("@train_status", trainStatus);
                cmd.Parameters.AddWithValue("@seats_available", seatsAvailable);
                con.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                con.Close();

                if (rowsAffected > 0)
                {
                    Console.WriteLine("Train updated successfully.");
                }
                else
                {
                    Console.WriteLine("Train update failed. Please check the train number.");
                }
            }
            
            
        }


        static void BookTickets(int userid, int trainNumber, int seatsToBook)
        {
            if (seatsToBook > 3)
            {
                throw new Exception("Cannot book more than 3 tickets at a time.");
            }

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                
                SqlCommand checkCmd = new SqlCommand("select seats_available, train_status from Trains where tno = @tno and train_status = 'active'", con);
                checkCmd.Parameters.AddWithValue("@tno", trainNumber);
                SqlDataReader reader = checkCmd.ExecuteReader();

                if (reader.Read())
                {
                    int seatsAvailable = (int)reader["seats_available"];
                    string trainStatus = (string)reader["train_status"];

                    if (seatsAvailable < seatsToBook)
                    {
                        throw new Exception("Not enough seats available.");
                    }

                    reader.Close();

                    
                    SqlCommand bookCmd = new SqlCommand("insert into Bookings (tno, userid, seats_booked, booking_date) values (@tno, @userid, @seats_booked, @booking_date)", con);
                    bookCmd.Parameters.AddWithValue("@tno", trainNumber);
                    bookCmd.Parameters.AddWithValue("@userid", userid);
                    bookCmd.Parameters.AddWithValue("@seats_booked", seatsToBook);
                    bookCmd.Parameters.AddWithValue("@booking_date", DateTime.Now);

                    bookCmd.ExecuteNonQuery();

                   
                    SqlCommand updateCmd = new SqlCommand("update Trains set seats_available = seats_available - @seats_booked where tno = @tno", con);
                    updateCmd.Parameters.AddWithValue("@seats_booked", seatsToBook);
                    updateCmd.Parameters.AddWithValue("@tno", trainNumber);

                    updateCmd.ExecuteNonQuery();
                }
                else
                {
                    throw new Exception("Train is not active or does not exist.");
                }
            }
        }

        static void CancelTickets(int bookingId, int seatsToCancel)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                
                SqlCommand checkCmd = new SqlCommand("select tno, seats_booked from Bookings where booking_id = @booking_id", con);
                checkCmd.Parameters.AddWithValue("@booking_id", bookingId);
                SqlDataReader reader = checkCmd.ExecuteReader();

                if (reader.Read())
                {
                    int trainNumber = (int)reader["tno"];
                    int seatsBooked = (int)reader["seats_booked"];

                    if (seatsToCancel > seatsBooked)
                    {
                        throw new Exception("Cannot cancel more seats than booked.");
                    }

                    reader.Close();

                    
                    SqlCommand cancelCmd = new SqlCommand("insert into Cancellations (booking_id, seats_cancelled, cancellation_date) values (@booking_id, @seats_cancelled, @cancellation_date)", con);
                    cancelCmd.Parameters.AddWithValue("@booking_id", bookingId);
                    cancelCmd.Parameters.AddWithValue("@seats_cancelled", seatsToCancel);
                    cancelCmd.Parameters.AddWithValue("@cancellation_date", DateTime.Now);

                    cancelCmd.ExecuteNonQuery();

                   
                    SqlCommand updateCmd = new SqlCommand("update Trains set seats_available = seats_available + @seats_cancelled where tno = @tno", con);
                    updateCmd.Parameters.AddWithValue("@seats_cancelled", seatsToCancel);
                    updateCmd.Parameters.AddWithValue("@tno", trainNumber);

                    updateCmd.ExecuteNonQuery();

                    
                    SqlCommand updateBookingCmd = new SqlCommand("update Bookings set seats_booked = seats_booked - @seats_cancelled where booking_id = @booking_id", con);
                }
            }
        }
    }
}
  