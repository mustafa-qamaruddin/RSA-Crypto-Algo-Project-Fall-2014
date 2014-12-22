using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RSA_Encryption
{
    class RSA
    {
        public RSA()
        {
            bops = new BigOps();
        }
        // E(M) = M^e mod n
        public BigInteger encode(BigInteger M, long e, BigInteger n)
        {
            BigInteger i = bops.exp(M, e);
            BigInteger[] arr = bops.div(i, n);
            return arr[1];
        }

        // M = E(M)^d mod n.
        public BigInteger decode(BigInteger EM, long d, BigInteger n)
        {
            BigInteger i = bops.exp(EM, d);
            BigInteger[] arr = bops.div(i, n);
            return arr[1];
        }

        private BigOps bops;
    }
}
