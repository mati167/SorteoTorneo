// Verificar si se pasó un argumento
using Sorteador;
using SorteoTorneo;
using System.Globalization;
using System.Text.Json;

if (args.Length == 0)
{
    Console.WriteLine("Por favor, pase la ruta del archivo JSON como un argumento.");
    return;
}
Funciones _funciones = new Funciones();
if (args[1] == "0")
{
    // Leer la ruta del archivo desde el primer argumento
    string filePath = args[1];
    int indice = int.Parse(args[2]);
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
        if ((j + 1) < indice)
            File.WriteAllText("sorteo/grupos" + (j + 1) + ".json", jsonString);
        else
            File.WriteAllText("gruposFinal.json", jsonString);
    }
}
if(args[2] == "1")
{
    // Leer la ruta del archivo desde el primer argumento
    string filePath = args[1];
    string fileSegundos = args[2];
    int indice = int.Parse(args[3]);
    // Verificar si el archivo existe
    if (!File.Exists(filePath) || !File.Exists(fileSegundos))
    {
        Console.WriteLine("El archivo especificado no existe.");
        return;
    }

    // Leer el contenido del archivo
    string json1;
    try
    {
        json1 = File.ReadAllText(filePath);
    }
    catch (Exception ex)
    {
        Console.WriteLine("Error al leer el archivo: " + ex.Message);
        return;
    }
    List<Cancion> primeros = _funciones.Reader(json1);
    string json2;
    try
    {
        json2 = File.ReadAllText(filePath);
    }
    catch (Exception ex)
    {
        Console.WriteLine("Error al leer el archivo: " + ex.Message);
        return;
    }
    List<Cancion> segundos = _funciones.Reader(json2);


    for (int j = 0; j < indice; j++)
    {

        List<Cancion> can1 = primeros.ToList();
        List<Cancion> can2 = segundos.ToList();
        // Crear una instancia de la clase Random
        Random random = new Random();

        List<Grupo> grupos = new();

        int g = 0;
        while (can1.Count > 0)
        {// Seleccionar un índice aleatorio
            g++;
            Grupo grupo = new Grupo();
            grupo.temas = new();
                int indiceAleatorio1 = random.Next(can1.Count);
            int indiceAleatorio2 = random.Next(can2.Count);
            // Obtener el objeto aleatorio
            Cancion can = can1[indiceAleatorio1];
                grupo.temas.Add(can);
            can = can2[indiceAleatorio2];
            can1.RemoveAt(indiceAleatorio1);
            can2.RemoveAt(indiceAleatorio2);
            grupo.grupo = g;
            grupos.Add(grupo);
        }

        string jsonString = JsonSerializer.Serialize(grupos);
        if ((j + 1) < indice)
            File.WriteAllText("sorteo/SegundaRonda" + (j + 1) + ".json", jsonString);
        else
            File.WriteAllText("SegundaRondaFINAL.json", jsonString);
    }


}

