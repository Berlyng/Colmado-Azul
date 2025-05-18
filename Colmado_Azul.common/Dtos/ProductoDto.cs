using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colmado_Azul.common.Dtos
{
	public class ProductoDto
	{
		public int Id { get; set; }

		public string Descripcion { get; set; } = null!;

		public int CategoriaId { get; set; }

		public int Cantidad { get; set; }

		public double Precio { get; set; }

		public int SuplidorId { get; set; }

		public int? FechaDeVencimiento { get; set; }

	}
}
