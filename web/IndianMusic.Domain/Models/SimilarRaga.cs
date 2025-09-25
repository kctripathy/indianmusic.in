using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace IndianMusic.Domain.Models;

public partial class SimilarRaga
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("RagaID")]
    public int? RagaId { get; set; }

    [Column("SimilarRagaID")]
    public int? SimilarRagaId { get; set; }

    [ForeignKey("RagaId")]
    [InverseProperty("SimilarRagaRagas")]
    public virtual Raga? Raga { get; set; }

    [ForeignKey("SimilarRagaId")]
    [InverseProperty("SimilarRagaSimilarRagaNavigations")]
    public virtual Raga? SimilarRagaNavigation { get; set; }
}
