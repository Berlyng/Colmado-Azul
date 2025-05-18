using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colmado_Azul.common.Dtos
{
	public class SuplidorDto
	{
		public int Id { get; set; }

		public string NombreDeEmpresa { get; set; } = null!;

		public string Correo { get; set; } = null!;

		public string Telefono { get; set; } = null!;

		public string? Direccion { get; set; }
	}
}
