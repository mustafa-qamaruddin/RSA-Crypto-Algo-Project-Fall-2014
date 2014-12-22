using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RSA_Encryption
{
    class Stringer
    {
        public BigInteger chartoascii(string input)
        {
            BigInteger ret = new BigInteger();
            for (int i = 0; i < input.Length; i++)
            {
                int dig1 = (int)input[i] / 100;
                int dig2 = ((int)input[i] % 100 ) / 10;
                int dig3 = (int)input[i] % 10;
                ret.get_data().insert(dig1);
                ret.get_data().insert(dig2);
                ret.get_data().insert(dig3);
                // Console.WriteLine("{0} - {1} - {2}", dig1, dig2, dig3);
            }
            return ret;
        }

        public string asciitochars(string input)
        {
            Console.WriteLine(input);
            string ret = "";
            for (int i = 0; i < input.Length; i+=3)
            {
                int ascii = 100 * (input[i] - '0');
                if(i+1 < input.Length)
                    ascii += 10 * (input[i+1] - '0');
                if (i + 2 < input.Length)
                    ascii += (input[i+2] - '0');
                ret += (char)ascii;
            }
            return ret;
        }
    }
}
