using System;
using System.Collections.Generic;

namespace Colamdo_Azul.domain.Entities.Models;

public partial class Suplidor
{
    public int Id { get; set; }

    public string NombreDeEmpresa { get; set; } = null!;

    public string Correo { get; set; } = null!;

    public string Telefono { get; set; } = null!;

    public string? Direccion { get; set; }

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
