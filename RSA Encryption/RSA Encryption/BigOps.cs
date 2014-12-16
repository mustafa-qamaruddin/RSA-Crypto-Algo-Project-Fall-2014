using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RSA_Encryption
{
    class BigOps
    {
        public string add(BigInteger A, BigInteger B)
        {
            Vector C = new Vector();

            int carry = 0;
            for (int i = max_padd_AB(A, B) - 1; i >= 0; i--)
            {
                int sum = A.get_data().at(i) + B.get_data().at(i) + carry;
                if (sum > 9)
                {
                    carry = 1;
                    sum = sum % 10;
                }
                else
                {
                    carry = 0;
                }
                C.insert(sum);
            }

            if (carry != 0)
                C.insert(carry);

            C.display();

            return C.toVString();
        }

        public string add(BigInteger A, int x)
        {
            return add(A, new BigInteger(x.ToString()));
        }

        /**
         * Careful: it padds the smaller to the difference
         * **/
        public int max_padd_AB(BigInteger A, BigInteger B)
        {
            int szA = A.get_data().get_size();
            int szB = B.get_data().get_size();

            if (szB > szA)
            {
                // padd A with difference
                A.padd(Math.Abs(szB - szA));
                return B.get_data().get_size();
            }
            else
            {
                // padd B with difference
                B.padd(Math.Abs(szB - szA));
                return A.get_data().get_size();
            }
        }

        public string sub_wrong(BigInteger A, BigInteger B)
        {
            Vector C = new Vector();

            B.set_mode(true); // twos complement mode
            BigInteger Z = new BigInteger(add(B, 1));

            return add(A, Z);
        }

        public int power(int b, int p)
        {
            if (p == 0)
                return 1;
            else if (p == 1)
                return b;
            else
            {
                int ret = power(b, p / 2);
                if (p % 2 == 0)
                    return ret * ret;
                else
                    return ret * ret * b;
            }
        }

        public string sub(BigInteger A, BigInteger B)
        {
            Vector C = new Vector();

            int borrow = 0;
            int position = 0;
            int base_n = 10;
            for (int i = max_padd_AB(A, B) - 1; i >= 0; i--)
            {
                int x = A.get_data().at(i);
                if (borrow != 0)
                {
                    x = x - 1;
                }
                int y = B.get_data().at(i);
                if (x < y)
                {
                    // use borrow
                    borrow = power(base_n, position);
                    x = borrow + x;
                }
                else
                {
                    borrow = 0;
                }
                int diff =  x - y;
                
                C.insert(diff);
            }

            C.display();

            return C.toVString();
        }
    }
}
