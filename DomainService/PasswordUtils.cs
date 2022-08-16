using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace DomainService;

public static class PasswordUtilities
{
    /// <summary>
    ///     PBKDF 迭代次數(預設值爲 99999 次)
    /// </summary>
    private static readonly int Iteration = 99999;

    /// <summary>
    ///     哈希函數的選定 (預設是HMACSHA256)
    /// </summary>
    private static readonly KeyDerivationPrf Prf = KeyDerivationPrf.HMACSHA256;

    /// <summary>
    ///     使用者密碼 Pbkdf2 哈希
    /// </summary>
    /// <param name="password"></param>
    /// <returns>
    ///     (byte[] salt, string saltStr, byte[] hashed, string hashedStr)
    ///     (鹽byte形式,鹽base64形式,密碼byte形式,密碼base64形式)
    /// </returns>
    public static (byte[] Salt,byte[]Hash) Pbkdf2(string password)
    {
        // Processing - 亂數產生鹽
        var salt = new byte[128 / 8];
        using (var rngCsp = RandomNumberGenerator.Create())
        {
            rngCsp.GetNonZeroBytes(salt);
        }

        // Processing - 進行哈希
        var hashed = KeyDerivation.Pbkdf2(
            password,
            salt,
            Prf,
            Iteration,
            256 / 8);

        // Processing - 把計算的結果回傳
        return new (salt, hashed);
    }
}