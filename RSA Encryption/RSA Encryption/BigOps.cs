using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RSA_Encryption
{
    class BigOps
    {
        public string add_ret_str(BigInteger A, BigInteger B)
        {
            BigInteger ret = add(A, B);
            return ret.get_data().toFString();
        }

        public BigInteger add(BigInteger A, int x)
        {
            return add(A, new BigInteger(x.ToString()));
        }

        public BigInteger add(BigInteger A, BigInteger B)
        {
            BigInteger ret = new BigInteger("");

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
                ret.get_data().insert(sum);
            }

            if (carry != 0)
                ret.get_data().insert(carry);

            // ret.get_data().display();
            ret.get_data().reverse();
            ret.trim();
            return ret;
        }

        /**
         * Careful: it padds the smaller to the difference
         * **/
        public int max_padd_AB(BigInteger A, BigInteger B, bool bl_Padding = true)
        {
            int szA = A.get_data().get_size();
            int szB = B.get_data().get_size();

            if (szB > szA)
            {
                // padd A with difference
                if (bl_Padding)
                {
                    A.padd(Math.Abs(szB - szA));
                }
                return szB;
            }
            else
            {
                // padd B with difference
                if (bl_Padding)
                {
                    B.padd(Math.Abs(szB - szA));
                }
                return szA;
            }
        }

        public string sub_wrong(BigInteger A, BigInteger B)
        {
            Vector C = new Vector();

            B.set_mode(true); // twos complement mode
            BigInteger Z = add(B, 1);

            return add_ret_str(A, Z);
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

        public string sub_ret_str(BigInteger A, BigInteger B)
        {
            BigInteger ret = sub(A, B);
            return ret.get_data().toFString();
        }

        public BigInteger sub(BigInteger A, BigInteger B)
        {
            if (A < B)
                return sub(B, A);
            BigInteger ret = new BigInteger("");

            int borrow = 0;
            int base_n = 10;
            for (int i = max_padd_AB(A, B) - 1; i >= 0; i--)
            {
                int x = A.get_data().at(i);
                if (borrow != 0)
                {
                    if (A.get_data().at(i) == 0)
                    {
                        x = base_n - 1;  // 0 borrowed 10 from i-1, then lent one to i+1 = 9
                    }
                    else
                    {
                        x = x - 1;
                        borrow = 0;
                    }
                }
                int y = B.get_data().at(i);
                if (x < y)
                {
                    if (i == 0)
                    {
                        throw new Exception("Unsupported Op.");
                    }
                    // use borrow
                    borrow = base_n;
                    x = borrow + x;
                }
                else
                {
                    // borrow = 0;
                }
                int diff = x - y;

                ret.get_data().insert(diff);
            }

            // ret.get_data().display();
            ret.get_data().reverse();
            ret.trim();
            return ret;
        }

        /**********************************
           div(a, b) 
            {
                if (a < b)
                    return (0, a)
                (q, r) = div(a, 2b)
                q = 2q
                if (r < b)
                    return (q, r)
                else
                    return (q + 1, r - b)
            }
        **/
        public BigInteger[] div(BigInteger A, BigInteger B)
        {
            BigInteger[] ret = new BigInteger[2];
            if (A < B){
                ret[0] = new BigInteger("0");
                ret[1] = A;
                return ret;
            }
            ret = div(A, mul_base_case(B, 2));
            ret[0] = mul_base_case(ret[0], 2);
            if (ret[1] < B)
            {
                return ret;
            }
            else
            {
                ret[0] = add(ret[0], 1);
                ret[1] = sub(ret[1], B);
            }
            return ret;
        }

        /*********************************************
         * Karatsuba T(N) = 3 T(N/2) + Constant * N + Constant
         * *******************************************
         * 1. Base Case : X OR Y contains one digit
         * 1. divide : x -> a & b
         *             y -> c & d
         * 2.          a_plus_b = a+b
         *             c_plus_d = c+d
         *             
         * 3. recurse: ac = mul(a, c)
         *             bd = mul(b, d)
         *             z = mul(a_plus_b, c_plus_d)
         *             
         * 4. combine: sub_r = sub(z, ac)
         *             r = sub(sub_r, bd)
         *             padd(ac, N, 0)
         *             padd(r, N/2, 0)
         *             ret = r + ac + bd
         *
         **/
        public BigInteger mul(BigInteger X, BigInteger Y)
        {
            int n = max_padd_AB(X, Y, true);

            if (X.get_data().get_size() == 1)
            {
                return mul_base_case(Y, X.get_data().at(0));
            }
            else if (Y.get_data().get_size() == 1)
            {
                return mul_base_case(X, Y.get_data().at(0));
            }

            BigInteger ret = new BigInteger("");

            BigInteger a = new BigInteger(), b = new BigInteger(), c = new BigInteger(), d = new BigInteger();

            X.slice(ref a, 0, n - (n / 2));
            X.slice(ref b, n - (n / 2), n);

            Y.slice(ref c, 0, n - (n / 2));
            Y.slice(ref d, n - (n / 2), n);
            X.trim(); Y.trim();
            a.trim(); b.trim(); c.trim(); d.trim();

            BigInteger a_plus_b = add(a, b),
            c_plus_d = add(c, d);

            BigInteger ac = mul(a, c), bd = mul(b, d), z = mul(a_plus_b, c_plus_d);

            // Gauss: 3 - 2 - 1
            z = sub(z, bd);
            z = sub(z, ac);

            shl(ref ac, n);
            shl(ref z, n/2);

            ret = add(ac, bd);
            ret = add(z, ret);

            return ret;
        }

        public BigInteger mul_base_case(BigInteger X, int y)
        {
            BigInteger ret = new BigInteger("0");
            for (int i = 0; i < y; i++)
            {
                ret = add(X, ret);
            }
            return ret;
        }

        // shift left n times := A * 10 ^ n
        public void shl(ref BigInteger A, int cnt)
        {
            for (int i = 0; i < cnt; i++)
            {
                A.get_data().insert(0);
            }
        }

        public BigInteger exp(BigInteger B, long E)
        {
            if (E == 0)
                return new BigInteger("1");
            else if (E == 1)
                return B;
            else
            {
                BigInteger acc = exp(B, E / 2);
                if (E % 2 == 0)
                {
                    return mul(acc, acc);
                }
                else
                {
                    return mul(acc, mul(acc, B));
                }
            }
        }
    }
}
