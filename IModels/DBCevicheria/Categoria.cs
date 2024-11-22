using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DBModel.DBCevicheria;

[Index("Nombre", Name = "idx_categoria_nombre")]
public partial class Categoria
{
    [Key]
    [Column("ID_Categoria")]
    public int IdCategoria { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string Nombre { get; set; } = null!;

    [Column(TypeName = "text")]
    public string? Descripcion { get; set; }

    public byte[]? Imagen { get; set; }

    public bool? Estado { get; set; }

    public int? OrdenVisualizacion { get; set; }

    [InverseProperty("IdCategoriaNavigation")]
    public virtual ICollection<Platillo> Platillos { get; set; } = new List<Platillo>();
}
