using NUnit.Framework.Legacy;


namespace Tests;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test1()
    {
        Pin p = new Pin();
        ClassicAssert.False(p.Expend(250));
        ClassicAssert.True(p.Expend(351));
        p.Expend(250);
        p.Expend(250);
        p.Expend(250);
        ClassicAssert.True(p.Expend(250));
        
    }
}