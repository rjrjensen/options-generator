namespace OptionsGenerator;

using System.Text.Json;
using Microsoft.CodeAnalysis;

[Generator]
public class OptionsGenerator : ISourceGenerator
{
    public void Initialize(GeneratorInitializationContext context)
    {
    }

    public void Execute(GeneratorExecutionContext context)
    {
        var appSettingsFile = context.AdditionalFiles.FirstOrDefault(file => file.Path.EndsWith("appsettings.json"));

        if (appSettingsFile is null) return;
        
        var appSettings = appSettingsFile.GetText(context.CancellationToken)?.ToString();
        
        if (string.IsNullOrWhiteSpace(appSettings)) return;

        var json = JsonDocument.Parse(appSettings);
        
        var obj = json.Deserialize<object> ();

        var root = json.RootElement.;
    }
}
