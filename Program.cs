using System.Linq;

var videojuegos = DatosDelDocumento.CrearVideojuegos();
var estudiantes = DatosDelDocumento.CrearEstudiantes();
var equipos = DatosDelDocumento.CrearEquipos();

var ejercicios = new (string Titulo, Action Accion)[]
{
    (
        "Videojuegos multijugador",
        () =>
        {
            var nombres = videojuegos.Where(v => v.EsMultijugador).Select(v => v.Nombre);
            foreach (var nombre in nombres)
                Console.WriteLine($"{nombre}");
        }),
    (
        "Estudiantes aprobados",
        () =>
        {
            var aprobados = estudiantes.Where(e => e.Nota >= 3.0);
            foreach (var estudiante in aprobados)
                Console.WriteLine($"{estudiante.Nombre} - {estudiante.Nota}");
        }),
    (
        "Equipos con buen ataque",
        () =>
        {
            var conBuenAtaque = equipos.Where(e => e.GolesFavor > 10);
            foreach (var equipo in conBuenAtaque)
                Console.WriteLine($"{equipo.Nombre} - {equipo.GolesFavor}");
        }),
    (
        "Solo nombres de videojuegos",
        () =>
        {
            var nombres = videojuegos.Select(v => v.Nombre);
            foreach (var nombre in nombres)
                Console.WriteLine($"{nombre}");
        }),
    (
        "Nombre y curso",
        () =>
        {
            var lineas = estudiantes.Select(e => $"{e.Nombre} - {e.Curso}");
            foreach (var linea in lineas)
                Console.WriteLine($"{linea}");
        }),
    (
        "Diferencia de gol",
        () =>
        {
            var filas = equipos.Select(e => new
            {
                e.Nombre,
                DiferenciaDeGol = e.GolesFavor - e.GolesContra
            });
            foreach (var item in filas)
                Console.WriteLine($"{item.Nombre} - {item.DiferenciaDeGol}");
        }),
    (
        "Ranking de videojuegos",
        () =>
        {
            var ranking = videojuegos.OrderByDescending(v => v.Puntos);
            foreach (var v in ranking)
                Console.WriteLine($"{v.Nombre} - {v.Puntos} pts");
        }),
    (
        "Ranking de estudiantes",
        () =>
        {
            var ranking = estudiantes.OrderByDescending(e => e.Nota);
            foreach (var e in ranking)
                Console.WriteLine($"{e.Nombre} - {e.Nota}");
        }),
    (
        "Tabla de posiciones",
        () =>
        {
            var tabla = equipos
                .OrderByDescending(e => e.Puntos)
                .ThenByDescending(e => e.GolesFavor);
            foreach (var e in tabla)
                Console.WriteLine($"{e.Nombre} - {e.Puntos} pts");
        }),
    (
        "Contar videojuegos top",
        () =>
        {
            int cantidad = videojuegos.Count(v => v.Puntos > 90);
            Console.WriteLine($"{cantidad}");
        }),
    (
        "Verificar reprobados",
        () =>
        {
            bool existe = estudiantes.Any(e => e.Nota < 3.0);
            Console.WriteLine($"{existe}");
        }),
    (
        "Mejor equipo",
        () =>
        {
            var mejor = equipos
                .OrderByDescending(e => e.Puntos)
                .ThenByDescending(e => e.GolesFavor)
                .FirstOrDefault();
            if (mejor is null)
                return;
            Console.WriteLine($"{mejor.Nombre} - {mejor.Puntos} pts");
        }),
    (
        "Agrupar estudiantes por curso",
        () =>
        {
            var grupos = estudiantes.GroupBy(e => e.Curso);
            foreach (var grupo in grupos)
            {
                Console.WriteLine($"Curso: {grupo.Key}");
                foreach (var estudiante in grupo)
                    Console.WriteLine($" - {estudiante.Nombre}");
            }
        }),
    (
        "Agrupar videojuegos por género",
        () =>
        {
            var porGenero = videojuegos.GroupBy(v => v.Genero);
            foreach (var g in porGenero)
                Console.WriteLine($"{g.Key}: {g.Count()}");
        }),
    (
        "Reto final",
        () =>
        {
            var resultado = equipos
                .Where(e => e.GolesFavor > e.GolesContra)
                .OrderByDescending(e => e.Puntos)
                .Select(e => new
                {
                    e.Nombre,
                    e.Puntos,
                    DiferenciaGol = e.GolesFavor - e.GolesContra
                });
            foreach (var item in resultado)
                Console.WriteLine($"{item.Nombre} - {item.Puntos} - {item.DiferenciaGol}");
        })
};

while (true)
{
    Consola.Limpiar();
    Console.WriteLine("Taller de LINQ — menú");
    Console.WriteLine(new string('=', 44));
    Console.WriteLine();

    for (var i = 0; i < ejercicios.Length; i++)
        Console.WriteLine($"  {i + 1,2}) {ejercicios[i].Titulo}");

    Console.WriteLine();
    Console.WriteLine("   0) Salir");
    Console.WriteLine();
    Console.Write("Elige una opción: ");

    var entrada = Console.ReadLine();

    if (!int.TryParse(entrada, out var opcion))
    {
        Consola.Limpiar();
        Console.WriteLine("Opción no válida. Pulsa una tecla...");
        Console.ReadKey(intercept: true);
        continue;
    }

    if (opcion == 0)
        break;

    if (opcion < 1 || opcion > ejercicios.Length)
    {
        Consola.Limpiar();
        Console.WriteLine("Opción no válida. Pulsa una tecla...");
        Console.ReadKey(intercept: true);
        continue;
    }

    var elegido = ejercicios[opcion - 1];
    Ejecucion.Ejecutar(elegido.Titulo, elegido.Accion);
}

internal static class DatosDelDocumento
{
    internal static List<Videojuego> CrearVideojuegos() =>
    [
        new Videojuego { Nombre = "Minecraft", Genero = "Sandbox", Puntos = 95, EsMultijugador = true },
        new Videojuego { Nombre = "FIFA", Genero = "Deportes", Puntos = 88, EsMultijugador = true },
        new Videojuego { Nombre = "Celeste", Genero = "Plataformas", Puntos = 92, EsMultijugador = false },
        new Videojuego { Nombre = "Mario Kart", Genero = "Carreras", Puntos = 90, EsMultijugador = true },
        new Videojuego { Nombre = "Hollow Knight", Genero = "Aventura", Puntos = 94, EsMultijugador = false }
    ];

    internal static List<Estudiante> CrearEstudiantes() =>
    [
        new Estudiante { Nombre = "Ana", Edad = 12, Nota = 4.8, Curso = "6A" },
        new Estudiante { Nombre = "Luis", Edad = 13, Nota = 3.2, Curso = "6A" },
        new Estudiante { Nombre = "Marta", Edad = 12, Nota = 4.5, Curso = "6B" },
        new Estudiante { Nombre = "Carlos", Edad = 14, Nota = 2.9, Curso = "6B" },
        new Estudiante { Nombre = "Sofía", Edad = 13, Nota = 5.0, Curso = "6A" }
    ];

    internal static List<Equipo> CrearEquipos() =>
    [
        new Equipo { Nombre = "Tigres FC", Puntos = 15, GolesFavor = 12, GolesContra = 6 },
        new Equipo { Nombre = "Leones FC", Puntos = 22, GolesFavor = 18, GolesContra = 10 },
        new Equipo { Nombre = "Águilas FC", Puntos = 19, GolesFavor = 10, GolesContra = 5 },
        new Equipo { Nombre = "Toros FC", Puntos = 8, GolesFavor = 6, GolesContra = 14 }
    ];
}

internal static class Consola
{
    /// <summary>Borra bien la ventana (en algunas consolas <see cref="Console.Clear"/> deja restos del menú).</summary>
    internal static void Limpiar()
    {
        if (Console.IsOutputRedirected)
        {
            Console.Clear();
            return;
        }

        try
        {
            Console.Write("\x1b[3J\x1b[2J\x1b[H");
            Console.Out.Flush();
        }
        catch
        {
            // Terminal sin secuencias VT
        }

        try
        {
            Console.Clear();
            Console.SetCursorPosition(0, 0);
        }
        catch
        {
            Console.Clear();
        }

        Console.Out.Flush();
    }
}

internal static class Ejecucion
{
    internal static void Ejecutar(string tituloDelTaller, Action accion)
    {
        Consola.Limpiar();
        Console.WriteLine($"{tituloDelTaller}");
        var anchoSeparador = Math.Max(44, tituloDelTaller.Length);
        Console.WriteLine(new string('=', anchoSeparador));
        Console.WriteLine();

        accion();

        Console.WriteLine();
        Console.WriteLine("Pulsa una tecla para volver al menú...");
        Console.ReadKey(intercept: true);
    }
}

public class Videojuego
{
    public string Nombre { get; set; } = string.Empty;
    public string Genero { get; set; } = string.Empty;
    public int Puntos { get; set; }
    public bool EsMultijugador { get; set; }
}

public class Estudiante
{
    public string Nombre { get; set; } = string.Empty;
    public int Edad { get; set; }
    public double Nota { get; set; }
    public string Curso { get; set; } = string.Empty;
}

public class Equipo
{
    public string Nombre { get; set; } = string.Empty;
    public int Puntos { get; set; }
    public int GolesFavor { get; set; }
    public int GolesContra { get; set; }
}
