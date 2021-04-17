using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler
{
    class CharChain
    {
        private char[] chars;
        private int index;
         
        public CharChain(string text)
        {
            chars = text.ToCharArray();
            index = 0;
        }

        public char GetNext()
        {
            if(index == chars.Length)
            {
                return '\0';
            }

            char result = chars[index];
            index++;
            return result;
        }
    }
}
