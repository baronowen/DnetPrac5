namespace ShopServerLibrary
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "UserService" in both code and config file together.
    public class UserService : IUserService
    {
        public string Register(string username) {
            /*
             * return password that has:
             * Lowercase,Uppercase and Numbers
             *
             */
            return GeneratePassword(10, true, true, true, false, false);
        }

        public string login(string username, string password) {
            //hard coded stuff that needs to be changed when persistence has been done

            return username == "surname" && password == "passworded" ? string.Format("you entered: {0},{1}", username, password) : "username and password combination is wrong";
        }

        public string getsaldo(int id) {
            //hard coded stuff that needs to be changed when persistence has been done
            return "20";
        }
        public string GetUserProductsJson(int id) {

            return "grgege";
        }

        // password generator that comes with c# isn't any good so made a new one
        public string GeneratePassword(int length, bool includeLowercase, bool includeUpperCase, bool includeNumeric, bool includeSpecial, bool includeSpaces) {
            //define character sets
            const int MAX_CONSECUTIVE_IDENTICALS = 2;
            const string LOWERCASE_CHARACTERS = "abcdefghijklmnopqrstuvwxyz";
            const string UPPERCASE_CHARACTERS = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const string NUMERIC_CHARACTERS = "0123456789";
            const string SPECIAL_CHARACTERS = @"!#$%&*@\";
            const string SPACE_CHARACTER = " ";

            //define character set to use in generation
            string charset = "";
            if (includeLowercase) { charset += LOWERCASE_CHARACTERS; }
            if (includeUpperCase) { charset += UPPERCASE_CHARACTERS; }
            if (includeNumeric) { charset += NUMERIC_CHARACTERS; }
            if (includeSpecial) { charset += SPECIAL_CHARACTERS; }
            if (includeSpaces) { charset += SPACE_CHARACTER; }

            char[] password = new char[length];
            int charSetLength = charset.Length;

            System.Random randomObject = new System.Random();

            // fill password char[] with randomly defined characters
            for (int charPosition = 0; charPosition < length; charPosition++) {
                password[charPosition] = charset[randomObject.Next(charSetLength - 1)];

                //splitted define and execute for visibility

                bool checkThreeConsecutiveChars =
                    charPosition > MAX_CONSECUTIVE_IDENTICALS &&
                    password[charPosition] == password[charPosition - 1] &&
                    password[charPosition] == password[charPosition - 2];

                if (checkThreeConsecutiveChars) {
                    charPosition--;
                }
            }
            return string.Join(null, password);
        }
    }
}