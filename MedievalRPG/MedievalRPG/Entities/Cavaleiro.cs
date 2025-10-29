using MedievalRPG.Entities.Abstractions;

namespace MedievalRPG.Entities;

public class Cavaleiro : Personagem
{
    public Cavaleiro(string nome) : base(nome, Dado.Range(100, 200), Dado.Range(10, 20), Enums.Classe.Cavaleiro) { }

    public override void UsarPoderEspecial(Personagem alvo)
    {
        if (Dado.Chance(30))
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"(ESPECIAL) {Nome} usa ESCUDO HEROICO, aumentando sua armadura drasticamente!");
            Console.ResetColor();
            Curar(20);
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine($"(ESPECIAL) {Nome} investe com CARGA PESADA, causando dano extra!");
            Console.ResetColor();
            alvo.ReceberDano(DanoBase + 20);
        }
    }
}

