namespace OptionsGeneratorTests;

using VerifyCS = CSharpSourceGeneratorVerifier<YourGenerator>; And use the following in your test method:

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        var code = "initial code";
        var generated = "expected generated code";
        await new VerifyCS.Test
        {
            TestState = 
            {
                Sources = { code },
                GeneratedSources =
                {
                    (typeof(YourGenerator), "GeneratedFileName", SourceText.From(generated, Encoding.UTF8, SourceHashAlgorithm.Sha256)),
                },
            },
        }.RunAsync();
    }
}
