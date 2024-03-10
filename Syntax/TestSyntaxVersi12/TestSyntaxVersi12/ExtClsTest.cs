using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TestSyntaxVersi12.MyDefInterface;

namespace TestSyntaxVersi12
{
    using MyDefClass;
    using TestSyntaxVersi12.MyExtensions;

    [TestClass]
    public class ExtClsTest
    {
        [TestMethod]
        public void ExtentionTest()
        {
            ContohInterface ci = new();
            ci.CetakPesan();
        }

        [TestMethod]
        public void ExtentionTest2()
        {
            A a = new A();
            B b = new B();
            C c = new C();

            // For a, b, and c, call the following methods:
            //      -- MethodA with an int argument
            //      -- MethodA with a string argument
            //      -- CetakPesan() with no argument.

            // A contains no MethodA, so each call to MethodA resolves to
            // the extension method that has a matching signature.
            a.CetakPesanX(1);           // Extension.MethodA(IMyInterface, int)
            a.CetakPesanX("hello");     // Extension.MethodA(IMyInterface, string)

            // A has a method that matches the signature of the following call
            // to CetakPesan().
            a.CetakPesan();            // A.CetakPesan()

            // B has methods that match the signatures of the following
            // method calls.
            b.CetakPesanX(1);           // B.MethodA(int)
            b.CetakPesan();            // B.CetakPesan()

            // B has no matching method for the following call, but
            // class Extension does.
            b.CetakPesanX("hello");     // Extension.MethodA(IMyInterface, string)

            // C contains an instance method that matches each of the following
            // method calls.
            c.CetakPesanX(1);           // C.MethodA(object)
            c.CetakPesanX("hello");     // C.MethodA(object)
            c.CetakPesan();             // C.CetakPesan()
        }
    }
    namespace MyDefInterface
    {
        public interface IContoh
        {
            void CetakPesan();
        }
    }
    namespace MyExtensions
    {
        using MyDefInterface;

        public static class myExtention
        {
            public static void CetakPesanX(this IContoh ic, int i)
            {
                Console.WriteLine
                ("Extension.MethodA(this IMyInterface myInterface, int i)");
            }
            public static void CetakPesanX(this IContoh ic, string s)
            {
                Console.WriteLine
                ("Extension.MethodA(this IMyInterface myInterface, string s)");
            }
            // This method is never called in ExtensionMethodsDemo1, because each
            // of the three classes A, B, and C implements a method named CetakPesan
            // that has a matching signature.
            public static void CetakPesan(this IContoh ic)
            {
                Console.WriteLine
                ("Extension.MethodA(this IMyInterface myInterface, int i)");
            }
        }
    }
    namespace MyDefClass
    {
        class ContohInterface : IContoh
        {
            public void CetakPesan()
            {
                Debug.WriteLine("Contoh Method Cetak !");
            }
        }
        class A : IContoh
        {
            public void CetakPesan()
            {
                Console.WriteLine($"A.CetakPesan()");
            }
        }
        class B : IContoh
        {
            public void CetakPesan()
            {
                Console.WriteLine($"B.CetakPesan()");
            }
            public void CetakPesanX(int I)
            {
                Console.WriteLine("C.MethodA(int i)");
            }

        }
        class C : IContoh
        {
            public void CetakPesan()
            {
                Console.WriteLine($"C.CetakPesan()");
            }
            public void CetakPesanX(object obj)
            {
                Console.WriteLine("C.MethodA(object obj)");
            }
        }
    }
}
