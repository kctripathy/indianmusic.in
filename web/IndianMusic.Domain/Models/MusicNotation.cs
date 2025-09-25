using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace IndianMusic.Domain.Models;

public partial class MusicNotation
{
    [Key]
    [Column("NotationID")]
    public int NotationId { get; set; }

    [Column("MusicID")]
    public int? MusicId { get; set; }

    [StringLength(2)]
    [Unicode(false)]
    public string? LineType { get; set; }

    public int LineNumber { get; set; }

    public int BitNumber { get; set; }

    [StringLength(10)]
    public string? Notation { get; set; }

    [ForeignKey("MusicId")]
    [InverseProperty("MusicNotations")]
    public virtual MusicPiece? Music { get; set; }
}
