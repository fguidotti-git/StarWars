using System;
using System.Collections.Generic;

namespace StarWars.API.Models;

public partial class Climate
{
    public int ClimateId { get; set; }

    public string Description { get; set; } = null!;

    public virtual ICollection<Home> Homes { get; } = new List<Home>();
}
