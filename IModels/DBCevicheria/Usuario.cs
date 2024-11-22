using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DBModel.DBCevicheria;

[Index("CorreoElectronico", Name = "UQ__Usuarios__531402F39A979E52", IsUnique = true)]
[Index("CorreoElectronico", Name = "idx_usuario_correo")]
public partial class Usuario
{
    [Key]
    [Column("ID_Usuario")]
    public int IdUsuario { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string Nombre { get; set; } = null!;

    [StringLength(100)]
    [Unicode(false)]
    public string CorreoElectronico { get; set; } = null!;

    [StringLength(100)]
    [Unicode(false)]
    public string Password { get; set; } = null!;

    [StringLength(50)]
    [Unicode(false)]
    public string DocumentoIdentidad { get; set; } = null!;

    [StringLength(50)]
    [Unicode(false)]
    public string Rol { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime? FechaRegistro { get; set; }

    [InverseProperty("IdUsuarioNavigation")]
    public virtual ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();
}
