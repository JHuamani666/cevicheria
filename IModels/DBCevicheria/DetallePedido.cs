using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DBModel.DBCevicheria;

[Table("DetallePedido")]
[Index("IdPedido", Name = "idx_detallepedido_pedido")]
[Index("IdPlatillo", Name = "idx_detallepedido_platillo")]
public partial class DetallePedido
{
    [Key]
    [Column("ID_Detalle")]
    public int IdDetalle { get; set; }

    [Column("ID_Pedido")]
    public int IdPedido { get; set; }

    [Column("ID_Platillo")]
    public int IdPlatillo { get; set; }

    public int Cantidad { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal PrecioUnitario { get; set; }

    [ForeignKey("IdPedido")]
    [InverseProperty("DetallePedidos")]
    public virtual Pedido IdPedidoNavigation { get; set; } = null!;

    [ForeignKey("IdPlatillo")]
    [InverseProperty("DetallePedidos")]
    public virtual Platillo IdPlatilloNavigation { get; set; } = null!;
}
