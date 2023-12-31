﻿using Bnaya.TypePatterns.Generators;

namespace Bnaya.TypePatterns.Generators.Playground;

[Partial]
public partial class Class1
{
    public Class1(int value, string name)
    {
        this.Value = value;
        Name = name;
    }

    public int Value { get; }
    public string Name { get; }
}
