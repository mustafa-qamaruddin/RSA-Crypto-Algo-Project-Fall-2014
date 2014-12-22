using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;

namespace RSA_Encryption
{
    class Files
    {
        public void read()
        {
            try
            {
                string line;

                // Read the file and display it line by line.
                //StreamReader file = new StreamReader(@"C://rsa/files/in/input.in");
                //StreamReader file = new StreamReader(@"C://rsa/files/in/test.in");
                StreamReader file = new StreamReader(@"C://rsa/files/in/strings.txt");
                line = file.ReadLine(); // first line # tc
                if (line != null)
                {
                    string mydocpath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                    FileStream fs = File.Create(mydocpath + @"\rsa\files\out\output_" + DateTime.Now.ToFileTime() + ".out");
                    int tc = Convert.ToInt32(line);
                    for (int i = 1; i <= tc; i++)
                    {
                        line = file.ReadLine(); // N
                        BigInteger N = new BigInteger(line);
                        line = file.ReadLine(); // e or d
                        long eord = Convert.ToInt64(line);
                        line = file.ReadLine(); // M or E(M)
                        // BigInteger MEM = new BigInteger(line); // numbers mode
                        BigInteger MEM = (new Stringer()).chartoascii(line); // ASCII mode

                        line = file.ReadLine(); // 0 or 1 (0-> encrypt, 1-> decrypt)
                        int mode = Convert.ToInt32(line);

                        
                        RSA rsa = new RSA();
                        int before = System.Environment.TickCount;
                        if (mode == 0)
                        {
                            string EM = rsa.encode(MEM, eord, N).get_data().toFString(); // numbers mode
                            EM = (new Stringer()).asciitochars(EM); // ASCII mode
                            line = String.Format("CASE#{0}: M={1}, e={2}, n={3}, E(M)={4}", i,MEM.get_data().toFString(), eord, N.get_data().toFString(), EM);
                        }
                        else if (mode == 1)
                        {
                            String M = rsa.decode(MEM, eord, N).get_data().toFString(); // numbers mode
                            M = (new Stringer()).asciitochars(M); // ASCII mode
                            line = String.Format("CASE#{0}: E(M)={1}, d={2}, n={3}, M={4}", i, MEM.get_data().toFString(), eord, N.get_data().toFString(), M);
                        }
                        int after = System.Environment.TickCount;
                        Console.WriteLine("Case#{0}: Runtime = {1}",i, after - before);
                        Console.WriteLine(line);
                        Byte[] info = new UTF8Encoding(true).GetBytes(line);
                        fs.Write(info, 0, line.Length);
                    }
                    fs.Close();
                }

                file.Close();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
