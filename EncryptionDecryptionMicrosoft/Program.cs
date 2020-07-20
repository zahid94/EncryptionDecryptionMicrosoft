using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace EncryptionDecryptionMicrosoft
{
    class Program
    {
        static void Main(string[] args)
        {

            CryptoEngine crypto = new CryptoEngine();
            //Console.WriteLine($"Public Key: \n {crypto.publickeystring()}\n");

            Console.WriteLine("Enter Your paintext for encryption.");
            string cypher = string.Empty;
            var text = Console.ReadLine();
            if (!text.Equals(string.Empty))
            {
                cypher = crypto.encryption(text);
                Console.WriteLine($"Cypher text:\n {cypher}\n");
            }

            Console.WriteLine("enter for decryption");
            Console.ReadLine();
            var paintext = crypto.decryption(cypher);
            Console.WriteLine($"paintext : \n {paintext}\n");
            Console.ReadLine();
        }
    }
}
