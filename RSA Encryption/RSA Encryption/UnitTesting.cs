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

        public void test_vector()
        {
            // test_worst_case_quick_sort();
            // test_average_case_quick_sort();
            // test_vector_insert_sorted();
            // test_vector_delete();
        }

        public void test_bigint()
        {
            // test_bigint_constr();
            // test_bigint_add();
            // test_bigint_sub();
            test_bigint_parity();
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
            Console.WriteLine(bops.add(bx, by));
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
            Console.WriteLine(bops.sub(bx, by));
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
    }
}
