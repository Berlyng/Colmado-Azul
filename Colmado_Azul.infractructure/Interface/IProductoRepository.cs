using Colamdo_Azul.domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colmado_Azul.infractructure.Interface
{
	public interface IProductoRepository
	{
		Task<Producto> GetByIdAsync(int id);
		Task<IEnumerable<Producto>> GetAllProducto();
		Task AddAsync(Producto producto);
		Task DeleteAsync(int id);
		Task UpdateAsync (Producto producto);
	}
}
