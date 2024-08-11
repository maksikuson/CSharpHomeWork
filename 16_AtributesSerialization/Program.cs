using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text;

namespace _16_AtributesSerialization
{
    public class User
    {
        [Range(1000, 9999, ErrorMessage = "ID must be a unique value between 1000 and 9999.")]
        public int Id { get; set; }

        [RegularExpression(@"^[a-zA-Z0-9]+$", ErrorMessage = "Login must contain only printed characters without special characters.")]
        public string Login { get; set; }

        [RegularExpression(@"^[a-zA-Z0-9]{8,}$", ErrorMessage = "Password must contain only printed characters without special characters, at least 8 characters long.")]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Password and ConfirmPassword do not match.")]
        public string ConfirmPassword { get; set; }

        [EmailAddress(ErrorMessage = "Invalid E-mail.")]
        public string Email { get; set; }

        [CreditCard(ErrorMessage = "Invalid credit card number.")]
        public string CreditCard { get; set; }

        [RegularExpression(@"^\+38-0\d{2}-\d{7}$", ErrorMessage = "Phone must be in +38-0**-*******")]
        public string Phone { get; set; }

        public override string ToString()
        {
            return $"ID: {Id}, Login: {Login}, Email: {Email}, Phone: {Phone}";
        }
    }

    internal class Program
    {
        static Dictionary<int, User> users = new Dictionary<int, User>();
        static string filePath = "users.json";

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            LoadFromFile();

            while (true)
            {
                Console.WriteLine("Menu :");
                Console.WriteLine("1. Add user");
                Console.WriteLine("2. Show all users");
                Console.WriteLine("3. Update User");
                Console.WriteLine("4. Delete user");
                Console.WriteLine("5. Save data to file");
                Console.WriteLine("6. Load data from file");
                Console.WriteLine("7. Exit");
                Console.Write("Select the option : ");

                int choice;
                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    switch (choice)
                    {
                        case 1:
                            AddUser();
                            break;
                        case 2:
                            DisplayUsers();
                            break;
                        case 3:
                            UpdateUser();
                            break;
                        case 4:
                            DeleteUser();
                            break;
                        case 5:
                            SaveToFile();
                            break;
                        case 6:
                            LoadFromFile();
                            break;
                        case 7:
                            return;
                        default:
                            Console.WriteLine("Wrong choice. Try again.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Incorrect input. Try again.");
                }
            }
        }

        static void AddUser()
        {
            User user = new User();
            Console.Write("Enter ID: ");
            user.Id = int.Parse(Console.ReadLine()!);

            if (users.ContainsKey(user.Id))
            {
                Console.WriteLine("A user with the same ID already exists.");
                return;
            }

            Console.Write("Enter Login : ");
            user.Login = Console.ReadLine()!;
            Console.Write("Enter Password : ");
            user.Password = Console.ReadLine()!;
            Console.Write("Confirm Password : ");
            user.ConfirmPassword = Console.ReadLine()!;
            Console.Write("Enter Email : ");
            user.Email = Console.ReadLine()!;
            Console.Write("Enter credit card number : ");
            user.CreditCard = Console.ReadLine()!;
            Console.Write("Enter your phone : ");
            user.Phone = Console.ReadLine()!;

            var results = new List<ValidationResult>();
            var context = new ValidationContext(user);

            if (!Validator.TryValidateObject(user, context, results, true))
            {
                foreach (var error in results)
                {
                    Console.WriteLine(error.ErrorMessage);
                }
                Console.WriteLine("User not added due to validation error.");
            }
            else
            {
                users.Add(user.Id, user);
                Console.WriteLine("User added.");
            }
        }

        static void DisplayUsers()
        {
            if (users.Count == 0)
            {
                Console.WriteLine("The list of users is empty.");
            }
            else
            {
                foreach (var user in users.Values)
                {
                    Console.WriteLine(user);
                }
            }
        }

        static void UpdateUser()
        {
            Console.Write("Enter the ID of the user you want to update: ");
            int id = int.Parse(Console.ReadLine()!);

            if (!users.ContainsKey(id))
            {
                Console.WriteLine("No user with this ID was found.");
                return;
            }

            User user = users[id];
            Console.Write("Enter new Login : ");
            user.Login = Console.ReadLine()!;
            Console.Write("Enter a new Password : ");
            user.Password = Console.ReadLine()!;
            Console.Write("Confirm new Password : ");
            user.ConfirmPassword = Console.ReadLine()!;
            Console.Write("Enter a new Email : ");
            user.Email = Console.ReadLine()!;
            Console.Write("Please enter a new credit card number : ");
            user.CreditCard = Console.ReadLine()!;
            Console.Write("Enter new phone : ");
            user.Phone = Console.ReadLine()!;

            var results = new List<ValidationResult>();
            var context = new ValidationContext(user);

            if (!Validator.TryValidateObject(user, context, results, true))
            {
                foreach (var error in results)
                {
                    Console.WriteLine(error.ErrorMessage);
                }
                Console.WriteLine("User not updated due to validation error.");
            }
            else
            {
                users[id] = user;
                Console.WriteLine("User updated.");
            }
        }

        static void DeleteUser()
        {
            Console.Write("Enter the ID of the user you want to delete : ");
            int id = int.Parse(Console.ReadLine()!);

            if (users.Remove(id))
            {
                Console.WriteLine("User deleted.");
            }
            else
            {
                Console.WriteLine("No user with this ID was found.");
            }
        }

        static void SaveToFile()
        {
            string json = JsonSerializer.Serialize(users, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, json);
            Console.WriteLine("The data is saved to a file.");
        }

        static void LoadFromFile()
        {
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                users = JsonSerializer.Deserialize<Dictionary<int, User>>(json);
                Console.WriteLine("Data loaded from file.");
            }
            else
            {
                Console.WriteLine("File not found.");
            }
        }
    }
}
