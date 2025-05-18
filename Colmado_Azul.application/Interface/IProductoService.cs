using Colmado_Azul.common.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colmado_Azul.application.Interface
{
	public interface IProductoService
	{
		Task<IEnumerable<ProductoDto>> GetAllProductoAsync();
		Task<ProductoDto> GetProductoById(int id);
		Task AddProductoAsync(CreateProductoDto producto);
		Task DeleteProductoAsync(int id);
		Task UpdatePrdouctoAsync(int id, UpdateProductoDto producto);
	}
}
