using System;
using System.Collections.Generic;

namespace StarWars.API.Models;

public partial class Object
{
    public int PersonId { get; set; }

    public int RelatedId { get; set; }

    public int RelationId { get; set; }

    public virtual Person Person { get; set; } = null!;

    public virtual Person Related { get; set; } = null!;

    public virtual Relation Relation { get; set; } = null!;
}
