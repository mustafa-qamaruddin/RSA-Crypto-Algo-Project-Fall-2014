using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RSA_Encryption
{
    class UnitTesting
    {
        public void test_worst_case_quick_sort()
        {
            Vector test = new Vector();
            for (int i = 1000000; i > 0; i--)
            {
                test.insert(i);
            }

            test.init_indices();
            test.quick_sort(0, 1000000 - 1);
        }

        public void test_average_case_quick_sort()
        {
            Vector test = new Vector();
            for (int i = 3; i > 0; i--)
            {
                test.insert(i);
            }

            test.init_indices();
            test.quick_sort(0, 10 - 1);
            test.display_sorted();
        }

        public void test_vector_insert_sorted()
        {
            Vector test = new Vector();
            for (int i = 30; i > 0; i /= 2)
            {
                test.insert(i);
            }

            test.insert_sorted(22);
            test.display_sorted();
        }

        public void test_vector_delete()
        {
            Vector test = new Vector();
            for (int i = 30; i > 0; i--)
            {
                test.insert(i);
            }

            test.remove(5);
            test.remove(1000);
            test.sort();
            test.remove_by_value(12); // must be sorted
            test.display();
        }

        public void test_vector_reverse()
        {
            Vector test = new Vector();
            for (int i = 30; i > 0; i /= 2)
            {
                test.insert(i);
            }

            test.display();
            test.reverse();
            test.display();
        }

        public void test_vector()
        {
            // test_worst_case_quick_sort();
            // test_average_case_quick_sort();
            // test_vector_insert_sorted();
            // test_vector_delete();
            // test_vector_reverse();
        }

        public void test_bigint()
        {
            // test_bigint_constr();
            // test_bigint_add();
            // test_bigint_sub();
            // test_bigint_parity();
            // test_bigint_halve();
            // test_bigint_slice();
            // test_bigint_mul();
            // test_bigint_lt();
            // test_bigint_div();
            // test_bigint_exp();
        }

        public void test_bigint_constr()
        {
            string x = Console.ReadLine();
            string y = Console.ReadLine();
            BigInteger bx = new BigInteger(x);
            BigInteger by = new BigInteger(y);
            bx.get_data().display();
            by.get_data().display();
        }

        /**
        4108597
        3378905

        2517819
        300217

        99999
        9999999

        9999999
        9999999
         ***/
        public void test_bigint_add()
        {
            string x = Console.ReadLine();
            string y = Console.ReadLine();
            BigInteger bx = new BigInteger(x);
            BigInteger by = new BigInteger(y);
            bx.get_data().display();
            by.get_data().display();
            BigOps bops = new BigOps();
            Console.WriteLine(bops.add(bx, by).get_data().toVString());
        }

        public void test_bigint_sub()
        {
            string x = Console.ReadLine();
            string y = Console.ReadLine();
            BigInteger bx = new BigInteger(x);
            BigInteger by = new BigInteger(y);
            bx.get_data().display();
            by.get_data().display();
            BigOps bops = new BigOps();
            Console.WriteLine(bops.sub(bx, by).get_data().toVString());
        }

        public void test_bigint_parity()
        {
            string x = Console.ReadLine();
            BigInteger bx = new BigInteger(x);
            Console.WriteLine(bx.check_parity());
        }

        public void test_bigops()
        {
            // test_bigops_power();
        }

        public void test_bigops_power()
        {
            BigOps bops = new BigOps();
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine("{0} : {1}", i, bops.power(3, i));
            }
        }

        public void test_bigint_halve()
        {
            string x = Console.ReadLine();
            string y = Console.ReadLine();
            BigInteger bx = new BigInteger(x);
            BigInteger by = new BigInteger(y);
            BigInteger a = new BigInteger(), b = new BigInteger(), c = new BigInteger(), d = new BigInteger();
            bx.get_data().display();
            by.get_data().display();
            bx.halve(ref a, ref b);
            by.halve(ref c, ref d);

            Console.WriteLine("First First Half");
            a.get_data().display();
            Console.WriteLine("First Second Half");
            b.get_data().display();
            Console.WriteLine("Second First Half");
            c.get_data().display();
            Console.WriteLine("Second Second Half");
            d.get_data().display();
        }

        public void test_bigint_mul()
        {
            string x = Console.ReadLine();
            string y = Console.ReadLine();
            BigInteger bx = new BigInteger(x);
            BigInteger by = new BigInteger(y);

            BigOps bops = new BigOps();
            Console.WriteLine(bops.mul(bx, by).get_data().toFString());
        }

        public void test_bigint_slice()
        {
            string x = Console.ReadLine();
            string y = Console.ReadLine();
            BigInteger bx = new BigInteger(x);
            BigInteger by = new BigInteger(y);
            BigInteger a = new BigInteger(), b = new BigInteger(), c = new BigInteger(), d = new BigInteger();
            bx.get_data().display();
            by.get_data().display();

            BigOps bops = new BigOps();
            int n = bops.max_padd_AB(bx, by, true);

            Console.Write("M:");
            Console.Write(n);

            bx.slice(ref a, 0, n-(n/2));
            bx.slice(ref b, n - (n / 2), n);

            by.slice(ref c, 0, n - (n / 2));
            by.slice(ref d, n - (n / 2), n);

            a.trim(); b.trim(); c.trim(); d.trim();

            Console.WriteLine("First First Half");
            a.get_data().display();
            Console.WriteLine("First Second Half");
            b.get_data().display();
            Console.WriteLine("Second First Half");
            c.get_data().display();
            Console.WriteLine("Second Second Half");
            d.get_data().display();
        }

        public void test_bigint_lt()
        {
            string x = Console.ReadLine();
            string y = Console.ReadLine();
            BigInteger bx = new BigInteger(x);
            BigInteger by = new BigInteger(y);

            if (bx < by)
                Console.Write("x < y");
            else
                Console.Write("x >= y");
            
        }

        public void test_bigint_div()
        {
            string x = Console.ReadLine();
            string y = Console.ReadLine();
            BigInteger bx = new BigInteger(x);
            BigInteger by = new BigInteger(y);

            BigOps bops = new BigOps();
            BigInteger[] ret = bops.div(bx, by);
            Console.WriteLine("q:{0}", ret[0].get_data().toFString());
            Console.WriteLine("r:{0}", ret[1].get_data().toFString());
        }

        public void test_bigint_exp()
        {
            string x = Console.ReadLine();
            long e = Console.Read();
            BigInteger bx = new BigInteger(x);
            

            BigOps bops = new BigOps();
            Console.WriteLine(bops.exp(bx,e).get_data().toFString());
        }

        public void test_rsa()
        {
            // test_rsa_encode();
            // test_rsa_decode();
        }

        public void test_rsa_encode()
        {
            RSA rsa = new RSA();
            string m = Console.ReadLine();
            string n = Console.ReadLine();
            BigInteger M = new BigInteger(m);
            long e = Console.Read();
            
            BigInteger nb = new BigInteger(n);
            Console.WriteLine(rsa.encode(M, e, nb).get_data().toFString());
        }

        public void test_rsa_decode()
        {
            RSA rsa = new RSA();
            string em = Console.ReadLine();
            string n = Console.ReadLine();
            BigInteger EM = new BigInteger(em);
            long d = Console.Read();

            BigInteger nb = new BigInteger(n);
            Console.WriteLine(rsa.encode(EM, d, nb).get_data().toFString());
        }

        public void test_files()
        {
            test_files_read();
        }

        public void test_files_read() {
            Files f = new Files();
            f.read();
        }

        public void test_stringer()
        {
            // test_stringer_chartoascii();
            // test_stringer_asciitochars();
        }

        public void test_stringer_chartoascii() {
            string x = Console.ReadLine();
            Stringer s = new Stringer();
            Console.WriteLine(s.chartoascii(x).get_data().toFString());
        }

        public void test_stringer_asciitochars()
        {
            string x = Console.ReadLine();
            Stringer s = new Stringer();
            Console.WriteLine(s.asciitochars(x));
        }
    }
}
