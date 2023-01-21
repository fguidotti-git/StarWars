using System;
using System.Collections.Generic;

namespace StarWars.API.Models;

public partial class Team
{
    public int TeamId { get; set; }

    public string Description { get; set; } = null!;

    public virtual ICollection<Role> Roles { get; } = new List<Role>();
}
