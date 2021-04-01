using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler
{
    class PascalCommentFinder
    {
        private static char state;

        private static bool IsM(char symbol)
        {
            if (symbol == '('  || symbol == ')' || symbol == '*' || symbol == '{' || symbol == '}')
                return true;
            else
                return false;
        }
        private static bool Isa(char symbol)
        {
            return !IsM(symbol);
        }
        private static bool Check(string input, char state)
        {
            for (int i = 0; i < input.Length; i++)
            {
                switch (state)
                {
                    case 'I': { if (input[i] == '{') state = 'K'; else if (input[i] == '(') state = 'D'; else return false; break; }
                    case 'K':
                        {
                            if (input[i] == '}')
                                return Check(input.Substring(i + 1, input.Length - i - 1), 'K') || Check(input.Substring(i + 1, input.Length - i - 1), 'F');
                            else state = 'K'; break;
                        }
                    case 'D': { if (input[i] == '*') state = 'C'; else return false; break; }
                    case 'C':
                        {
                            if (input[i] == '*')
                                return Check(input.Substring(i + 1, input.Length - i - 1), 'C') || Check(input.Substring(i + 1, input.Length - i - 1), 'E');
                            else state = 'C'; break;
                        }
                    case 'E': { if (input[i] == ')') state = 'F'; else return false; break; }
                    default:
                        return false;
                }
            }
            if (state == 'F')
                return true;
            else
                return false;
        }
        public static bool CheckString(string input)
        {
            return Check(input, 'I');
        }
    }
}