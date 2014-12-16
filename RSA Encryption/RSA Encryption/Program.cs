using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RSA_Encryption
{
    class Program
    {
        static void Main(string[] args)
        {
            UnitTesting ut = new UnitTesting();
            ut.test_vector();
            ut.test_bigint();
            ut.test_bigops();
        }
    }
}
