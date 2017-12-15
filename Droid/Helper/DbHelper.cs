using System;
using SQLite;
namespace ICT13580096B2.Droid.Helper
{
    public class DbHelper
    {
        SQLiteConnection db;

        public DbHelper(String dbPath)
        {
            db = new SQLiteConnection(dbPath);
            db.CreateTable<Product>();    
        }
        public int AddProduct(Product product)
        {
            db.Insert(product);
            return Product.Id;
        }
    }
}
