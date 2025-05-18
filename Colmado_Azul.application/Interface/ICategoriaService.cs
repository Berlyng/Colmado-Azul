using Colmado_Azul.common.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colmado_Azul.application.Interface
{
	public interface ICategoriaService
	{
		Task<IEnumerable<CategoriaDto>> GetAllCategoriasAsync();
		Task<CategoriaDto> GetCategoriaByIdAsync(int id);
		Task AddCategoriaAsync(CreateCategoriaDto categoria);
		Task DeleteCategoriaAsync(int id);
		Task UpdateCategoriaAsync(int id, UpdateCategoriaDto categria);
	}
}
