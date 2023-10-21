# TypePatterns Generators

This package show how to mimic Typescropt's [Utility Types](https://www.typescriptlang.org/docs/handbook/utility-types.html) using Source Code Generator.

```cs
[Partial]
public readonly partial record struct RecStruct(int? Value, string Name)
{
    public required int Quantity { get; init; }
    public string Tag { get; init; } = string.Empty;

    public string Description => $"{Name}: {Quantity}";
}
```

Will generate:

```cs
public record struct RecStructNullable
{
	public int? Value{ get; init; }
	public string? Name{ get; init; }
	public int? Quantity{ get; init; }
	public string? Tag{ get; init; }
}
```

And

```cs
partial record struct RecStruct
{
	public static RecStruct operator +(RecStruct a, RecStructNullable b)
	{
		var result = a with {
			Value = b.Value ?? a.Value,
			Name = b.Name ?? a.Name,
			Quantity = b.Quantity ?? a.Quantity,
			Tag = b.Tag ?? a.Tag,
		};
		return result;
	}
}
```

As result, the following test, pass.

```cs
[Fact]
public void RecStruct1_Test()
{
    var r = new RecStruct1 { Value = -150, Name = "Be'ery 😞", Quantity = -150 };
    var rn = new RecStruct1Nullable { Value = -160 };

    var r2 = r + rn;

    Assert.Equal(r.Name, r2.Name);
    Assert.Equal(r.Quantity, r2.Quantity);
    Assert.Equal(rn.Value, r2.Value);
}
```
