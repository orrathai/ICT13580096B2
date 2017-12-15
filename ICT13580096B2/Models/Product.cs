using System;
using SQLite;
namespace ICT13580096B2.Models
{
    public class Product
    {
        [PrimaryKey, AutoIncrement]
        public int Id{ get; set; }

        [NotNull]
        [MaxLength(200)]
        public String Name { get; set; }

        public String Descriptions{ get; set; }

		[NotNull]
		[MaxLength(100)]
        public String Category{ get; set; }

        public decimal ProductPrice{ get; set; }
        public decimal sellPrice{ get; set; }
        public int Strock{get;set;}
    }
}
