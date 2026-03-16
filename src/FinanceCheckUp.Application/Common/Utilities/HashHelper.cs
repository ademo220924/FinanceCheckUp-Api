using System.Security.Cryptography;
using System.Text;

namespace FinanceCheckUp.Application.Common.Utilities;

public static class HashHelper
{
    public static string GenerateHashKey(string total, string installment, string currencyCode, string merchantKey, string invoiceİd, string appSecret)
    {

        var data = total + "|" + installment + "|" + currencyCode + "|" + merchantKey + "|" + invoiceİd;

        var mtRand = new Random();

        var iv = Sha1Hash(mtRand.Next().ToString())[..16];
        var password = Sha1Hash(appSecret);
        var salt = Sha1Hash(mtRand.Next().ToString()).Substring(0, 4);
        var saltWithPassword = "";
        using var sha256Hash = SHA256.Create();
        saltWithPassword = GetHash(sha256Hash, password + salt);
        var encrypted = Encryptor(data, saltWithPassword[..32], iv);

        var msgEncryptedBundle = iv + ":" + salt + ":" + encrypted;
        msgEncryptedBundle = msgEncryptedBundle.Replace("/", "__");

        return msgEncryptedBundle;
    }

    [Obsolete("Obsolete")]
    public static IList<string> ValidateHashKey(string hashKey, string appSecret)
    {
        hashKey = hashKey.Replace("__", "/");
        var password = Sha1Hash(appSecret);

        IList<string> mainStringArray = hashKey.Split(':').ToList();

        if (mainStringArray.Count != 3)
            return new List<string>();

        var iv = mainStringArray[0];
        var salt = mainStringArray[1];
        var mainKey = mainStringArray[2];

        var saltWithPassword = "";
        using var sha256Hash = SHA256.Create();
        saltWithPassword = GetHash(sha256Hash, password + salt);
        var originalValues = Decryptor(mainKey, saltWithPassword[..32], iv);
        IList<string> valueList = originalValues.Split('|').ToList();
        return valueList;
    }

    private static string GetHash(HashAlgorithm hashAlgorithm, string input)
    {
        var data = hashAlgorithm.ComputeHash(Encoding.UTF8.GetBytes(input));
        var sBuilder = new StringBuilder();
        foreach (var t in data)
        {
            sBuilder.Append(t.ToString("x2"));
        }
        return sBuilder.ToString();
    }

    [Obsolete("Obsolete")]
    private static string Sha1Hash(string password)
    {
        return string.Join("", SHA1CryptoServiceProvider.Create().ComputeHash(Encoding.UTF8.GetBytes(password)).Select(x => x.ToString("x2")));
    }

    [Obsolete("Obsolete")]
    private static string Encryptor(string textToEncrypt, string strKey, string strIv)
    {
        var plainTextBytes = Encoding.UTF8.GetBytes(textToEncrypt);
        using var aesProvider = new AesCryptoServiceProvider();
        aesProvider.BlockSize = 128;
        aesProvider.KeySize = 256;
        aesProvider.Key = Encoding.UTF8.GetBytes(strKey);
        aesProvider.IV = Encoding.UTF8.GetBytes(strIv);
        aesProvider.Padding = PaddingMode.PKCS7;
        aesProvider.Mode = CipherMode.CBC;

        var cryptoTransform = aesProvider.CreateEncryptor(aesProvider.Key, aesProvider.IV);
        var encryptedBytes = cryptoTransform.TransformFinalBlock(plainTextBytes, 0, plainTextBytes.Length);
        return Convert.ToBase64String(encryptedBytes);
    }

    [Obsolete("Obsolete")]
    private static string Decryptor(string textToDecrypt, string strKey, string strIv)
    {
        var encryptedBytes = Convert.FromBase64String(textToDecrypt);
        var aesProvider = new AesCryptoServiceProvider();
        aesProvider.BlockSize = 128;
        aesProvider.KeySize = 256;
        aesProvider.Key = Encoding.ASCII.GetBytes(strKey);
        aesProvider.IV = Encoding.ASCII.GetBytes(strIv);
        aesProvider.Padding = PaddingMode.PKCS7;
        aesProvider.Mode = CipherMode.CBC;


        var cryptoTransform = aesProvider.CreateDecryptor(aesProvider.Key, aesProvider.IV);
        var decryptedBytes = cryptoTransform.TransformFinalBlock(encryptedBytes, 0, encryptedBytes.Length);
        return Encoding.ASCII.GetString(decryptedBytes);
    }




}