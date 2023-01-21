using System;
using System.Collections.Generic;

namespace StarWars.API.Models;

public partial class Home
{
    public int HomeId { get; set; }

    public string Description { get; set; } = null!;

    public int ClimateId { get; set; }

    public virtual Climate Climate { get; set; } = null!;

    public virtual ICollection<Person> People { get; } = new List<Person>();
}
