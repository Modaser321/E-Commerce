using E_Commerce.Sheard.Dtos.Products;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace E_Commerce.Service.Services
{
    public interface IProductService
    {      
        Task<ProductDto> GetProductByIdAsync(int id);

        Task<IEnumerable<ProductDto>> GetAllProductsAsync();
        Task<IEnumerable<BrandDto>> GetAllBrandsAsync();
        Task<IEnumerable<TypeDto>> GetAllTypesAsync();


    }
}