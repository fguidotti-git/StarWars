using System;
using System.Collections.Generic;

namespace StarWars.API.Models;

public partial class Relation
{
    public int RelationId { get; set; }

    public string Description { get; set; } = null!;

    public virtual ICollection<Object> Objects { get; } = new List<Object>();
}
