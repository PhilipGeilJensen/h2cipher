using System;
using System.Linq;
using System.Text;

namespace h2cipher
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                string key = "zyxwvutsrqponmlkjihgfedcba";

                key = Scramble(key);

                Console.WriteLine("Enter text to encrypt");
                string encrypted = Encrypt(Console.ReadLine().ToLower(), key);
                string decrypted = Decrypt(encrypted, key);

                Console.WriteLine("This is encrypted - {0}", encrypted);
                Console.WriteLine("This is decrypted - {0}", decrypted);

                GetPercentages(encrypted);
                Console.WriteLine();
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }


        }
        /// <summary>
        /// Encrypts the entered string
        /// </summary>
        /// <param name="plain"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        static string Encrypt(string plain, string key)
        {

            StringBuilder s = new StringBuilder();

            for (int i = 0; i < plain.Length; i++)
            {
                int j = plain[i] - 97;
                try
                {
                    s.Append(key[j]);
                }
                catch (Exception)
                {
                    s.Append(plain[i]);
                }
            }
            return s.ToString();
        }
        /// <summary>
        /// Decrypts the provided string with the given key
        /// </summary>
        /// <param name="text"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        static string Decrypt(string text, string key)
        {
            StringBuilder s = new StringBuilder();

            for (int i = 0; i < text.Length; i++)
            {
                int j = key.IndexOf(text[i]);
                try
                {
                    char ch = (char)(j + 97);
                    if (ch < 97)
                    {
                        s.Append(text[i]);
                    }
                    else
                    {
                        s.Append(ch);
                    }
                }
                catch (Exception)
                {
                    s.Append(text[i]);
                }
            }
            return s.ToString();
        }
        /// <summary>
        /// Shows the percentages eact letter is representated in the given string
        /// </summary>
        /// <param name="text"></param>
        static void GetPercentages(string text)
        {
            Console.WriteLine("Appearences of each letter in the ecrypted string:");
            string alphabet = "abcdefghijklmnopqrstuvwxyz";
            foreach (char item in alphabet)
            {
                int a = 0;
                foreach (char i in text)
                {
                    if (item == char.ToLower(i))
                    {
                        a++;
                    }
                }
                double percentage = a * 100 / text.Length;
                Console.Write("{0} appears {1}%  ", item, percentage);
                for (int i = 0; i < percentage; i++)
                {
                    Console.Write("#");
                }
                Console.WriteLine();
            }
        }
        /// <summary>
        /// Takes a string and mixes it up randomly
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        static string Scramble(string s)
        {
            return new string(s.ToCharArray().OrderBy(x => Guid.NewGuid()).ToArray());
        }
    }
}
