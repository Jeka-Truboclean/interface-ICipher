using System.Text;

namespace _21._03
{
    class Program
    {
        public interface ICipher
        {
            string Encode(string str);
            string Decode(string str);
        }
        static void Main()
        {
            Chipher ch = new Chipher();
            string originalString = "Hello world!";
            string binaryString = ch.Encode(originalString);
            Console.WriteLine($"Encrypted binary string: {binaryString}");

            string decryptedString = ch.Decode(binaryString);
            Console.WriteLine($"Decrypted string: {decryptedString}");
        }
        public class Chipher : ICipher
        {
            public string Encode(string str)
            {
                StringBuilder sb = new StringBuilder();

                foreach (char c in str.ToCharArray())
                {
                    sb.Append(Convert.ToString(c, 2).PadLeft(8, '0'));
                }

                return sb.ToString();
            }

            public string Decode(string str)
            {
                StringBuilder sb = new StringBuilder();

                for (int i = 0; i < str.Length; i += 8)
                {
                    string binaryChar = str.Substring(i, 8);
                    sb.Append(Convert.ToChar(Convert.ToInt32(binaryChar, 2)));
                }

                return sb.ToString();
            }
        }
    }
}
