using System;
using System.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

class Arvore
{
    public int Raiz { get; set; }

    public int[] Esquerda { get; set; }

    public int[] Direita { get; set; }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("\n *** Tarefa 2 - Criação de uma arvore binaria *** ");

        int[] array1 = { 3, 2, 1, 6, 0, 5 };
        int[] array2 = { 7, 5, 13, 9, 1, 6, 4 };

        // CRIANDO O OBJETO DA ARVORE
        var arvore1 = CriaObjetoArvore(array1);
        var arvore2 = CriaObjetoArvore(array2);

        // EXIBINDO OS VALORES DA ARVORE 1
        Console.WriteLine("\n\n Cenario 1 \n");
        ExibeValoresArvore(array1, arvore1);

        // EXIBINDO O FRONT DA ARVORE 1
        ExibeArvoreBinaria(arvore1);

        // EXIBINDO OS VALORES DA ARVORE 2
        Console.WriteLine("\n\n\n Cenario 2 \n");
        ExibeValoresArvore(array2, arvore2);

        // EXIBINDO O FRONT DA ARVORE 2
        ExibeArvoreBinaria(arvore2);
        
        Console.ReadKey();
    }

    static Arvore CriaObjetoArvore(int[] valores)
    {
        var raiz = valores.Max();
        var galhosEsquerda = valores.TakeWhile(n => n != raiz).OrderByDescending(o => o).ToArray();
        var galhosDireita = valores.Where(w => !galhosEsquerda.Contains(w) && w != raiz).OrderByDescending(o => o).ToArray();

        var arvore = new Arvore()
        {
            Raiz = raiz,
            Esquerda = galhosEsquerda,
            Direita = galhosDireita,
        };

        return arvore;
    }

    static void ExibeValoresArvore(int[] array, Arvore arvore)
    {
        Console.WriteLine("  Array de Entrada: [" + string.Join(", ", array) + "]");
        Console.WriteLine("  Raiz: " + arvore.Raiz);
        Console.WriteLine("  Galhos da Esquerda: " + string.Join(", ", arvore.Esquerda));
        Console.WriteLine("  Galhos da Direita: " + string.Join(", ", arvore.Direita));
    }

    static void ExibeArvoreBinaria(Arvore arvore)
    {
        var prefixo = "            ";
        var prefixoMeio = "    ";

        Console.WriteLine("\n\n" + prefixo + "  " + arvore.Raiz + prefixo);

        var minhaListaEsq = arvore.Esquerda.ToList();
        var minhaListaDir = arvore.Direita.ToList();

        var stringConsole = "";

        while (minhaListaDir.Count > 0 || minhaListaEsq.Count > 0)
        {
            stringConsole = "\n" + prefixo + (minhaListaEsq.Count > 0 ? minhaListaEsq.First() : " ") + prefixoMeio;

            if (minhaListaEsq.Count > 0)
                minhaListaEsq.Remove(minhaListaEsq.First());

            stringConsole += minhaListaDir.Count > 0 ? minhaListaDir.First() : " ";

            if (minhaListaDir.Count > 0)
                minhaListaDir.Remove(minhaListaDir.First());

            prefixo = prefixo.Substring(0, prefixo.Length - 1);
            prefixoMeio += "  ";

            Console.WriteLine(stringConsole);
        }
    }
}