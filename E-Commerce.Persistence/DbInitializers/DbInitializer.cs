using E_Commerce.Domain.Contracts;
using E_Commerce.Domain.Entities.Products;
using E_Commerce.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace E_Commerce.Persistence.DbInitializers
{
    public class DbInitializer(StoreDbContext context) : IDbInitializer
    {
        public async Task InitializeAsync()
        {

            context.Database.MigrateAsync();

            if (!context.ProductBrands.Any())
            {
               var brandsData = await File.ReadAllTextAsync(@"..\E-Commerce.Persistence\Context\DataSeed\brands.json");

                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData, options);

                if (brands is not null && brands.Any())
                  await  context.ProductBrands.AddRangeAsync(brands);
                    
                await context.SaveChangesAsync();
            }

            if (!context.ProductTypes.Any())
            {
                var typesData = await File.ReadAllTextAsync(@"..\E-Commerce.Persistence\Context\DataSeed\types.json");
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                var types = JsonSerializer.Deserialize<List<ProductType>>(typesData, options);

                if (types is not null && types.Any())
                  await  context.ProductTypes.AddRangeAsync(types);

                await  context.SaveChangesAsync();
            }

            if (!context.Products.Any())
            {
                var productsData = await File.ReadAllTextAsync(@"..\E-Commerce.Persistence\Context\DataSeed\products.json");

                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                var products = JsonSerializer.Deserialize<List<Product>>(productsData, options);

                if ( products is not null && products.Any())
                 await   context.Products.AddRangeAsync(products);

                await context.SaveChangesAsync();
            }

        }

    }
}
