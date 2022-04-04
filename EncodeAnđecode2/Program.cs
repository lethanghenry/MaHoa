using System;
using System.Security.Cryptography;
using System.Text;

namespace EncodeAnđecode2
{
    class Program
    {
        
        static string key { get; set; } = "A!9HHhi%XjjYY4YP2@Nob009X";
        static void Main(string[] args)
        {
            var text = "lethanghenry";
            Console.WriteLine(text);

            //var cipher = EncodeString(text);
            //Console.WriteLine(cipher);

            //text = DecodeString(cipher);
            //Console.WriteLine(text);

            var cipher = Encode(text);
            Console.WriteLine(cipher.ToString());

            var text2 = Decode(cipher);
            Console.WriteLine(text2);

            Console.ReadKey();
        }

        public static string Encode(string text)
        {
            Byte[] mybyte = System.Text.Encoding.UTF8.GetBytes(text);
            string returntext = System.Convert.ToBase64String(mybyte);
            return returntext;
        }
        public static Byte[] Encode2(string text)
        {
            byte[] mybyte = System.Text.Encoding.UTF8.GetBytes(text);
            return mybyte;
        }
        public static string Decode(string text)
        {
            Byte[] mybyte = System.Convert.FromBase64String(text);
            string returntext = System.Text.Encoding.UTF8.GetString(mybyte);
            return returntext;
        }
        public static Byte[] Decode2(string text)
        {
            Byte[] mybyte = System.Convert.FromBase64String(text);
            
            return mybyte;
        }

        static string EncodeString(string password)
        {
            using (var md5 = new MD5CryptoServiceProvider())
            {
                using (var tdes =new TripleDESCryptoServiceProvider())
                {
                    tdes.Key = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                    tdes.Mode = CipherMode.ECB;
                    tdes.Padding = PaddingMode.PKCS7;

                    using (var transform = tdes.CreateEncryptor())
                    {
                        byte[] textBytes = UTF8Encoding.UTF8.GetBytes(password);
                        byte[] bytes = transform.TransformFinalBlock(textBytes, 0, textBytes.Length);
                        return Convert.ToBase64String(bytes, 0, bytes.Length);
                    }
                }
            }
        }
        static Byte[] EncodeByte(string password)
        {
            using (var md5 = new MD5CryptoServiceProvider())
            {
                using (var tdes = new TripleDESCryptoServiceProvider())
                {
                    tdes.Key = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                    tdes.Mode = CipherMode.ECB;
                    tdes.Padding = PaddingMode.PKCS7;

                    using (var transform = tdes.CreateEncryptor())
                    {
                        byte[] textBytes = UTF8Encoding.UTF8.GetBytes(password);
                        byte[] bytes = transform.TransformFinalBlock(textBytes, 0, textBytes.Length);
                        return bytes;
                    }
                }
            }
        }
        static string DecodeString(string password)
        {
            using (var md5 = new MD5CryptoServiceProvider())
            {
                using (var tdes = new TripleDESCryptoServiceProvider())
                {
                    tdes.Key = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                    tdes.Mode = CipherMode.ECB;
                    tdes.Padding = PaddingMode.PKCS7;

                    using (var transform = tdes.CreateDecryptor())
                    {
                        byte[] cipherBytes = Convert.FromBase64String(password);
                        byte[] bytes = transform.TransformFinalBlock(cipherBytes, 0, cipherBytes.Length);
                        return UTF8Encoding.UTF8.GetString(bytes);
                    }
                }
            }
        }

        static Byte[] DecodeByte(string password)
        {
            using (var md5 = new MD5CryptoServiceProvider())
            {
                using (var tdes = new TripleDESCryptoServiceProvider())
                {
                    tdes.Key = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                    tdes.Mode = CipherMode.ECB;
                    tdes.Padding = PaddingMode.PKCS7;

                    using (var transform = tdes.CreateDecryptor())
                    {
                        byte[] cipherBytes = Convert.FromBase64String(password);
                        byte[] bytes = transform.TransformFinalBlock(cipherBytes, 0, cipherBytes.Length);
                        return bytes;
                    }
                }
            }
        }
    }
}
