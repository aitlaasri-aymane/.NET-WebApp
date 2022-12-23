using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.database;
using WebApplication1.entities;

namespace WebApplication1.controllers;

[Route("api/categories")]
[ApiController]
public class CategoryRestController
{
    private DataContext _dataContext { get; set; }

    public CategoryRestController(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IEnumerable<Category> getAll()
    {
        return _dataContext.Categories;
    }

    [HttpGet("{Id}/products")]
    public IEnumerable<Product> getAll(int Id)
    {
        Category category = _dataContext.Categories.Include(c => c.Products).FirstOrDefault(c => c.CategoryID == Id);
        return category.Products;
    }
    
    [HttpGet("{Id}")]
    public Category read(int Id)
    {
        return _dataContext.Categories.FirstOrDefault(c => c.CategoryID == Id);
    }

    [HttpPut("{Id}")]
    public Category update([FromBody] Category category, int Id)
    {
        category.CategoryID = Id;
        _dataContext.Categories.Update(category);
        _dataContext.SaveChanges();
        return category;
    }

    [HttpPost]
    public Category create([FromBody] Category category)
    {
        _dataContext.Categories.Add(category);
        _dataContext.SaveChanges();
        return category;
    }

    [HttpDelete("{Id}")]
    public void delete(int Id)
    {
        Category category = _dataContext.Categories.FirstOrDefault(c => c.CategoryID == Id);
        _dataContext.Categories.Remove(category);
        _dataContext.SaveChanges();
    }
}