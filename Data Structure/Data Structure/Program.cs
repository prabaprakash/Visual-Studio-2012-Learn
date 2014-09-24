using System;
using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;

namespace Data_Structure
{
    internal class Program
    {
        //Method 1 - Seperate Words
        //static void Main(string[] args)
        //{
        //    string string1 = "Of course if we were going to actually use this algorithm in 7 ";

        //    int i = 0;
        //    Console.WriteLine(string1.Length);
        //    int pos = string1.IndexOf(" ");
        //    ArrayList word=new ArrayList();
        //    Task<ArrayList> task = GetValue(pos, string1);
        //    //var awa= task.GetAwaiter();
        //    word = task.Result;
        //    string[] s;
        //    char[] d=new char[]{' '};
        //    s = string1.Split(d,string1.Length);
        //    foreach (var s1 in s)
        //    {
        //        Console.WriteLine(s1);
        //    }
        //    foreach (var VARIABLE in word)
        //    {
        //        Console.WriteLine(VARIABLE);
        //    }

        //    Console.ReadLine();
        //}

        //public static Task<ArrayList> GetValue(int pos, string string1)
        //{
        //    return Task.Run(() =>
        //        {
        //            ArrayList wo = new ArrayList();
        //            int i = 0;
        //            while (pos > 0)
        //            {
        //                //  Console.WriteLine(pos);
        //                wo.Add(string1.Substring(0, pos));
        //                string1 = string1.Substring(pos + 1, string1.Length - (pos + 1));
        //                pos = string1.IndexOf(" ");
        //                i++;
        //            }
        //            if (pos < 0)
        //            {
        //                wo.Add(string1);
        //            }
        //            return (ArrayList)wo;
        //        });
        //}
        //Method 2 - 
        public static void Main(string[] args)
        {
            // 1 Split

            //Console.WriteLine("-------------------Split----------------\n");
            //string s = "hai,there,is,ediot like me ,shouting everytime without reason !!!without proper reason";
            //char[] d = new char[3];
            //d[0] = ',';
            //string[] f = s.Split(d, s.Length);
            //foreach (var sd in f)
            //{
            //    Console.WriteLine(sd);
            //}

            // 2 Join

            //Console.WriteLine("-------------------Join----------------\n");
            //string join;
            //join = String.Join(" ",f);
            //Console.WriteLine(join);

            // 3 Compare

            //Console.WriteLine("-------------------Compare--------------\n");
            //string s1 = "foobar";
            //string s2 = "foobar";
            //Console.WriteLine(s1.CompareTo(s2)); // returns 0
            //s2 = "fooaoo";
            //Console.WriteLine(s1.CompareTo(s2)); // returns -1
            //s2 = "foogoo";
            //Console.WriteLine(s1.CompareTo(s2)); // returns 1


            // 4 EndsWith

            //string[] noun=new string[]
            //    {
            //         "well",
            //        "songs",
            //        "computers",
            //        "ventures"
            //    };
            //foreach (var s in noun)
            //{
            //    if (s.EndsWith("s")==true)
            //    {
            //        Console.WriteLine(s);

            //    }
            //}
            //Console.Read();

            // 5 Remove

            //string[] noun = new string[]
            //    {
            //         "well",
            //        "songs",
            //        "computers",
            //        "ventures"
            //    };
            //for (int i = 0; i < noun.Length; i++)
            //{
            //    if (noun[i].EndsWith("s"))
            //    {

            //        noun[i] = noun[i].Remove(noun[i].Length-1,1);
            //        Console.WriteLine(noun[i]);
            //    }
            //}
            //    Console.Read();

            // 6  Replace

            //string[] noun = new string[]
            //    {
            //         "well",
            //        "songs",
            //        "computers",
            //        "ventures"
            //    };
            //for (int i = 0; i <noun.Length; i++)
            //{
            //    if (noun[i].EndsWith("s"))
            //    {

            //        noun[i] = noun[i].Replace("s", "d");
            //        Console.WriteLine(noun[i]);
            //    }
            //}
            //Console.Read();

            //7 Padding Left & Right

            //string[] noun = new string[]
            //    {
            //         "well",
            //        "songs",
            //        "computers",
            //        "ventures"
            //    };
            //for (int i = 0; i < noun.Length; i++)
            //{
            //        Console.WriteLine(noun[i].PadLeft(10)+"PadLeft");
            //   Console.WriteLine("PadRight"+noun[i].PadRight(5));

            //}
            //Console.Read();

            //8 InnerBound & UpperBound

            //    string[,] names = new string[,]
            //    {
            //        {"1504", "Mary", "Ella", "Steve", "Bob","fff"},
            //        {"1133", "Elizabeth", "Alex", "David", "Joe","fff"},
            //        {"2624", "Joel", "Chris", "Craig", "Bill","fff"}
            //     };
            //Console.WriteLine();
            //Console.WriteLine();
            //for (int outer = 0; outer <= names.GetUpperBound(0); outer++)
            //{
            //    for (int inner = 0; inner <= names.GetUpperBound(1); inner++)
            //        Console.Write(names[outer, inner] + "\n");
            //        Console.WriteLine();
            //}
            //Console.WriteLine();
            //Console.WriteLine();
            //for (int outer = 0; outer <= names.GetUpperBound(0); outer++)
            //{
            //    for (int inner = 0; inner <= names.GetUpperBound(1); inner++)
            //        Console.WriteLine(names[outer, inner].PadRight(10) + " ");
            //    Console.WriteLine();
            //}


            //9 Trim
            //string[] names = new string[]
            //    {
            //        "1504 ", "Mary  ", "Ella ", "Steve ", "Bob ", "fff "
            //    };
            //char[] ch=new char[]{' '};
            //for (int i = 0; i <=names.GetUpperBound(0); i++)
            //{
            //    names[i] = names[i].TrimEnd(ch);
            //    Console.Write(names[i]);
            //}
            //Console.Read();

            //10 Expert Trim
            //var htmlComments = new[]
            //    {
            //        "<!-- Start Page Number Function -->",
            //        "<!-- Get user name and password -->",
            //        "<!-- End Title page -->",
            //        "<!-- End script -->"
            //    };
            //var commentChars = new[]
            //    {
            //        '<', '!', '-',
            //        '>'
            //    };
            //for (int i = 0; i <= htmlComments.GetUpperBound(0); i++)
            //{
            //    htmlComments[i] = htmlComments[i].Trim(commentChars);
            //    Console.WriteLine(htmlComments[i]);
            //}

            //11 StringBuilder
            //var st=new StringBuilder(23);
            //st.Insert(0, "threrjgg gggggggggg");
            //st.Append("ddddddddd ddddd");
            //st.Replace('g', 'h');
            //String s = st.ToString(3, 8);
            //st.Remove(0, 5);
            //Console.WriteLine(st+"\n"+s);
            //Console.Read();

            //11 StringBuilder Efficenecy Test

            //var s = new StringBuilder();
            //var timer = new Stopwatch();
            //timer.Start();

            //for (int i = 0; i < 100; i++)
            //{
            //    s.Append("ggdd");
            //}
            ////timer.Stop();
            //Console.WriteLine(timer.ElapsedMilliseconds + "\n" + s);

            //12 Regular Expression

            Regex regex=new Regex("dog");
            String s = "iam praba ,like without any hope living without happiness living ox";
            //Match m = regex.Match(s);
            //Console.WriteLine(m.Success ? m.Index.ToString() : "failed");
            s = Regex.Replace(s, "i", "dog");
            MatchCollection mc = regex.Matches(s);
           
            foreach (Match mch in mc)
            {
                Console.WriteLine(mch.Success?mch.Index.ToString():"failed");
            }
            Console.Read();
        }
    }
    }