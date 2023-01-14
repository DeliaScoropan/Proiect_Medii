using Proiect_Medii.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proiect_Medii;

namespace Proiect_Medii.Database
{
    public class ItemsList
    {
        readonly SQLiteAsyncConnection _database;
        public ItemsList(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Items>().Wait();
            _database.CreateTableAsync<Product>().Wait();
            _database.CreateTableAsync<ProductList>().Wait();
        }


        public Task<int> SaveProductAsync(Product product)
        {
            if (product.ID != 0)
            {
                return _database.UpdateAsync(product);
            }
            else
            {
                return _database.InsertAsync(product);
            }
        }
        public Task<int> DeleteProductAsync(Product product)
        {
            return _database.DeleteAsync(product);
        }
        public Task<List<Product>> GetProductsAsync()
        {
            return _database.Table<Product>().ToListAsync();
        }
        public Task<int> DeleteListProductAsync(ProductList listp)
        {
            return _database.DeleteAsync(listp);
        }
        public Task<List<ProductList>> GetListProducts()
        {
            return _database.QueryAsync<ProductList>("select * from ProductList");
        }

        public Task<List<Items>> GetShopListsAsync()
        {
            return _database.Table<Items>().ToListAsync();
        }
        public Task<Items> GetShopListAsync(int id)
        {
            return _database.Table<Items>()
            .Where(i => i.ID == id)
           .FirstOrDefaultAsync();
        }
        public Task<int> SaveShopListAsync(Items slist)
        {
            if (slist.ID != 0)
            {
                return _database.UpdateAsync(slist);
            }
            else
            {
                return _database.InsertAsync(slist);
            }
        }
        public Task<int> DeleteShopListAsync(Items slist)
        {
            return _database.DeleteAsync(slist);
        }
        public Task<int> SaveListProductAsync(ProductList listp)
        {
            if (listp.ID != 0)
            {
                return _database.UpdateAsync(listp);
            }
            else
            {
                return _database.InsertAsync(listp);
            }
        }
        public Task<List<Product>> GetListProductsAsync(int shoplistid)
        {
            return _database.QueryAsync<Product>(
            "select P.ID, P.Description from Product P"
            + " inner join ProductList LP"
            + " on P.ID = LP.ProductID where LP.ItemsID = ?",
            shoplistid);
        }

    }

}