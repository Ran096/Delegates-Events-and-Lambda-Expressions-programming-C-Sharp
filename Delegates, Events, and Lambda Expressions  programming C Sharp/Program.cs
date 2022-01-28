using System;

namespace Delegates__Events__and_Lambda_Expressions__programming_C_Sharp
{
    // A simple delegate example.
    /*
    delegate string Ran(string Str);
    internal class Program
    {
        static string ReplaceSpaces(string s)
        {
            Console.WriteLine("Replacing spaces with hyphens.");
            return s.Replace(' ','-');
        }
        static string RemoveSpaces(string r)
        {
            string temp=" ";
            int i;
            
            Console.WriteLine("Removing spaces.");
            for (i = 0; i < r.Length; i++)
                if (r[i] != ' ') temp += r[i];
            return temp;
        }
        static string ReverseString( string s)
        {
            int i, j;
            string temp = " ";
            Console.WriteLine("Reversing string.");
            for (j = 0, i = s.Length - 1; i >= 0; i--, j++)
                temp += s[i];
            return temp;
        }
        static void Main()
        {
            Ran Strob = new Ran(ReplaceSpaces);
            string str;
            str = Strob(" This is a Test");
            Console.WriteLine(" Resulting String : \t"+str);
            Console.WriteLine();
            Strob = new Ran(RemoveSpaces);
            str = Strob(" This is a test");
            Console.WriteLine("Resulting String Removes: \t" + str);
            Console.WriteLine();
            Strob = new Ran(ReverseString);
            str = Strob(" This is a test");
            Console.WriteLine("Resulting Reverse String :\t"+str);
        }
    }
  
    delegate string StrMod(ref string Str);
    internal class Program
    {
        static string ReplaceSpaces(ref string s)
    {
        Console.WriteLine("Replacing spaces with hyphens.");
        return s.Replace(' ', '-');
    }
    static string RemoveSpaces(ref string r)
    {
        string temp = " ";
        int i;

        Console.WriteLine("Removing spaces.");
        for (i = 0; i < r.Length; i++)
            if (r[i] != ' ') temp += r[i];
        return temp;
    }
    static string ReverseString(ref string s)
    {
        int i, j;
        string temp = " ";
        Console.WriteLine("Reversing string.");
        for (j = 0, i = s.Length - 1; i >= 0; i--, j++)
            temp += s[i];
        return temp;
    }
    static void Main()
    {
            StrMod strOp;
            StrMod replaceSp = ReplaceSpaces;
            StrMod removeSp = RemoveSpaces;
            StrMod reverseStr = ReverseString;
            string str = "This is a test";
            // Set up multicast.
            strOp = replaceSp;
            strOp += reverseStr;
            // Call multicast.
            strOp(ref str);
            Console.WriteLine("Resulting string: " + str);
            Console.WriteLine();
            // Remove replace and add remove.
            strOp -= replaceSp;
            strOp += removeSp;
            str = "This is a test."; // reset string
                                     // Call multicast.
            strOp(ref str);
            Console.WriteLine("Resulting string: " + str);
            Console.WriteLine();

        }
    }
   
    // Demonstrate covariance and contravariance.
    class X
    {
        public int val;
    }
    class Y : X { }
    delegate X ChangeIt( Y obj);

    class CoContra
    {
        static X IncrtA( X obj)
        {
            
                X temp = new X();
                temp.val = obj.val + 1 +1;
                return temp;
           
        }
        static X IncrtB(Y obj)
        {

            Y temp = new Y();
            temp.val = obj.val + 1+1;
            return temp;

        }
        static void Main()
        {
            Y yob = new Y();
            ChangeIt change = IncrtA;
            X Xob =change(yob);

            Console.WriteLine("XOB Value:" + Xob.val);

            change = IncrtB;
            yob = (Y)change(yob);
            Console.WriteLine("Yob value : " + yob.val);
        }
    }
 
    // Demonstrate an anonymous method.
    delegate void CountIt();
    class AnonymousMethod
    {
        static void Main()
        {
            CountIt count = delegate
            {
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine(" Delegate Count Value " + i);
                }
            };
            count();
        }
    }
        
    // Demonstrate an anonymous method that takes an argument
    delegate void CountIt(int end );
    class AnonymousMethod
    {
        static void Main()
        {
            CountIt count = delegate(int end)
            {
                for (int i = 0; i < end; i++)
                {
                    Console.WriteLine(" Delegate Count Value " + i);
                }
            };
            count(5);
            Console.WriteLine("Pass argument");
            count(6);
        }
    }

  
    // This delegate returns int and takes an int argument.
    delegate int CountIt(int end);
    class VarCapture
    {
        static CountIt Counter()
        {
            int sum = 0;

            CountIt ctObj = delegate (int end)
            {
                for (int i = 0; i <= end; i++)
                {
                    Console.WriteLine(i);
                    sum += i;
                }
                return sum;
            };
            return ctObj;
        }
        static void Main()
        {

            CountIt count = Counter();
            int result;
            result = count(3);
            Console.WriteLine("Summation of 3 is " + result);
            Console.WriteLine();
            result = count(5);
            Console.WriteLine("Summation of 5 is" + result);
        }
    }
        
    // Use two simple lambda expressions.
    delegate int IncrIt(int v);
    delegate bool IsEven(int v);
    
    class LambdaDemo
    {
        static void Main()
        {
        IncrIt incrti = count => count + 2;
            Console.WriteLine("Incrt Lambda Used");
            int x = -20;
            while(x<=0)
            {
                Console.Write(" " + x);
                x = incrti(x);
            }

            IsEven isEven = n => n % 2 == 0;
            Console.WriteLine("\n Use isEven lambda expression: ");
           for(int i= 0; i<20;i++)
            {
                if (isEven(i)) Console.WriteLine(i + " is even.");
            }
        }
    }

    // A very simple event demonstration.

    delegate void MyEventHandler();
    class MyEvent
    {
        public event MyEventHandler SomeEvent;
        public void OnSomeEvent()
        {
            if (SomeEvent != null)
            {
                SomeEvent();
            }
        }
    }
    class EventDemo
    {
        static void Handler()
        {
            Console.WriteLine(" This is A Event occurred");
        }
        static void Main()
        {
            MyEvent evt = new MyEvent();
            evt.SomeEvent += Handler;
            evt.OnSomeEvent();
        }
    }
      
    // An event multicast demonstration.

    delegate void MyEventHandler();
    class MyEvent
    {
        public event MyEventHandler SomeEvent;
        public void OnSomeEvent()
        {
            if (SomeEvent != null)
            {
                SomeEvent();
            }
        }
    }
    class X
    {
        public void Xhandler()
        {
            Console.WriteLine(" Event received by X object");
        }
    }
    class Y
    {
        public void Yhandler()
        {
            Console.WriteLine("Event received by Y object");
        }
    }
    class Z
    {
        public void Zhandler()
        {
            Console.WriteLine("Event received by z object");
        }
    }
    class A
    {
        public void Ahandler()
        {
            Console.WriteLine("Event received by A object");
        }
    }
    class MultipleEventDemo
    {
        static void Handler()
        {
            Console.WriteLine("Event received by Multiple Event Demo Handler Called ");
        }
        public static void Main()
        {
            MyEvent evt = new MyEvent();
            X xob = new X();
            Y yob = new Y();
            Z zob = new Z();
            A aob = new A();

            evt.SomeEvent += Handler;
            evt.SomeEvent += xob.Xhandler;
            evt.SomeEvent += yob.Yhandler;
            evt.SomeEvent += zob.Zhandler;
            evt.SomeEvent += aob.Ahandler;
            evt.OnSomeEvent();
            Console.WriteLine();
           
            evt.SomeEvent -= yob.Yhandler;
            evt.OnSomeEvent();

        }
    }
     */
    //
    class AmStrognNumber
    {
        static void Main()
        {
            int num, n, qsum, r;
            Console.WriteLine("Armstrong Number from 100 to 999");
            for (num = 100; num <= 999; num++)
            {
                qsum = 0;
                n = num;
                while (n != 0)
                {
                    r = n % 10;
                    qsum = qsum + (r * r * r);
                    n = n / 10;
                }
                if (num == qsum)
                    Console.WriteLine(num);
            }

            Console.ReadKey();
        }
    }
}