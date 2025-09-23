# Tarea Programada 1 - TP1 Suma Aritmética

**Nombre:** Sebastian Vargas Pacheco  
**Carné:** FH23015557  

---

## Comandos de dotnet utilizados (CLI).

**Respuesta:**
mkdir PP1, cd PP1, dotnet new sln --name PracticaProgramada1, dotnet new console -f net8.0 -o SAritmetica, dotnet sln add SAritmetica, cd SAritmetica, dotnet build, dotnet run

## Recursos Consultados

- https://chat.openai.com/

---

## Prompts utilizados

### ChatGPT

**Prompt:**  
Si en un trabajo de suma aritmética se busca que al crecer n los resultados empiecen a verse negativos por overflow, que mecanismo de C# me recomiendas para esta situación ?

**Respuesta:**  
Usar el contexto unchecked en las operaciones enteras relevantes (suma/multiplicación). Esto evita excepciones por overflow y permite observar el desbordamiento esperado. Se sugiere aplicarlo solo en esos cálculos, manteniendo el resto del código con las comprobaciones habituales.

---

### ChatGPT

**Prompt:**  
Implementa un metodo SumIte(int n) que retorne la suma de los primeros números enteros positivos (1 + 2 + … + n), pero utilizando una versión iterativa que sea equivalente a la función recursiva:
SumRec(1) = 1
SumRec(n) = n + SumRec(n - 1)
El método debe recibir un entero positivo n > 0 y retornar un int.

**Respuesta:**  
static int SumIte(int n)
{
    long nn = n;
    long exact = nn * (nn + 1) / 2;
    return unchecked((int)exact);
}

---

### ChatGPT

**Prompt:**  
teniendo este codigo: using System;

static class Program
{
        static int SumFor(int n) => unchecked(n * (n + 1) / 2);

        static int SumIte(int n)
    {
    long nn = n;
    long exact = nn * (nn + 1) / 2;   
    return unchecked((int)exact);     
    }

       static (int n, int sum) BuscarUltimoValidoAscendente(Func<int, int> f)
    {
        int lastN = 0, lastSum = 0;
        for (int n = 1; n > 0; n++)   
        {
            int s = f(n);
            if (s <= 0) return (lastN, lastSum);
            lastN = n; lastSum = s;
        }
        return (lastN, lastSum);
    }

       static (int n, int sum) BuscarPrimeroValidoDescendente(Func<int, int> f)
    {
        for (int n = int.MaxValue; n >= 1; n--)
        {
            int s = f(n);
            if (s > 0) return (n, s);
        }
        return (0, 0);
    } me ayudas con el metodo Main() que llame las funciones de busqueda del codigo (BuscarUltimoValidoAscendente)(BuscarPrimeroValidoDescendente) encargando a SumFor y SumIte, ten en cuenta que se debe imprimir en consola, con la logica esta bien no hace falta que me des algo mas, basicamente metodo x estrategia sino me equivoco se podria usar var.

**Respuesta:**  
¡Así lo veo! Aquí tienes solo el Main() usando var, llamando a tus funciones de búsqueda con SumFor y SumIte, e imprimiendo en consola:

static void Main()
{
    var resulAscendenteFor   = BuscarUltimoValidoAscendente(SumFor);
    var resulDescendenteFor  = BuscarPrimeroValidoDescendente(SumFor);

    var resulAscendenteIte   = BuscarUltimoValidoAscendente(SumIte);
    var resulDescendenteIte  = BuscarPrimeroValidoDescendente(SumIte);

    Console.WriteLine("• SumFor:");
    Console.WriteLine($"\t◦ From 1 to Max → n: {resulAscendenteFor.n} → sum: {resulAscendenteFor.sum}");
    Console.WriteLine($"\t◦ From Max to 1 → n: {resulDescendenteFor.n} → sum: {resulDescendenteFor.sum}");
    Console.WriteLine();
    Console.WriteLine("• SumIte:");
    Console.WriteLine($"\t◦ From 1 to Max → n: {resulAscendenteIte.n} → sum: {resulAscendenteIte.sum}");
    Console.WriteLine($"\t◦ From Max to 1 → n: {resulDescendenteIte.n} → sum: {resulDescendenteIte.sum}");
}

---

**Pregunta:**
¿Por qué todos los valores resultantes tanto de n como de sum difieren entre métodos (fórmula e implementación iterativa) y estrategias (ascendente y descendente)?

**Respuesta:**
Mas que todo seria porque cada método maneja el overflow de enteros de una manera distinta por ejemplo en SumFor se usa la multiplicación por el otro lado SumIte suma iterativamente y permite reunir mas valores antes del overflow  y básicamente tanto la estrategia ascendente como la descendente tienen diferentes puntos del overflow ya que una busca el ultimo valor valido ósea ascendente y la otra el primer valor valido ósea descendente.

---

**Pregunta:**
¿Qué cree que sucedería si se utilizan las mismas estrategias (ascendente y descendente) pero con el método recursivo de suma (SumRec)?

**Respuesta:**
Con el método recursivo SumRec en ambas estrategias básicamente tendría el método mas limitado primero en el contexto de ascendente encontraría un n valido bastante menor que los otros métodos ya que en cuestión de memoria del stack las recursivas van por delante y eso causa un stackoverflowexception antes de poder llegar al overflow aritmético y por el lado descendente por el stack overflow fallaría prácticamente de inmediato y eso lleva a que pueda tener un rango de valores mas pequeños que SumFor y SumIte.