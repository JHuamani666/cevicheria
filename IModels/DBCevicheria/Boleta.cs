using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DBModel.DBCevicheria;

[Index("IdPedido", Name = "idx_boleta_pedido")]
public partial class Boleta
{
    [Key]
    [Column("ID_Boleta")]
    public int IdBoleta { get; set; }

    [Column("ID_Pedido")]
    public int IdPedido { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? FechaBoleta { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal MontoTotal { get; set; }

    [ForeignKey("IdPedido")]
    [InverseProperty("Boleta")]
    public virtual Pedido IdPedidoNavigation { get; set; } = null!;
}
