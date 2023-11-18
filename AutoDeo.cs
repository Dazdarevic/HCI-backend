using System.ComponentModel.DataAnnotations;

namespace Auto_delovi_bekend
{
    public class AutoDeo
    {
        [Key]
        public int id { get; set; }
        public String? naziv { get; set; }
        public String? marka_automobila { get; set; }
        public String? cena { get; set; }
        public String? detalji { get; set; }
    }
}
