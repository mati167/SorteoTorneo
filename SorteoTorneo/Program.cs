// Verificar si se pasó un argumento
using Sorteador;
using SorteoTorneo;
using System.Text.Json;

if (args.Length == 0)
{
    Console.WriteLine("Por favor, pase la ruta del archivo JSON como un argumento.");
    return;
}
// Leer la ruta del archivo desde el primer argumento
string filePath = args[0];
int indice = int.Parse(args[1]);
// Verificar si el archivo existe
if (!File.Exists(filePath))
{
    Console.WriteLine("El archivo especificado no existe.");
    return;
}

// Leer el contenido del archivo
string json;
try
{
    json = File.ReadAllText(filePath);
}
catch (Exception ex)
{
    Console.WriteLine("Error al leer el archivo: " + ex.Message);
    return;
}
//string json = args[0];
Funciones _funciones = new Funciones();
List<Cancion> sorteo = _funciones.Reader(json);
for (int j = 0; j < indice; j++)
{

    List<Cancion> canciones = sorteo.ToList();
    // Crear una instancia de la clase Random
    Random random = new Random();

    List<Grupo> grupos = new();

    int g = 0;
    while (canciones.Count > 0)
    {// Seleccionar un índice aleatorio
        g++;
        Grupo grupo = new Grupo();
        grupo.temas = new();
        for (int i = 0; i < 3; i++)
        {
            int indiceAleatorio = random.Next(canciones.Count);
            // Obtener el objeto aleatorio
            Cancion can = canciones[indiceAleatorio];
            grupo.temas.Add(can);
            canciones.RemoveAt(indiceAleatorio);
        }
        grupo.grupo = g;
        grupos.Add(grupo);
    }

    string jsonString = JsonSerializer.Serialize(grupos);
    if((j+1) < indice)
        File.WriteAllText("sorteo/grupos"+(j+1) +".json", jsonString);
    else
        File.WriteAllText("gruposFinal.json", jsonString);
}

