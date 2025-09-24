using System;
using System.Collections.Generic;

namespace IndianMusic.Domain.Models;

public partial class MusicNotation
{
    public int NotationId { get; set; }

    public int? MusicId { get; set; }

    public string? LineType { get; set; }

    public int LineNumber { get; set; }

    public int BitNumber { get; set; }

    public string? Notation { get; set; }

    public virtual MusicPiece? Music { get; set; }
}
