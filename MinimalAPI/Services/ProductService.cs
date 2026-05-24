using Microsoft.EntityFrameworkCore;
using MinimalAPI.DbContextClass;
using MinimalAPI.DTOs;
using MinimalAPI.Models;
using MinimalAPI.Repository;

namespace MinimalAPI.Services
{
    public class ProductService : IProductRepository
    {
        private readonly MyDbContext _context;
        public ProductService(MyDbContext context)
        {
            this._context = context;
        }

        public async Task<bool> DeleteProduct(int productId)
        {
            try
            {
                var prodId = await _context.Products.Where(x => x.ProductId == productId).FirstOrDefaultAsync(); 
                if(prodId == null)
                {
                    return false;
                }
                _context.Products.Remove(prodId);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error Occurred!", ex);
            }

        }

        public async Task<ProductDTO> EditProduct(int productId)
        {
            try
            {
                var productData = await _context.Products.Where(x => x.ProductId == productId).FirstOrDefaultAsync();
                if (productData == null) {
                    return null;
                }
                var productsList = new ProductDTO
                {
                    ProductId = productData.ProductId,
                    ProductName = productData.ProductName,
                    ProductDescription = productData.ProductDescription,
                    ProductPrice = productData.ProductPrice,
                    ProductQuanity = productData.ProductQuanity
                };
                return productsList;
            }
            catch (Exception ex)
            {
                throw new Exception("Database error occurred", ex);
            }
        }

        public async Task<List<ProductDTO>> GetProduct()
        {
            return await _context.Products
                            .Select(x => new ProductDTO
                            {
                                ProductId = x.ProductId,
                                ProductName = x.ProductName,
                                ProductDescription = x.ProductDescription,
                                ProductPrice = x.ProductPrice,
                                ProductQuanity = x.ProductQuanity
                            })
                            .ToListAsync();
        }

        public async Task<ProductDTO> InsertProduct(ProductDTO product)
        {
            try
            {
                if (product == null || string.IsNullOrEmpty(product.ProductName) || product.ProductPrice <= 0 || product.ProductQuanity <= 0)
                {
                    throw new Exception("Invalid Product Data!");
                }
                var products = new Products
                {
                    ProductId = product.ProductId,
                    ProductName = product.ProductName,
                    ProductDescription = product.ProductDescription,
                    ProductPrice = product.ProductPrice,
                    ProductQuanity = product.ProductQuanity,
                };
                await _context.Products.AddAsync(products);
                await _context.SaveChangesAsync();
                return product;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public async Task<ProductDTO> UpdateProduct(int productId, ProductDTO productDTO)
        {
            try
            {
                var existingData = await _context.Products.Where(x => x.ProductId == productId).FirstOrDefaultAsync();
                if (existingData is null)
                {
                    return null;
                }
                existingData.ProductName = productDTO.ProductName;
                existingData.ProductDescription = productDTO.ProductDescription;
                existingData.ProductPrice = productDTO.ProductPrice;
                existingData.ProductQuanity = productDTO.ProductQuanity;
                await _context.SaveChangesAsync();
                return new ProductDTO
                {
                    ProductId = existingData.ProductId,
                    ProductName = existingData.ProductName,
                    ProductDescription = existingData.ProductDescription,
                    ProductPrice = existingData.ProductPrice,
                    ProductQuanity = existingData.ProductQuanity
                };
            }
            catch (Exception ex)
            {

                throw new Exception("Error Occurred", ex);
            }

        }
    }
}
