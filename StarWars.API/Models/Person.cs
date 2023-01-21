using System;
using System.Collections.Generic;

namespace StarWars.API.Models;

public partial class Person
{
    public int PersonId { get; set; }

    public string Name { get; set; } = null!;

    public int RoleId { get; set; }

    public int HomeId { get; set; }

    public virtual Home Home { get; set; } = null!;

    public virtual ICollection<Object> ObjectPeople { get; } = new List<Object>();

    public virtual ICollection<Object> ObjectRelateds { get; } = new List<Object>();

    public virtual Role Role { get; set; } = null!;
}
