using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.database;
using WebApplication1.entities;

namespace WebApplication1.controllers;

[Route("api/products")]
[ApiController]
public class ProductRestController
{
    private DataContext _dataContext { get; set; }

    public ProductRestController(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    [HttpGet]
    public IEnumerable<Product> getAll()
    {
        return _dataContext.Products.Include(p => p.Category);
    }
    
    [HttpGet("{Id}")]
    public Product read(int Id)
    {
        return _dataContext.Products.Include(p => p.Category).FirstOrDefault(c => c.ProductId == Id);
    }

    [HttpPut("{Id}")]
    public Product update([FromBody] Product product, int Id)
    {
        product.ProductId = Id;
        _dataContext.Products.Update(product);
        _dataContext.SaveChanges();
        return product;
    }

    [HttpPost]
    public Product create([FromBody] Product product)
    {
        _dataContext.Products.Add(product);
        _dataContext.SaveChanges();
        return product;
    }

    [HttpDelete("{Id}")]
    public void delete(int Id)
    {
        Product product = _dataContext.Products.FirstOrDefault(p => p.ProductId == Id);
        _dataContext.Products.Remove(product);
        _dataContext.SaveChanges();
    }
}