﻿using System;

namespace UtilLibrary.MsSqlRepsoitory
{
    public interface IFullBooks : IItems
    {
        string Author { get; set; }
        int ISBN { get; set; }
        string Category { get; set; }
        int Pages { get; set; }
        string Publisher { get; set; }
    }
}