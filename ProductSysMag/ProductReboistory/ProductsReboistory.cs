using Dapper;
using Microsoft.AspNetCore.Mvc;
using ProductSysMag.Models;
using ProductSystemManagement.Data;

namespace ProductSysMag.ProductReboistory
{
    public class ProductsReboistory
    {
        private readonly DapperContext _dapperContext;

        public ProductsReboistory(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }

        public async Task<IEnumerable<ProductModel>> GetAllProduct()
        {
            var query = @"SELECT * FROM Products Order BY CreatedDate DESC";
            using (var connection = _dapperContext.CreateConnection())
            {
               return await connection.QueryAsync<ProductModel>(query);
            }
        }

        public async Task<IEnumerable<Guid>> CrerateProduct(ProductModel proudct)
        {
            var query = @"
                        DECLARE @NewId UNIQUEIDENTIFIER = NEWID();
                        INSERT INTO Products (Id, Name, Description, Price)
                        VALUES (@NewId, @Name, @Description, @Price);
                        SELECT @NewId;";
            using (var connection = _dapperContext.CreateConnection())
            {

                var Obj = new
                {
                    proudct.Name,
                    proudct.Description,
                    proudct.Price,
                };
                var product = await connection.QueryAsync<Guid>(query, Obj);

                return product;
            }
        }

        public async Task<ProductModel> GetProductById(Guid id)
        {
            var query = "SELECT * FROM Products WHERE Id = @Id";

            using (var connection = _dapperContext.CreateConnection())
            {
                var product = await connection.QuerySingleOrDefaultAsync<ProductModel>(query, new { id });
                return product;
            }
        }

        public async Task UpdateProduct(ProductModel product)
        {
            var query = @"UPDATE Products 
                    SET Name = @Name, Description=@Description, Price = @Price
                    WHERE Id = @Id";

            using (var connection = _dapperContext.CreateConnection())
            {
                await connection.ExecuteAsync(query, product);
            }
        }

        public async Task DeleteProduct(Guid id)
        {
            var query = "DELETE FROM Products WHERE Id = @Id";

            using (var connection = _dapperContext.CreateConnection())
            {
                await connection.ExecuteAsync(query, new { id });
            }
        }


    }
}