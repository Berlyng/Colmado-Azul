using Colmado_Azul.common.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colmado_Azul.application.Interface
{
	public interface ISuplidoraService
	{
		Task<IEnumerable<SuplidorDto>> GetAllSuplidorAsync();
		Task<SuplidorDto> GetSuplidorByIdAsync(int id);
		Task AddSuplidorAsync(CreateSuplidorDto suplidor);
		Task DeleteSuplidorAsync(int id);
		Task UpdateSuplidorAsync(int id, UpdateSuplidorDto suplidor);
	}
}
