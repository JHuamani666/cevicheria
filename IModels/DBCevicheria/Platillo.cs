using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DBModel.DBCevicheria;

[Index("Nombre", Name = "idx_platillo_nombre")]
public partial class Platillo
{
    [Key]
    [Column("ID_Platillo")]
    public int IdPlatillo { get; set; }

    [Column("ID_Categoria")]
    public int IdCategoria { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string Nombre { get; set; } = null!;

    [Column(TypeName = "decimal(10, 2)")]
    public decimal Precio { get; set; }

    public bool? Disponible { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Estado { get; set; }

    [InverseProperty("IdPlatilloNavigation")]
    public virtual ICollection<DetallePedido> DetallePedidos { get; set; } = new List<DetallePedido>();

    [ForeignKey("IdCategoria")]
    [InverseProperty("Platillos")]
    public virtual Categoria IdCategoriaNavigation { get; set; } = null!;
}
