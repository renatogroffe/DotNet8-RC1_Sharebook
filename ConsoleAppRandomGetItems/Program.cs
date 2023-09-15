using System.Runtime.InteropServices;
using System.Text.Json;

Console.WriteLine("***** Testes com .NET 8 | Metodo Random.Shared.GetItems *****");
Console.WriteLine($"Versao do .NET em uso: {RuntimeInformation
    .FrameworkDescription} - Ambiente: {Environment.MachineName} - Kernel: {Environment
    .OSVersion.VersionString}");

Console.WriteLine();
Console.WriteLine("** Testes com string[]");
var sugestoesCidades = new string[]
{
    "Sao Paulo", "Nova York", "Roma", "Cairo", "Paris", "Toquio"
};
Console.WriteLine($"{nameof(sugestoesCidades)} = " +
    JsonSerializer.Serialize(sugestoesCidades));
for (int i = 1; i <= 3; i++)
{
    var escolhas = Random.Shared.GetItems(sugestoesCidades, i);
    Console.WriteLine($"{nameof(sugestoesCidades)} - GetItems {i}/3 = " +
        JsonSerializer.Serialize(escolhas));
}

Console.WriteLine();
Console.WriteLine("** Testes com ReadOnlySpan<string>");
var sugestoesPratos = new ReadOnlySpan<string>(new string[]
{
    "Pizza", "Spaghetti", "Costela bovina", "Sopa", "Bacon", "Esfiha", "Feijoada"
});
Console.WriteLine($"{nameof(sugestoesPratos)} - valor original = " +
    JsonSerializer.Serialize(sugestoesPratos.ToArray()));
for (int i = 1; i <= 3; i++)
{
    var escolhas = Random.Shared.GetItems(sugestoesPratos, i);
    Console.WriteLine($"{nameof(sugestoesPratos)} - GetItems {i}/3 = " +
        JsonSerializer.Serialize(escolhas));
}