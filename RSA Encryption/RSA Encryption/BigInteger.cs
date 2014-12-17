using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RSA_Encryption
{
    class BigInteger
    {
        public BigInteger(string a)
        {
            bops = new BigOps();
            data = new Vector();
            for (int i = 0; i < a.Length; i++)
            {
                data.insert(a[i] - '0');
            }
        }

        public Vector twos_complement()
        {
            Vector complement = new Vector();
            for (int i = 0; i < data.get_size(); i++)
            {
                complement.insert(9 - data.at(i));
            }
            complement.display();

            return complement;
        }

        public void padd(int count)
        {
            for (int i = 0; i < count; i++)
            {
                data.push_front(0);
            }
        }

        /**
         * mode = false ; normal
         * mode = true  ; complement
         * **/
        public Vector get_data()
        {
            if (mode)
                return twos_complement();
            else
                return data;
        }

        public void set_mode(bool _mode)
        {
            mode = _mode;
        }

        //0 = even
        //1 = odd
        public int check_parity()
        {
            int x = data.at(data.get_size() - 1);
            return (x % 2);
        }

        private Vector data;
        /**
         * mode = false ; normal
         * mode = true  ; complement
         * **/
        private bool mode;

        BigOps bops; // object composition
    }
}
