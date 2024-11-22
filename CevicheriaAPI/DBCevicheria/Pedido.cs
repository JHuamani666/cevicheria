using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CevicheriaAPI.DBCevicheria;

[Index("IdUsuario", Name = "idx_pedido_usuario")]
public partial class Pedido
{
    [Key]
    [Column("ID_Pedido")]
    public int IdPedido { get; set; }

    [Column("ID_Usuario")]
    public int IdUsuario { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? FechaPedido { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Estado { get; set; }

    [Column(TypeName = "text")]
    public string? ComentarioCliente { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal TotalPedido { get; set; }

    [InverseProperty("IdPedidoNavigation")]
    public virtual ICollection<Boleta> Boleta { get; set; } = new List<Boleta>();

    [InverseProperty("IdPedidoNavigation")]
    public virtual ICollection<DetallePedido> DetallePedidos { get; set; } = new List<DetallePedido>();

    [ForeignKey("IdUsuario")]
    [InverseProperty("Pedidos")]
    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
}
