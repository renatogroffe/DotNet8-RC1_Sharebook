using System.Runtime.InteropServices;
using System.Text.Json;

Console.WriteLine("***** Testes com .NET 8 | Metodo Random.Shared.Shuffle *****");
Console.WriteLine($"Versao do .NET em uso: {RuntimeInformation
    .FrameworkDescription} - Ambiente: {Environment.MachineName} - Kernel: {Environment
    .OSVersion.VersionString}");

Console.WriteLine();
Console.WriteLine("** Testes com string[]");
var sugestoesCidades = new string[]
{
    "Sao Paulo", "Nova York", "Roma", "Cairo", "Paris", "Toquio"
};
Console.WriteLine($"{nameof(sugestoesCidades)} - valor original = " +
    JsonSerializer.Serialize(sugestoesCidades));
for (int i = 1; i <= 3; i++)
{
    Random.Shared.Shuffle(sugestoesCidades);
    Console.WriteLine($"{nameof(sugestoesCidades)} - Shuffle {i}/3 = " +
        JsonSerializer.Serialize(sugestoesCidades));
}

Console.WriteLine();
Console.WriteLine("** Testes com Span<string>");
var sugestoesPratos = new Span<string>(new string[]
{
    "Pizza", "Spaghetti", "Costela bovina", "Sopa", "Bacon", "Esfiha", "Feijoada"
});
Console.WriteLine($"{nameof(sugestoesPratos)} - valor original = " +
    JsonSerializer.Serialize(sugestoesPratos.ToArray()));
for (int i = 1; i <= 3; i++)
{
    Random.Shared.Shuffle(sugestoesPratos);
    Console.WriteLine($"{nameof(sugestoesPratos)} - Shuffle {i}/3 = " +
        JsonSerializer.Serialize(sugestoesPratos.ToArray()));
}