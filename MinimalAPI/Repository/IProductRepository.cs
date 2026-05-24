using MinimalAPI.DTOs;
using MinimalAPI.Models;

namespace MinimalAPI.Repository
{
    public interface IProductRepository
    {
        public Task<ProductDTO> InsertProduct(ProductDTO product);
        public Task<List<ProductDTO>> GetProduct();
        public Task<ProductDTO> EditProduct(int productId);
        public Task<ProductDTO> UpdateProduct(int productId, ProductDTO productDTO);
        public Task<bool> DeleteProduct(int productId);
    }
}
