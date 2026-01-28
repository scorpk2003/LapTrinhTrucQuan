using System;
using System.Collections.Generic;

namespace QuanLyPhongTro.Entities;

public partial class PersonDetail
{
    public Guid Id { get; set; }

    public string? Name { get; set; }

    public string? Cccd { get; set; }

    public byte[]? CccdImage { get; set; }

    public string? Phone { get; set; }

    public byte[]? Avatar { get; set; }

    public string? Gender { get; set; }

    public string? Gmail { get; set; }

    public virtual Person? Person { get; set; }
}
