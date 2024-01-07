using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OopModel
{
    internal class entModel
    {
    }
    public abstract class entTBBase
    {
        [Key]
        virtual public int Id { get; set; }
    }

    public enum enJenAnimal : byte
    {
        Mamalia = 1,
        Betelur = 2
    }
    public enum enJenNafas : byte
    {
        ParuParu = 1, Insang = 2, Hybrid = 3
    }
    public enum enHabitat : byte
    {
        Air = 1, Darat = 2
    }

    public enum enKatAnimal
    {
        Melata, Unggas, Verteberata, KakiEmpat, LainLain
    }
    public class Animal : entTBBase
    {
        public required string Nama { get; set; }
        [Range(1, 2)]
        public enJenAnimal KembangBiak { get; set; }
        public enHabitat Habitat { get; set; }
        public enJenNafas Nafas { get; set; }
        public enKatAnimal Kategori { get; set; }
        public bool IsBuas { get; set; }
    }

    public class Unggas : Animal
    {
        public bool IsTerbang { get; set; } = true;
        public bool IsKicau { get; set; } = false;
    }

    public class KakiEmpat : Animal
    {

    }
    public class Ikan : Animal
    {
        Ikan() { Habitat = enHabitat.Air; }
        [Range(1,2)]
        public byte JenisAir { get; set; }  // 1: Tawar, 2: Payau, 3:Asin
    }

}
