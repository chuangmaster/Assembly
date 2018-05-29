using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Test;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //var t = Type.GetType("Test.Parents");
            //Console.WriteLine(t.FullName);
            //Console.WriteLine(t.Name);
            //t.GetMethods();
            LateBinding();
            //lateBinding2();
            Console.ReadLine();
        }

        static void LateBinding()
        {
            //取得目前存取中的Assembly
            Assembly assembly = Assembly.GetExecutingAssembly();
            Type type = assembly.GetType("ClassLibrary1.Worker");
            //印出所有property
            var properties = type.GetProperties();
            foreach (var property in properties)
            {
                Console.WriteLine(property.Name);
            }
            var printNameMethod = type.GetMethod("PrintName");


            MethodInfo[] methods = type.GetMethods();
            object[] parameters = new object[1];
            parameters[0] = "Hello!";

            object worker = Activator.CreateInstance(type);
            foreach (var method in methods)
            {
                method.Invoke(worker, parameters);
            }

        }
        static void lateBinding2()
        {
            Assembly assembly = Assembly.LoadFrom("ClassLibrary1.dll");
            Type type = assembly.GetType("ClassLibrary1.Worker");
            Object workerInstance = Activator.CreateInstance(type);
            var properties = type.GetProperties();
            foreach (var property in properties)
            {
                Console.WriteLine(property.Name);
            }

            MethodInfo saySomthingMethod = type.GetMethod("SaySomthing");
            object[] parameters = new object[1];
            parameters[0] = "Hello!";

            saySomthingMethod.Invoke(workerInstance, parameters);

        }

    }

    public struct MyFirstStruct : IA
    {
        public void Method()
        {
            throw new NotImplementedException();
        }

        public void MethodInIA()
        {
            throw new NotImplementedException();
        }
    }




    public class C : IA, IB
    {
        //non-explicit
        public void MethodInIA()
        {
            Console.WriteLine("Only in IA");
        }

        //explicit
        void IA.Method()
        {
            Console.WriteLine("Same method name in IA");
        }

        //explicit
        void IB.Method()
        {
            Console.WriteLine("Same method name in IB");
        }
    }

    public interface IA
    {
        void Method();

        void MethodInIA();
    }

    public interface IB
    {
        void Method();
    }
}

namespace Test
{
    public class Parents
    {
        public Parents()
        {
            Console.WriteLine("父類別被產生");
        }
        public Parents(string son)
        {
            Console.WriteLine($"小孩是{son}");
        }
        public virtual void Sing()
        {
            Console.WriteLine("天生好歌喉");
        }
        public virtual void Talk()
        {
            Console.WriteLine("大人講話");
        }
    }

    public class Children : Parents
    {
        public Children(string name) : base(name)
        {
            Console.WriteLine("小孩被產生");
        }
        public override sealed void Sing()
        {
            base.Sing();
        }
        public override void Talk()
        {
            Console.WriteLine("童言童語");

        }

    }

}
