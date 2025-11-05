using System;
using System.Linq; // for All()

namespace PasswordApp {
    public static class PasswordGenerate {
        /* Character Lists:
         * character_list_all_symbols: Alphanumeric with special characters
         * character_list_only_numbers_and_letters_option: Alphanumeric
         * character_list_only_numbers_option: Numeric only
         * numerical_letters_list: Numerical letters only
         * alphabetical_letters_list: Alphabetical letters only
         * special_character_list: Special characters only
         */
        public static char[] character_list_all_symbols = {'0', '1', '2', '3', '4', '5', '6', '7', '8', '9','a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z',
                   'A','B','C','D','E','F','G','H','I','J','K','L','M', 'N','O','P','Q','R','S','T','U','V','W','X','Y', 'Z','!','@','#','$','%','^','&','*','(',')','_','+' };
        public static char[] character_list_only_numbers_and_letters_option = {'0', '1', '2', '3', '4', '5', '6', '7', '8', '9','a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z',
                   'A','B','C','D','E','F','G','H','I','J','K','L','M', 'N','O','P','Q','R','S','T','U','V','W','X','Y','Z' };
        public static char[] character_list_only_numbers_option = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        public static char[] numerical_letters_list = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        public static char[] alphabetical_letters_list = {'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z',
                             'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
        public static char[] special_character_list = { '!', '@', '#', '$', '%', '^', '&', '*', '(', ')', '_', '+' };

        /* Methods to get user input for password length and type */
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

        /* Method to get user input for password type */
        public static char[] password_type() {
            while (true) {
                Console.Write("Choose password type:\n1. Alphanumeric with special characters\n2. Alphanumeric \n3. Numeric only\n(Default's 1): ");
                string type = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(type) || type == "1")
                    return character_list_all_symbols;
                else if (type == "2")
                    return character_list_only_numbers_and_letters_option;
                else if (type == "3")
                    return character_list_only_numbers_option;
                else
                    Console.WriteLine("Invalid input. Please enter 1, 2, or 3.");
            }
        }

        /* Password Generator Method
         * @param length: Length of the password
         * @param character_list: List of characters to use for password generation
         */
        public static string PasswordGenerator1(int length, char[] character_list) {
            string password = "";
            Random rand = new Random();
            while (true) { // Loop until a valid password is generated
                password = ""; 
                char last_used_letter = ' '; // Initialize with a space or any character not in character_list
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

        /* Password Validator Method
         * @param password: Generated password
         * @param length: Length of the password
         * @param character_list: List of characters used for password generation
         */
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

        /* Numerical Letters Validator Method
         * @param password: Generated password
         * @param passord_length: Length of the password
         */
        public static bool validate_numerical_letters(string password, int password_length) {
            int count = (int)Math.Ceiling((double)password_length / 4);
            for (int i = 0; i < password_length; i++) {
                if (numerical_letters_list.Contains(password[i]))
                    count--;
            }
            return count <= 0;
        }

        /* Alphabetical Letters Validator Method
         * @param password: Generated password
         * @param passord_length: Length of the password
         */
        public static bool validate_alphabetical_letters(string password, int password_length) {
            int count = (int)Math.Ceiling((double)password_length / 4);
            for (int i = 0; i < password_length; i++) {
                if (alphabetical_letters_list.Contains(password[i]))
                    count--;
            }
            return count <= 0;
        }

        /* Special Characters Validator Method
         * @param password: Generated password
         * @param passord_length: Length of the password
         */
        public static bool validate_special_characters(string password, int password_length) {
            int count = (int)Math.Ceiling((double)password_length / 4);
            for (int i = 0; i < password_length; i++) {
                if (special_character_list.Contains(password[i]))
                    count--;
            }
            return count <= 0;
        }
    }
}