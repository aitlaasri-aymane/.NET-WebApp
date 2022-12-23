using WebApplication1.database;
using WebApplication1.entities;

namespace WebApplication1.services;

public static class DbInit
{
    public static void initData(DataContext dataContext)
    {
        dataContext.Categories.Add(new Category { NameCategory = "phones" });
        dataContext.Categories.Add(new Category { NameCategory = "watches" });
        
        dataContext.Products.Add(new Product { ProductId = 1, Designation = "Iphone 14 Pro", Price = 15000, CategoryID = 1 });
        dataContext.Products.Add(new Product { ProductId = 2, Designation = "Samsung 12 ULTRA", Price = 18000, CategoryID = 1 });
        dataContext.Products.Add(new Product { ProductId = 3, Designation = "Oppo Phone", Price = 3500, CategoryID = 1 });
        dataContext.Products.Add(new Product { ProductId = 4, Designation = "Apple watch", Price = 14000, CategoryID = 2 });
        dataContext.Products.Add(new Product { ProductId = 5, Designation = "Samsung watch", Price = 8000, CategoryID = 2 });
        dataContext.Products.Add(new Product { ProductId = 6, Designation = "Huawei watch", Price = 4500, CategoryID = 2 });

        dataContext.SaveChanges();
    }
}