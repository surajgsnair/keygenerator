using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.Configuration;

public class Program
{
    public const string InputKey = "HQVFX-X58LW-3FKTK-A8L+I-WIBVO";
    public static void Main(string[] args)
    {

        IConfiguration Config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
        var key = Config.GetSection("TokenKey").Value;
        Console.WriteLine(KeyGenerate(key.ToUpper()).ToUpper());
        Console.WriteLine("Press any key to exit.");
        Console.ReadLine();
        Environment.Exit(0);
    }
    private static string KeyGenerate(string token)
    {
        return Left(Convert.ToBase64String(new SHA1CryptoServiceProvider().ComputeHash(new UnicodeEncoding().GetBytes("FCSH" + token))) + "4546RJT", 25);

    }

    private static string Left(string StringValue, int Length) => StringValue.Length <= Length ? StringValue : StringValue.Substring(0, Length);
}
