using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class Algorithm
    {
        public static List<string> DealInput(string input)
        {
            List<string> ret = new List<string>();
            do
            {
                int pos = input.IndexOfAny(new char[] { '+', '-', '*', '/', '%', '(', ')' });
                if (pos == -1)
                {
                    ret.Add(input);
                    break;
                }
                if (pos != 0)
                    ret.Add(new string(input.ToCharArray(), 0, pos));
                if (pos == 0 && (input[pos] == '+' || input[pos] == '-'))
                {
                    char ch = input[0];
                    input = input.Remove(0, 1);
                    int index = input.IndexOfAny(new char[] { '+', '-', '*', '/', '%', '(', ')' });
                    if (index != -1)
                    {
                        string str = new string(input.ToCharArray(), 0, index);
                        input = input.Remove(0, index);
                        string tmp = "(0" + ch.ToString() + str + ")";
                        input = tmp + input;
                    }
                    else
                    {
                        input = "(0" + ch.ToString() + input + ")";
                    }
                    continue;
                }
                ret.Add(input[pos].ToString());
                input = input.Remove(0, pos + 1);
            } while (input.Length != 0);
            return ret;
        }

        public static List<string> MidToBack(List<string> list)
        {
            Stack<string> s = new Stack<string>();
            List<string> ret = new List<string>();
            foreach (string str in list)
            {
                if (str.IndexOfAny(new char[] { '+', '-', '*', '/', '%', '(', ')' }) == -1)
                {
                    ret.Add(str);
                }
                else
                {
                    if (s.Count == 0)
                    {
                        s.Push(str);
                    }
                    else
                    {
                        if (str[0] == '(')
                        {
                            s.Push(str);
                        }
                        else if (str[0] == '*' || str[0] == '/' || str[0] == '%')
                        {
                            s.Push(str);
                        }
                        else if (str[0] == '+' || str[0] == '-')
                        {
                            while (s.Count != 0 && s.Peek()[0] != '(')
                            {
                                ret.Add(s.Pop());
                            }
                            s.Push(str);
                        }
                        else
                        {
                            while (s.Count != 0 && s.Peek()[0] != '(')
                            {
                                ret.Add(s.Pop());
                            }
                            s.Pop();
                        }
                    }
                }
            }
            while (s.Count != 0)
            {
                ret.Add(s.Pop());
            }
            return ret;
        }

        public static double GetValueByBack(List<string> list)
        {
            double ret = 0;
            Stack<string> s = new Stack<string>();
            foreach (string str in list)
            {
                if (str.IndexOfAny(new char[] { '+', '-', '*', '/', '%', '(', ')' }) == -1)
                {
                    s.Push(str);
                }
                else
                {
                    string s2 = s.Pop();
                    string s1 = s.Pop();
                    switch (str[0])
                    {
                        case '+':
                            s.Push((Convert.ToDouble(s1) + Convert.ToDouble(s2)).ToString());
                            break;
                        case '-':
                            s.Push((Convert.ToDouble(s1) - Convert.ToDouble(s2)).ToString());
                            break;
                        case '*':
                            s.Push((Convert.ToDouble(s1) * Convert.ToDouble(s2)).ToString());
                            break;
                        case '/':
                            s.Push((Convert.ToDouble(s1) / Convert.ToDouble(s2)).ToString());
                            break;
                        case '%':
                            s.Push(((int)Convert.ToDouble(s1) % (int)Convert.ToDouble(s2)).ToString());
                            break;
                        default:
                            throw new Exception(string.Format("未知运算符: {0}", str));
                    }
                }
            }
            ret = Convert.ToDouble(s.Pop());
            return ret;
        }
    }
}
