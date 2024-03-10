using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace TestSyntaxVersi12
{
    [TestClass]
    public class StaticInterfaceTest
    {
        public static T MidPoint<T>(T left, T right)
            where T : INumber<T> => (left + right) / T.CreateChecked(2);  // note: the addition of left and right may overflow here; it's just for demonstration purposes

        [TestMethod]
        public void StaticIntefaceMethodTest()
        {
            var aa = TestCls.MidPoint(7, 4);
            Assert.AreEqual(aa, 5.5d,"Hasilnya Sama");
            var bb = MidPoint<int>(7, 4);
            Assert.AreEqual(bb, 5.5f,"Penjumlahan Hasilnya Tidak Sama");
        }
        [TestMethod]
        public void RepeatSequenceTest()
        {
            RepeatSequence aa = new();
            for (int i = 0; i < 10; i++)
            {
                Debug.WriteLine(aa++);
            }
        }
        [TestMethod]
        public void GenericMathTest()
        {
            var ptA = new PointA<int>(1, 2);
            var trA = new TranslationA<int>(4, 7);
            var fnA = ptA + trA;

            Debug.WriteLine($"Nilai dari ptA {ptA}");
            Debug.WriteLine($"Nilai dari trA {trA}");
            Debug.WriteLine($"Nilai dari fnA {fnA}");

            var pt = new Point<int>(3, 4);

            var translate = new Translation<int>(5, 10);

            var final = pt + translate;

            Debug.WriteLine(pt);
            Debug.WriteLine(translate);
            Debug.WriteLine(final);
        }
    }

    class TestCls
    {
        public static double MidPoint(double left, double right) => (left + right) / (2.0);
    }

    public interface IGetNext<T> where T : IGetNext<T>
    {
        static abstract T operator ++(T other);
    }

    public struct RepeatSequence : IGetNext<RepeatSequence>
    {
        private const char Ch = 'A';
        public string Text = new string(Ch, 1);

        public RepeatSequence() { }

        public static RepeatSequence operator ++(RepeatSequence other)
            => other with { Text = other.Text + Ch };

        public override string ToString() => Text;
    }

    public record TranslationA<T>(T XOffset, T YOffset) where T : IAdditionOperators<T, T, T>;
    public record PointA<T>(T X, T Y) : IAdditionOperators<PointA<T>, TranslationA<T>, PointA<T>>
        where T : IAdditionOperators<T, T, T>
    {
        public static PointA<T> operator +(PointA<T> left, TranslationA<T> right)
        {
            return left with { X = left.X + right.XOffset, Y = left.Y + right.YOffset };
        }
    }

    public record Translation<T>(T XOffset, T YOffset) : IAdditiveIdentity<Translation<T>, Translation<T>>
        where T : IAdditionOperators<T, T, T>, IAdditiveIdentity<T, T>
    {
        public static Translation<T> AdditiveIdentity =>
            new Translation<T>(XOffset: T.AdditiveIdentity, YOffset: T.AdditiveIdentity);
    }

    public record Point<T>(T X, T Y) : IAdditionOperators<Point<T>, Translation<T>, Point<T>>
        where T : IAdditionOperators<T, T, T>, IAdditiveIdentity<T, T>
    {
        public static Point<T> operator +(Point<T> left, Translation<T> right) =>
            left with { X = left.X + right.XOffset, Y = left.Y + right.YOffset };
    }
}
