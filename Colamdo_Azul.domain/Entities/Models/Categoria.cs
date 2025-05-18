using System;
using System.Collections.Generic;

namespace Colamdo_Azul.domain.Entities.Models;

public partial class Categoria
{
    public int Id { get; set; }

    public string? Descripcion { get; set; }

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
