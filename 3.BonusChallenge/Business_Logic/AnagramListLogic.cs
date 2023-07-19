using _3.BonusChallenge_1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static System.Net.Mime.MediaTypeNames;

namespace _3.BonusChallenge.Business_Logic
{
    public class AnagramListLogic
    {
        Resource resource = new Resource();
        public IEnumerable<IEnumerable<string>> GetSimpleOutput()
        {
            return Output(resource.SimpleList);
        }
        public IEnumerable<IEnumerable<string>> GetHarderOutput()
        {
            return Output(resource.HarderList);
        }

        static IEnumerable<IEnumerable<string>> Output(IEnumerable<string> input)
        {
            var output = new List<List<string>>();

            // YOUR CODE GOES HERE
            //remove duplicates, remove empty/whitespace strings, sort alphabetically
            List<string> cleanInput = input.Distinct().ToList();
            cleanInput.RemoveAll(string.IsNullOrWhiteSpace);
            cleanInput = cleanInput.Select(s => s.Trim()).ToList();
            cleanInput.Sort();

            while (cleanInput.Count != 0)
            {
                List<string> list = new List<string>();
                list.Add(cleanInput[0]);
                string compare = cleanInput[0];
                cleanInput.RemoveAt(0);

                for (int i = 0; i < cleanInput.Count; i++)
                {
                    if (IsAnagram(compare, cleanInput[i]))
                    {
                        list.Add((string)cleanInput[i]);
                        cleanInput.RemoveAt(i);
                    }
                }
                output.Add(list);
            }
            return output;
        }

        static bool IsAnagram(string str1, string str2)
        {
            str1 = str1.ToLower();
            str2 = str2.ToLower();

            if (str1.Length != str2.Length)
            {
                return false;
            }

            List<char> remainingChars = new List<char>();
            remainingChars.AddRange(str2);

            for (int i = 0; i < str1.Length; i++)
            {
                //if we are unable to remove the char from remainingChars, it means it doesn't exist and the strings are not anagrams
                if (!remainingChars.Remove(str1[i]))
                {
                    return false;
                }
            }
            return true;
        }

    }
}