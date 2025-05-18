using Colamdo_Azul.domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colmado_Azul.infractructure.Interface
{
	public interface ICategoriaRepository
	{
		Task<Categoria> GetByIdAsync(int id);
		Task <IEnumerable<Categoria>> GetAllCategoria();
		Task AddAsycn(Categoria categoria);
		Task UpdateAsync(Categoria categoria);
		Task DeleteAsync(int id);
	}
}
