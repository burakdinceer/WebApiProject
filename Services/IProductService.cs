using Ornek2.Api.Models;
using System.Collections.Generic;

namespace Ornek2.Api.Services
{
    public interface IProductService
    {
        List<Product> GetSimpleList();
    }
}
