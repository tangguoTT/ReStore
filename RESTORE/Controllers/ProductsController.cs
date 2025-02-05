using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RESTORE.Data;
using RESTORE.Entities;

namespace RESTORE.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly StoreContext _context;

    public ProductsController(StoreContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<List<Product>>> GetProducts()
    {
        return await _context.Products.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Product>> GetProduct(int id)
    {
        var product =   await _context.Products.FindAsync(id);
        
        if (product == null) return NotFound();

        return product;
    }
}