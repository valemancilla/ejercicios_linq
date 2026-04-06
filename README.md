# ejercicios_linq

Proyecto de consola en C# alineado con el material **«Ejercicios progresivos de LINQ en C#»** (archivo tipo `Ejercicios progresivos de LINQ en C# (1).md`): **taller de 15 ejercicios de LINQ en C#**, pensado para aprender paso a paso con ejemplos cercanos.

---

## Descripción del proyecto

**ejercicios_linq** es una **aplicación de consola** que implementa el **Taller de 15 ejercicios** del documento del docente. Trabaja con las mismas **tres colecciones** definidas en la **Base del taller** del material:

- **`Videojuego`** — `Nombre`, `Genero`, `Puntos`, `EsMultijugador`
- **`Estudiante`** — `Nombre`, `Edad`, `Nota`, `Curso`
- **`Equipo`** — `Nombre`, `Puntos`, `GolesFavor`, `GolesContra`

Las listas de ejemplo coinciden con el documento: **5** videojuegos, **5** estudiantes y **4** equipos (Minecraft, FIFA, Ana, Luis, Tigres FC, Leones FC, etc.).

El programa muestra un **menú** donde el usuario elige **1 a 15** (cada número es un ejercicio del taller) o **0** para salir. Tras cada elección se limpia la consola, se muestra el **título del ejercicio** (con separador) y el **resultado** de la consulta LINQ.

**Base técnica** (según el propio documento del taller): LINQ ofrece un modelo consistente para consultar datos en C#; la mayoría de operadores sobre colecciones son **métodos de extensión** sobre **`IEnumerable<T>`**; muchas consultas que devuelven secuencias usan **ejecución diferida**, mientras que operaciones como **`Count`** o **`FirstOrDefault`** suelen ejecutarse **de inmediato**.

**Contenido del taller en el menú** (mismo orden y enunciados que el documento):

| Menú | Bloque | Qué pide el material |
|:---:|:---:|---|
| 1 | **Bloque 1 · Filtrar** | Nombres de videojuegos multijugador (`Where`, `Select`) |
| 2 | **Bloque 1 · Filtrar** | Estudiantes con nota ≥ 3,0 |
| 3 | **Bloque 1 · Filtrar** | Equipos con más de 10 goles a favor |
| 4 | **Bloque 2 · Transformar** | Solo nombres de todos los videojuegos |
| 5 | **Bloque 2 · Transformar** | Formato `Nombre - Curso` |
| 6 | **Bloque 2 · Transformar** | `Nombre - DiferenciaDeGol` (GolesFavor − GolesContra) |
| 7 | **Bloque 3 · Ordenar** | Ranking de videojuegos por puntos (mayor a menor) |
| 8 | **Bloque 3 · Ordenar** | Ranking de estudiantes por nota (mayor a menor) |
| 9 | **Bloque 3 · Ordenar** | Tabla de posiciones: puntos; empate por goles a favor |
| 10 | **Bloque 4 · Consultas rápidas** | Contar videojuegos con más de 90 puntos |
| 11 | **Bloque 4 · Consultas rápidas** | ¿Existe estudiante con nota &lt; 3,0? |
| 12 | **Bloque 4 · Consultas rápidas** | Primer equipo de la tabla de posiciones |
| 13 | **Bloque 5 · Agrupar y combinar** | Agrupar estudiantes por curso |
| 14 | **Bloque 5 · Agrupar y combinar** | Agrupar videojuegos por género y cantidad |
| 15 | **Bloque 5 · Agrupar y combinar** | Reto: DG positiva, orden por puntos; Nombre, Puntos, DiferenciaGol |

> El material también incluye **Niveles 1 a 5** con ejemplos introductorios; este repositorio concentra la entrega en el **taller de 15** anteriormente listado.

**Ejecución:** en la carpeta del proyecto, `dotnet run`.

---

## Características destacadas

| Característica | Descripción |
|----------------|-------------|
| **Alineación con el docente** | Enunciados, datos y bloques 1–5 según *Ejercicios progresivos de LINQ en C#*. |
| **Menú interactivo** | Opciones **1–15** (ejercicios) y **0** (salir). |
| **Operadores LINQ** | `Where`, `Select`, `OrderByDescending`, `ThenByDescending`, `Count`, `Any`, `FirstOrDefault`, `GroupBy`, tipos anónimos donde aplica. |
| **Interfaz de consola** | Título *Taller de LINQ — menú*, separadores con `=` en menú y en cada ejercicio. |
| **`Consola.Limpiar()`** | Borrado de pantalla reforzado (secuencias VT + `Console.Clear` + `Flush`) para evitar restos del menú. |
| **Código organizado** | Arreglo de tuplas `(Título, Acción)` para los 15 ejercicios; clases auxiliares `DatosDelDocumento`, `Ejecucion`, `Consola`. |
| **C# moderno** | Top-level statements, nullable reference types, implicit usings. |

---

## Objetivo

- **Aprender** los operadores que el documento marca como esenciales: **`Where`** (filtrar), **`Select`** (proyectar o transformar), **`OrderBy`** y **`ThenBy`** (ordenar; en el código se usan variantes **Descending** cuando el enunciado pide de mayor a menor), **`Count`** y **`Any`** (consultas rápidas), **`FirstOrDefault`** (obtener un elemento) y **`GroupBy`** (agrupar por clave), documentados por Microsoft como operadores estándar de consulta LINQ.
- **Aplicar** esos operadores sobre **videojuegos**, **estudiantes** y **equipos**, resolviendo los **15 ejercicios** del taller en un solo programa ejecutable.
- **Comprender** la diferencia entre consultas con **ejecución diferida** y operaciones que se ejecutan **al instante** (`Count`, `FirstOrDefault`), tal como explica el material del docente.

---

## Tecnologías utilizadas

| Tecnología | Uso en el proyecto |
|------------|---------------------|
| **C#** | Lenguaje de implementación. |
| **.NET** (`net10.0` en `ejercicios_linq.csproj`) | Plataforma de compilación y ejecución. |
| **LINQ** (`System.Linq`) | Consultas con sintaxis de métodos sobre colecciones en memoria. |
| **Consola** (`System.Console`) | Menú, salida de resultados y lectura de opciones. |

**Herramientas recomendadas:** Visual Studio, Visual Studio Code, Cursor o Rider, con **SDK de .NET** compatible con el proyecto.

---

## Estructura del sistema

```
ejercicios_linq/
├── Program.cs                 # Aplicación: datos, 15 ejercicios, menú, Consola, Ejecucion, modelos
├── ejercicios_linq.csproj     # Definición del proyecto (Exe, net10.0)
├── ejercicios_linq.sln        # Solución
├── README.md                  # Documentación del proyecto (este archivo)
├── PROYECTO.md                # Enlace breve a README.md
├── bin/                       # Salida de compilación (generada)
└── obj/                       # Archivos intermedios (generados)
```

**Flujo:** se cargan las listas (`DatosDelDocumento`) → el **menú** pide una opción → si es **1–15**, se llama a **`Ejecucion.Ejecutar`**, que limpia la pantalla, muestra el título del ejercicio y ejecuta la **acción LINQ** correspondiente → al pulsar una tecla se vuelve al menú.

---

## Qué hace cada archivo

| Archivo | Función |
|---------|---------|
| **`Program.cs`** | Punto de entrada; creación de `videojuegos`, `estudiantes` y `equipos`; arreglo de **15** ejercicios como lambdas LINQ; bucle **`while`** del menú; clase **`Consola`** (`Limpiar`); clase **`Ejecucion`** (`Ejecutar`); clase **`DatosDelDocumento`** (listas iguales a la base del taller); modelos **`Videojuego`**, **`Estudiante`**, **`Equipo`**. |
| **`ejercicios_linq.csproj`** | Configura el proyecto como **ejecutable**, framework **net10.0**, **implicit usings** y **nullable** habilitados. |
| **`ejercicios_linq.sln`** | Agrupa el proyecto para abrir y compilar desde el IDE o `dotnet build`. |
| **`README.md`** | Describe el proyecto según el material *Ejercicios progresivos de LINQ en C#* y las secciones pedidas en la entrega. |
| **`PROYECTO.md`** | Indica que la documentación detallada está en **README.md**. |

Las carpetas **`bin`** y **`obj`** las genera el compilador; no deben editarse a mano.

---

## Autor

**Nombre:** *[Escribe aquí tu nombre completo, curso o grupo, según lo exija tu institución.]*

**Referencia académica:** implementación del taller descrito en **Ejercicios progresivos de LINQ en C#** (taller de **15** ejercicios, cinco bloques).
