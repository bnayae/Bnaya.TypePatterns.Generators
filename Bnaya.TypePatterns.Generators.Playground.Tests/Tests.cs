using Bnaya.TypePatterns.Generators.Playground;
using Xunit;

namespace Bnaya.TypePatterns.Generators.Tests;

public class BulderPatternGenerationTests
{
    [Fact]
    public void Rec_Test()
    {
        var r = new Rec1 (-150, "Be'ery 😞");
        var rn = new Rec1Nullable { Value = -160 };

        var r2 = r + rn;

        Assert.Equal(r.Name, r2.Name);
        Assert.Equal(rn.Value, r2.Value);
    }

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
}

