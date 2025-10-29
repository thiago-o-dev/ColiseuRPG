using MedievalRPG.Entities.Abstractions;
using MedievalRPG.Entities.Enums;

namespace MedievalRPG.Entities;

public class Ladino : Personagem
{
    public Ladino(string nome) : base(nome, Dado.Range(80, 130), Dado.Range(20, 30), Classe.Ladino) { }

    public override void UsarPoderEspecial(Personagem alvo)
    {
        if (Dado.Chance(50))
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"(ESPECIAL) {Nome} usa NEVOA OBSCURA, se esconde e recupera 30 de vida!");
            Console.ResetColor();
            Curar(30);
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"(ESPECIAL) {Nome} tenta se esconder, mas falha! Aproveita para dar um golpe rápido.");
            Console.ResetColor();
            alvo.ReceberDano(Dado.Rolar(12));
        }
    }
}