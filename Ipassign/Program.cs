using System;
using System.Collections.Generic;
using System.Linq;

namespace Ipassign
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                String proxy;
                int octet;
                Console.WriteLine("Enter Proxy");
                proxy = Console.ReadLine();
                Console.WriteLine("Enter Octal Number");
                octet = Convert.ToInt16(Console.ReadLine());
                Console.WriteLine("---------------");
                var sepearteproxy = new int[4];

                sepearteproxy = MethodToSeparateProxy(proxy);



                List<internet> internets = new List<internet>()
                                               {
                                                   new internet()
                                                       {
                                                           Octal =
                                                               new List<int>()
                                                                   {
                                                                       1,
                                                                       9,
                                                                       17,
                                                                       25
                                                                   },
                                                           Subnetmask = 128,
                                                           Incorder = 128
                                                       },
                                                   new internet()
                                                       {
                                                           Octal =
                                                               new List<int>()
                                                                   {
                                                                       2,
                                                                       10,
                                                                       18,
                                                                       26
                                                                   },
                                                           Subnetmask = 192,
                                                           Incorder = 64
                                                       },
                                                   new internet()
                                                       {
                                                           Octal =
                                                               new List<int>()
                                                                   {
                                                                       3,
                                                                       11,
                                                                       19,
                                                                       27
                                                                   },
                                                           Subnetmask = 224,
                                                           Incorder = 32
                                                       },
                                                   new internet()
                                                       {
                                                           Octal =
                                                               new List<int>()
                                                                   {
                                                                       4,
                                                                       12,
                                                                       20,
                                                                       28
                                                                   },
                                                           Subnetmask = 240,
                                                           Incorder = 16
                                                       },
                                                   new internet()
                                                       {
                                                           Octal =
                                                               new List<int>()
                                                                   {
                                                                       5,
                                                                       13,
                                                                       21,
                                                                       29
                                                                   },
                                                           Subnetmask = 248,
                                                           Incorder = 8
                                                       },
                                                   new internet()
                                                       {
                                                           Octal =
                                                               new List<int>()
                                                                   {
                                                                       6,
                                                                       14,
                                                                       22,
                                                                       30
                                                                   },
                                                           Subnetmask = 252,
                                                           Incorder = 4
                                                       },
                                                   new internet()
                                                       {
                                                           Octal =
                                                               new List<int>()
                                                                   {
                                                                       7,
                                                                       15,
                                                                       23,
                                                                       31
                                                                   },
                                                           Subnetmask = 254,
                                                           Incorder = 2
                                                       },
                                                   new internet()
                                                       {
                                                           Octal =
                                                               new List<int>()
                                                                   {
                                                                       8,
                                                                       16,
                                                                       24,
                                                                       32
                                                                   },
                                                           Subnetmask = 255,
                                                           Incorder = 1
                                                       },
                                               };


                var f = from x in internets from y in x.Octal where y.Equals(octet) select x;


                foreach (var internet in f)
                {
                    if (octet <= 8 && octet > 0)
                    {
                        Console.WriteLine("Subnet Mask .:{0}.0.0.0\n", internet.Subnetmask);
                        var j = sepearteproxy[0] / internet.Incorder;
                        Console.WriteLine("Network Address .:{0}.0.0.0\n", j * internet.Incorder);
                        Console.WriteLine("First Address.:{0}.0.0.1\n", j * internet.Incorder);
                        Console.WriteLine(
                            "Last Address.:{0}.255.255.254\n", j * internet.Incorder + internet.Incorder - 1);
                        Console.WriteLine(
                            "Broadcast Address.:{0}.255.255.255", (j * internet.Incorder) + internet.Incorder - 1);
                    }
                    else if (octet <= 16 && octet > 8)
                    {
                        Console.WriteLine("Subnet Mask .:255.{0}.0.0\n", internet.Subnetmask);
                        var j = sepearteproxy[1] / internet.Incorder;
                        Console.WriteLine("Network Address .:{0}.{1}.0.0\n", sepearteproxy[0], j * internet.Incorder);
                        Console.WriteLine("First Address.:{0}.{1}.0.1\n", sepearteproxy[0], j * internet.Incorder);
                        Console.WriteLine(
                            "Last Address.:{0}.{1}.255.254\n",
                            sepearteproxy[0],
                            (j * internet.Incorder) + internet.Incorder - 1);
                        Console.WriteLine(
                            "Broadcast Address.:{0}.{1}.255.255",
                            sepearteproxy[0],
                            (j * internet.Incorder) + internet.Incorder - 1);

                    }
                    else if (octet <= 24 && octet > 16)
                    {
                        Console.WriteLine("Subnet Mask .:255.255.{0}.0\n", internet.Subnetmask);
                        var j = sepearteproxy[2] / internet.Incorder;
                        Console.WriteLine(
                            "Network Address .:{0}.{1}.{2}.0\n",
                            sepearteproxy[0],
                            sepearteproxy[1],
                            j * internet.Incorder);
                        Console.WriteLine(
                            "First Address.:{0}.{1}.{2}.1\n", sepearteproxy[0], sepearteproxy[1], j * internet.Incorder);
                        Console.WriteLine(
                            "Last Address.:{0}.{1}.{2}.254\n",
                            sepearteproxy[0],
                            sepearteproxy[1],
                            (j * internet.Incorder) + internet.Incorder - 1);
                        Console.WriteLine(
                            "Broadcast Address.:{0}.{1}.{2}.255",
                            sepearteproxy[0],
                            sepearteproxy[1],
                            (j * internet.Incorder) + internet.Incorder - 1);
                    }
                    else if (octet <= 32 && octet > 24)
                    {
                        Console.WriteLine("Subnet Mask .:255.255.255.{0}\n", internet.Subnetmask);
                        var j = sepearteproxy[3] / internet.Incorder;
                        Console.WriteLine(
                            "Network Address .:{0}.{1}.{2}.{3}\n",
                            sepearteproxy[0],
                            sepearteproxy[1],
                            sepearteproxy[2],
                            j * internet.Incorder);
                        Console.WriteLine(
                            "First Address.:{0}.{1}.{2}.{3}\n",
                            sepearteproxy[0],
                            sepearteproxy[1],
                            sepearteproxy[2],
                            (j * internet.Incorder )+ 1);
                        Console.WriteLine(
                            "Last Address.:{0}.{1}.{2}.{3}\n",
                            sepearteproxy[0],
                            sepearteproxy[1],
                            sepearteproxy[2],
                            (j * internet.Incorder) + (internet.Incorder - 1)-1);
                        Console.WriteLine(
                            "Broadcast Address.:{0}.{1}.{2}.{3}",
                            sepearteproxy[0],
                            sepearteproxy[1],
                            sepearteproxy[2],
                            (j * internet.Incorder) + internet.Incorder-1);
                    }


                }

                Console.WriteLine("Continue");
                string con =Console.ReadLine();
                if (con.Equals("end"))
                {
                    break;
                }
            }
        }

        private static int[] MethodToSeparateProxy(string proxy)
        {
            var sepearteproxy = new int[4];
            var ss = proxy.Split(new char[] { '.' }, proxy.Length);
            for (int h = 0; h < ss.Length; h++)
            {
                
                sepearteproxy[h] = Convert.ToInt32(ss[h]);
               // Console.WriteLine(sepearteproxy[h]);
            }
            return sepearteproxy;
        }
    }
    class internet
    {
        public List<int> Octal { get; set; }

        public int Subnetmask { get; set; }

        public int Incorder { get; set; }
    }
}
