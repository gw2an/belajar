using System.Diagnostics;

namespace TestSyntaxVersi12
{
    [TestClass]
    public class ClassTest
    {
        [TestMethod]
        public void ClsConstructorTest()
        {
            Dasar dasar = new Dasar();
            Assert.IsNotNull(dasar);
            Turunan turA = new("Nacha", 17);
            Assert.IsNotNull(turA);
            Turunan turB = new("Ridha", 20);
            Dasar turC = new Turunan();
            Assert.IsNotNull(turC);

        }
    }

    class Dasar(string Nama, int Umur)
    {
        private string Nama { get; } = Nama;
        private int Umur { get; } = Umur;
        public Dasar() : this("Amir", 10) { Tampil(); }
        public void Tampil()
        {
            Debug.WriteLine($"Nama :{Nama}  Umur : {Umur}");
        }
        static Dasar() { Debug.WriteLine($"Hanya sekali dijalankan saat di buat"); }
    }

    class Turunan : Dasar
    {
        public Turunan(string Nama, int Umur) : base(Nama, Umur) { Tampil(); }
        public Turunan() {  }

    }
}