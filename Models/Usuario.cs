using System;
using System.Collections.Generic;

namespace MVC.Models;

/// <summary>
/// Create user
/// </summary>
public partial class Usuario
{
    public int IdUsuarios { get; set; }

    public string SUsername { get; set; } = null!;

    public string SPassword { get; set; } = null!;
}
