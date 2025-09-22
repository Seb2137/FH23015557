using System;

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
    }

    static void Main()
    {
        var resulAscendenteFor   = BuscarUltimoValidoAscendente(SumFor);
        var resulDescendenteFor = BuscarPrimeroValidoDescendente(SumFor);

        var resulAscendenteIte   = BuscarUltimoValidoAscendente(SumIte);
        var resulDescendenteIte = BuscarPrimeroValidoDescendente(SumIte);

        Console.WriteLine("• SumFor:");
        Console.WriteLine($"\t◦ From 1 to Max → n: {resulAscendenteFor.n} → sum: {resulAscendenteFor.sum}");
        Console.WriteLine($"\t◦ From Max to 1 → n: {resulDescendenteFor.n} → sum: {resulDescendenteFor.sum}");
        Console.WriteLine();
        Console.WriteLine("• SumIte:");
        Console.WriteLine($"\t◦ From 1 to Max → n: {resulAscendenteIte.n} → sum: {resulAscendenteIte.sum}");
        Console.WriteLine($"\t◦ From Max to 1 → n: {resulDescendenteIte.n} → sum: {resulDescendenteIte.sum}");
    }
}