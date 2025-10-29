using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedievalRPG.Entities;

public static class Dado
{
    private static readonly Random random = new Random();

    public static int Rolar(int lados)
    {
        return random.Next(1, lados + 1);
    }

    public static bool Chance(int chancePercentual)
    {
        return random.Next(1, 101) <= chancePercentual;
    }

    public static int Range(int ValMin, int ValMax)
    {
        return random.Next(ValMin, ValMax + 1);
    }

    public static T EscolherAleatoriamente<T>(List<T> lista)
    {
        if (lista == null || lista.Count == 0)
        {
            throw new InvalidOperationException("A lista de escolha não pode ser nula ou vazia.");
        }
        int indice = random.Next(lista.Count);
        return lista[indice];
    }
}
