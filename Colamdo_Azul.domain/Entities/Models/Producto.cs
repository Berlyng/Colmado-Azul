using System;
using System.Collections.Generic;

namespace Colamdo_Azul.domain.Entities.Models;

public partial class Producto
{
    public int Id { get; set; }

    public string Descripcion { get; set; } = null!;

    public int CategoriaId { get; set; }

    public int Cantidad { get; set; }

    public double Precio { get; set; }

    public int SuplidorId { get; set; }

    public int? FechaDeVencimiento { get; set; }

    public virtual Categoria Categoria { get; set; } = null!;

    public virtual Suplidor Suplidor { get; set; } = null!;
}
