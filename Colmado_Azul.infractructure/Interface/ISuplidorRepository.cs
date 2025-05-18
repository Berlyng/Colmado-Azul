using Colamdo_Azul.domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colmado_Azul.infractructure.Interface
{
	public interface ISuplidorRepository
	{
		Task<Suplidor> GetSuplidorById(int id);
		Task<IEnumerable<Suplidor>> GetAllSuplidorAsync();
		Task AddAsync (Suplidor suplidor);
		Task UpdateAsync (Suplidor suplidor);
		Task DeleteAsync (int id);
	}
}
