using MinimalAPI.DTOs;
using MinimalAPI.Repository;

namespace MinimalAPI.EndPoints
{
    public static class ProductEndPoint
    {
        public static void ProductAPI(this IEndpointRouteBuilder app)
        {
            app.MapPost("/api/insertProduct", async (ProductDTO productDto, IProductRepository productRepo) =>
            {
                try
                {
                    if (productDto is null)
                        return Results.BadRequest("Product is required");

                    var result = await productRepo.InsertProduct(productDto);
                    return Results.Ok(new { successMessage = "Product Insert SuccessFully!", data = result });
                }
                catch (Exception ex)
                {
                    return Results.BadRequest(new { errorMessage = ex.Message });
                }
            });
            app.MapGet("/api/getProducts", async (IProductRepository productRepo) =>
            {
                var data = await productRepo.GetProduct();

                if (data == null || !data.Any())
                {
                    return Results.NotFound(new { message = "No products found" });
                }

                return Results.Ok(data);
            });
            app.MapGet("/api/editProduct/{id}", async (IProductRepository productRepo, int id) =>
            {
                try
                {
                    var product = await productRepo.EditProduct(id);

                    if (product == null)
                        return Results.NotFound(new { message = "Product not found" });

                    return Results.Ok(product);
                }
                catch (Exception ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            });
            app.MapPut("/api/updateProduct/{id}", async (IProductRepository productRepo, int id, ProductDTO productDTO) =>
            {
                try
                {
                    var product = await productRepo.UpdateProduct(id, productDTO);

                    if (product == null)
                        return Results.NotFound(new { message = "Product not found" });

                    return Results.Ok(new {successMessage = "Product Update Successfully!", data = product});
                }
                catch (Exception ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }
            });
            app.MapDelete("/api/deleteProduct/{id}", async (IProductRepository productRepo, int id) =>
            {
                try
                {
                    var data = await productRepo.DeleteProduct(id);
                    if (data == null)
                        return Results.NotFound(new { message = "Product not found" });

                    return Results.Ok(new { successMessage = "Product Delete Successfully!" });

                }
                catch (Exception ex)
                {
                    return Results.BadRequest(new { error = ex.Message });
                }                
            });
        }
    }
}
