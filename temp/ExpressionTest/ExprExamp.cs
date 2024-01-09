using System.Runtime.CompilerServices;

namespace ExpressionTest;

[TestClass]
public class ExprExamp
{
    [TestMethod]
    public void TestMethod1()
    {
        ItemList<double> listDbl = new ItemList<double>() { 2.3d, 4.5d, 7.2d, 8.5d };
        ItemList<int> listInt = new ItemList<int>() { 2, 4, 6, 3, 9, 11 };
        var sumDbl = listDbl.Jumlah();
        var sumInt = listInt.Jumlah();
    }
}

public class ItemList<T> : List<T>
{
    public int Sum(Func<T, int> selector)
    {
        int sum = 0;
        foreach (T item in this)
        {
            sum += selector(item);
        }
        return sum;
    }

    public double Sum(Func<T, double> selector)
    {
        double sum = 0;
        foreach (T item in this)
        {
            sum += selector(item);
        }
        return sum;
    }
}

public static class extList
{
    public static double Jumlah(this ItemList<double> items)
    {
        double sum = 0;
        foreach (double item in items)
        {
            sum += item;
        }
        return sum;
    }

    public static int Jumlah(this ItemList<int> items)
    {
        int sum = 0;
        foreach (int item in items)
        {
            sum += item;
        }
        return sum;
    }
}