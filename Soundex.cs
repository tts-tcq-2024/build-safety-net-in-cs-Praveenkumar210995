using System;
using System.Collections.Generic;
using System.Text;

namespace SoundexCheck
{
    public class Soundex
    {

        private static void AppendCode(string name, StringBuilder soundex, char prevCode)
        {
            for (int i = 1; i < name.Length && soundex.Length < 4; i++)
            {
                char code = GetCode(name[i]);
                if (IsValidCode(code, prevCode))
                {
                    soundex.Append(code);
                    prevCode = code;
                }
            }
        }

        private static char GetCode(char c)
        {
            char code;
            c = char.ToUpper(c);
            var soundexMap = new Dictionary<char, char>
            {
                {'B', '1'}, {'F', '1'}, {'P', '1'}, {'V', '1'},
                {'C', '2'}, {'G', '2'}, {'J', '2'}, {'K', '2'},
                {'Q', '2'}, {'S', '2'}, {'X', '2'}, {'Z', '2'},
                {'D', '3'}, {'T', '3'},
                {'L', '4'},
                {'M', '5'}, {'N', '5'},
                {'R', '6'}
            };

            return soundexMap.TryGetValue(c, out code) ? code : '0';
        }

        private static bool IsValidCode(char code, char prevCode)
        {
            return code != 0 && code != prevCode;
        }

        private static void AddZero(StringBuilder soundex)
        {
            while (soundex.Length < 4)
            {
                soundex.Append(0);
            }
        }

        public static string GenerateSoundex(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return string.Empty;
            }

            StringBuilder soundex = new StringBuilder();
            soundex.Append(char.ToUpper(name[0]));
            char prevCode = GetCode(name[0]);

            AppendCode(name, soundex, prevCode);

            AddZero(soundex);

            return soundex.ToString();
        }
    }
}
