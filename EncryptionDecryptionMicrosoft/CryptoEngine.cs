using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace EncryptionDecryptionMicrosoft
{
    public class CryptoEngine
    {
        private static RSACryptoServiceProvider rSA = new RSACryptoServiceProvider(2048);
        private RSAParameters _privateKey;
        private RSAParameters _publicKey;
        public CryptoEngine()
        {
            _privateKey = rSA.ExportParameters(true);
            _publicKey = rSA.ExportParameters(false);
        }

        //public string publickeystring()
        //{
        //    string s = "dgn hgdf gfd hgkdfh";
        //    //var sw = new StringWriter();
        //    //var xs = new XmlSerializer(typeof(RSAParameters));
        //    //xs.Serialize(sw,_publicKey);
        //    return s;
        //}

        public string encryption(string paintext)
        {
            rSA = new RSACryptoServiceProvider();
            rSA.ImportParameters(_publicKey);

            var data = Encoding.Unicode.GetBytes(paintext);
            var cypher = rSA.Encrypt(data, false);
            return Convert.ToBase64String(cypher);
        }
        public string decryption(string cypher)
        {
            var dataBytes = Convert.FromBase64String(cypher);
            rSA.ImportParameters(_privateKey);
            var paintext = rSA.Decrypt(dataBytes, false);
            return Encoding.Unicode.GetString(paintext);
        }
    }
}
