using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RSA_Encryption
{
    class BigInteger
    {
        public BigInteger(string a = "")
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

        /*
         * [from, to[
         **/
        public bool slice(ref BigInteger ret, int from, int to)
        {
            if( to < from)
                return false;
            for (int i = from; i < to; i++)
            {
                ret.get_data().insert(data.at(i));
            }
            return true;
        }

        public bool halve(ref BigInteger p1, ref BigInteger p2)
        {
            return slice(ref p1, 0, data.get_size()/2) && slice(ref p2, data.get_size()/2, data.get_size() );
        }

        public static bool operator< (BigInteger lhs, BigInteger rhs)
        {
            lhs.trim();
            rhs.trim();
            if (lhs.get_data().get_size() < rhs.get_data().get_size())
            {
                return true;
            }
            else if (lhs.get_data().get_size() > rhs.get_data().get_size())
            {
                return false;
            }
            else
            {
                int i = 0;
                while (i < lhs.get_data().get_size() && lhs.get_data().at(i) == rhs.get_data().at(i))
                {
                    i++;
                }
                return (lhs.get_data().at(i) < rhs.get_data().at(i));
            }
        }

        public static bool operator >(BigInteger lhs, BigInteger rhs)
        {
            lhs.trim();
            rhs.trim();
            if (lhs.get_data().get_size() > rhs.get_data().get_size())
            {
                return true;
            }
            else if (lhs.get_data().get_size() < rhs.get_data().get_size())
            {
                return false;
            }
            else
            {
                int i = 0;
                while (i < lhs.get_data().get_size() && lhs.get_data().at(i) == rhs.get_data().at(i))
                {
                    i++;
                }
                return (lhs.get_data().at(i) > rhs.get_data().at(i));
            }
        }

        public void trim()
        {
            while (data.get_size() > 1 && data.at(0) == 0)
            {
                data.pop_front();
            }
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
