using System;
using System.Collections.Generic;

namespace StarWars.API.Models;

public partial class Role
{
    public int RoleId { get; set; }

    public string Description { get; set; } = null!;

    public int TeamId { get; set; }

    public virtual ICollection<Person> People { get; } = new List<Person>();

    public virtual Team Team { get; set; } = null!;
}
