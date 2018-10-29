using System;
using System.Collections.Generic;
using System.Linq;


namespace addSpaces
{
    public class Spacefier
    {
        string[] m_dictionary;
        public Spacefier(string[] dictionary = null)
        {
            if (dictionary != null)
                SetDictonary(dictionary);
        }

        public void SetDictonary(string[] dictionary)
        {
            if (dictionary == null || dictionary.Length == 0)
                throw new ArgumentException();
            m_dictionary = dictionary;
        }

        public string Specify(string src)
        {
            if (m_dictionary == null)
                throw new InvalidOperationException();

            var dest = src;
            foreach (string word in m_dictionary)
                dest = FindAndAddSpaces(dest, word);
            return dest;
        }

        private string FindAndAddSpaces(string dest, string word)
        {
            var indexes = dest.AllIndexesOf(word);
            return insertSpacesIntoString(dest, indexes,word.Length);
        }

        public static string insertSpacesIntoString(
            string src, 
            IEnumerable<int> indexes,
            int wordLength)
        {

            string dest = src.Substring(0, indexes.First());
            if (dest.Length > 0 && dest.Last() != ' ')
                dest += " ";
            return String.Empty;
        }
    }

    static class StringExt
    {
        public static IEnumerable<int> AllIndexesOf(this string str, string value)
        {
            if (String.IsNullOrEmpty(value))
                throw new ArgumentException("the string to find may not be empty", "value");
            for (int index = 0; ; index += value.Length)
            {
                index = str.IndexOf(value, index);
                if (index == -1)
                    break;
                yield return index;
            }
        }
    }


}
