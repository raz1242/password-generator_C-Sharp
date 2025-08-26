using System;
using System.Linq; // for All()

namespace PasswordApp {
    public static class PasswordGenerate {
        public static char[] character_list1 = {'0', '1', '2', '3', '4', '5', '6', '7', '8', '9','a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z',
                   'A','B','C','D','E','F','G','H','I','J','K','L','M', 'N','O','P','Q','R','S','T','U','V','W','X','Y', 'Z','!','@','#','$','%','^','&','*','(',')','_','+' };
        public static char[] character_list2 = {'0', '1', '2', '3', '4', '5', '6', '7', '8', '9','a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z',
                   'A','B','C','D','E','F','G','H','I','J','K','L','M', 'N','O','P','Q','R','S','T','U','V','W','X','Y','Z' };
        public static char[] character_list3 = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        public static char[] numerical_letters_list = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        public static char[] alphabetical_letters_list = {'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z',
                             'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
        public static char[] special_character_list = { '!', '@', '#', '$', '%', '^', '&', '*', '(', ')', '_', '+' };

        public static int password_length() {
            while (true) {
                Console.Write("Enter password length (8-20 characters, default's 16): ");
                string requested_password_length = Console.ReadLine();
                if (requested_password_length == "")
                    requested_password_length = "16";
                else if (!requested_password_length.All(char.IsDigit)) {
                    Console.WriteLine("Invalid input. Please enter a number.");
                    continue;
                }
                else if (int.Parse(requested_password_length) < 8 || int.Parse(requested_password_length) > 20) {
                    Console.WriteLine("Invalid input. Please enter a number between 8 and 20.");
                    continue;
                }
                return int.Parse(requested_password_length);
            }
        }
        public static char[] password_type() {
            while (true) {
                Console.Write("Choose password type:\n1. Alphanumeric with special characters\n2. Alphanumeric \n3. Numeric only\n(Default's 1): ");
                string type = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(type) || type == "1")
                    return character_list1;
                else if (type == "2")
                    return character_list2;
                else if (type == "3")
                    return character_list3;
                else
                    Console.WriteLine("Invalid input. Please enter 1, 2, or 3.");
            }
        }

        public static string PasswordGenerator1(int length, char[] character_list) {
            string password = "";
            Random rand = new Random();
            while (true) {
                password = "";
                char last_used_letter = ' ';
                while (password.Length < length) {
                    char next_letter = character_list[rand.Next(0, character_list.Length)];
                    if (next_letter != last_used_letter) {
                        password += next_letter;
                        last_used_letter = next_letter;
                    }
                }
                if (!validator(password, length, character_list))
                    continue;
                break;
            }
            return password;
        }

        public static bool validator(string password, int length, char[] character_list) {
            int list_length = character_list.Length;
            if (!validate_numerical_letters(password, length))
                return false;
            if (list_length == 62 || list_length == 74)
                if (!validate_alphabetical_letters(password, length))
                    return false;
            if (list_length == 74)
                if (!validate_special_characters(password, length))
                    return false;
            return true;
        }

        public static bool validate_numerical_letters(string password, int password_length) {
            int count = (int)Math.Ceiling((double)password_length / 4);
            for (int i = 0; i < password_length; i++) {
                if (numerical_letters_list.Contains(password[i]))
                    count--;
            }
            return count <= 0;
        }


        public static bool validate_alphabetical_letters(string password, int password_length) {
            int count = (int)Math.Ceiling((double)password_length / 4);
            for (int i = 0; i < password_length; i++) {
                if (alphabetical_letters_list.Contains(password[i]))
                    count--;
            }
            return count <= 0;
        }

        public static bool validate_special_characters(string password, int password_length) {
            int count = (int)Math.Ceiling((double)password_length / 4);
            for (int i = 0; i < password_length; i++) {
                if (special_character_list.Contains(password[i]))
                    count--;
            }
            return count <= 0;
        }

        /*public static void Main(string[] args) {
            Console.WriteLine("Password Generator");
            int request_password_length = password_length();
            char[] request_password_list = password_type();
            string password = generate_password(request_password_length, request_password_list);
            Console.WriteLine("Generated Password:");
            Console.WriteLine(password);
        }*/
    }
}