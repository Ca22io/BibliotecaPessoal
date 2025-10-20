using Microsoft.AspNetCore.Identity;
using BibliotecaPessoal.Models;

public class BCryptSenhaHasher<TUser> : IPasswordHasher<TUser> where TUser : class
{
    public string HashPassword(TUser user, string password)
    {
        return BCrypt.Net.BCrypt.HashPassword(password);
    }

    public PasswordVerificationResult VerifyHashedPassword(TUser user, string hashedPassword, string providedPassword)
    {
        bool isValid = BCrypt.Net.BCrypt.Verify(providedPassword, hashedPassword);

        if (isValid)
        {
            return PasswordVerificationResult.Success;
        }
        else
        {
            return PasswordVerificationResult.Failed;
        }
    }
}