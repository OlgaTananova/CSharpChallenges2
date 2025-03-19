using System;

namespace Practice.Core.PasswordValidator;

public class PasswordValidator
{
    public bool IsValidPassword(string password)
    {
        if (string.IsNullOrEmpty(password) || password.Length < 8) return false;

        // check the password length (must be > 8)
        bool hasUpper = password.Any(char.IsUpper);
        bool hasLower = password.Any(char.IsLower);
        bool hasDigit = password.Any(char.IsDigit);
        bool hasSpecial = password.Any(c => !char.IsLetterOrDigit(c));

        return hasUpper && hasLower & hasDigit && hasSpecial;
    }
    public bool IsValidPasswordWithSingleLoop(string password)
    {
        if (string.IsNullOrEmpty(password) || password.Length < 8) return false;

        bool hasUpper = false, hasLower = false, hasDigit = false, hasSpecial = false;

        foreach (char c in password)
        {
            if (char.IsUpper(c)) hasUpper = true;
            else if (char.IsLower(c)) hasLower = true;
            else if (char.IsDigit(c)) hasDigit = true;
            else hasSpecial = true; 

            if (hasUpper && hasDigit && hasLower && hasSpecial) return true;
        }
        return false;
    }

}
