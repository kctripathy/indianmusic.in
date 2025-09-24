using System;
using System.Collections.Generic;

namespace IndianMusic.Domain.Models;

public partial class SimilarRaga
{
    public int Id { get; set; }

    public int? RagaId { get; set; }

    public int? SimilarRagaId { get; set; }

    public virtual Raga? Raga { get; set; }

    public virtual Raga? SimilarRagaNavigation { get; set; }
}
