using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace exemple_stagiu1
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            int i = 345;
            float f = i;

            Console.WriteLine(i);
            Console.WriteLine(f);


             i = 100;
            Console.WriteLine(i);
            ChangeValue(i);
            Console.WriteLine(i);

            Student student1 = new Student();
            student1.StudentName = "Bill";

            Console.WriteLine(student1.StudentName);
            ChangeReferenceType(student1);
            Console.WriteLine(student1.StudentName);

            Student student = new Student();

            Console.WriteLine(student);

            int nullableInt;
            //Console.WriteLine(nullableInt);

            var myAnonymousType = new
            {
                firstProperty = "First",
                secondProperty = 2,
                thirdProperty = true
            };


            Console.WriteLine(myAnonymousType.GetType().ToString());
            Console.WriteLine(student.GetType().ToString());

            i = 100;
            string ceva = "Hello dynamic";
            TestDymicType(i);
            TestDymicType(ceva);
            //ChangeValue(ceva);

            dynamic dynamicVariable = 100;
            Console.WriteLine("Dynamic variable value: {0}, Type: {1}", dynamicVariable, dynamicVariable.GetType().ToString());

            dynamicVariable = "Hello World";
            Console.WriteLine("Dynamic variable value: {0}, Type: {1}", dynamicVariable, dynamicVariable.GetType().ToString());

            dynamicVariable = true;
            Console.WriteLine("Dynamic variable value: {0}, Type: {1}", dynamicVariable, dynamicVariable.GetType().ToString());

            dynamicVariable = DateTime.Now;
            Console.WriteLine("Dynamic variable value: {0}, Type: {1}", dynamicVariable, dynamicVariable.GetType().ToString());

            //string hello = "hellow world";
            string hello = "hi eveybody";
            hello = "altceva";

            StringBuilder stringBUilderExample = new StringBuilder();
            stringBUilderExample.AppendLine(hello);
            stringBUilderExample.AppendLine("altceva");


            i = 100;
            string someExample = "Hellow example";

            Console.WriteLine(someExample.GetType().ToString());
            Console.WriteLine(someExample.GetType());

            object someIntObjected = someExample;

            Console.WriteLine(someIntObjected.GetType().ToString());

            object intObjeted = 200;

            int j = (int)intObjeted;
            int k = (int)someIntObjected;


            List<int> myIntList = new List<int>();
            myIntList.Add(j);
            //myIntList.Add(someExample);
            Dictionary<int, string> keyValuePairs = new Dictionary<int, string>();

            keyValuePairs.Add(i, someExample);


            Console.WriteLine(keyValuePairs[i]);


            myIntList = new List<int>();

            var x = myIntList.ToArray();

            Student studentul = new Student();
            studentul.NumarMatricol = 1234;
            studentul.NumarMatricol = 445;

            ArrayList strArray = new ArrayList();
            strArray.AddRange(new string[] { "first", "second", "third" });
            strArray.Add("fourth");

            foreach (string str in strArray)
            {
                Console.WriteLine("Entry:{0}", str);
            }

            Console.ReadLine();
        }



        static void ChangeValue(int x)
        {
            x = 200;
            Console.WriteLine(x);
        }

        static void ChangeReferenceType(Student referinta)
        {
            referinta.StudentName = "Steve";
            Console.WriteLine(referinta.StudentName);
        }

        static void TestDymicType(dynamic someVariable)
        {
            Console.WriteLine(someVariable);
        }



        public void Swap<T> (T parametru) where T : struct
        {

        }
    }

    public class Student
    {
        public string StudentName { get; set; }
        public int NumarMatricol { get; set; }
        public int NumarTelefon { get; set; }
    }


    public class Student2
    {
        public string Prenume { get; set; }
        public int NumarMatricol { get; set; }
        public int NumarPantofi { get; set; }
    }
}
