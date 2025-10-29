using MedievalRPG.Entities.Abstractions;
using MedievalRPG.Entities.Enums;

namespace MedievalRPG.Entities;

public class Arqueiro : Personagem
{
    public Arqueiro(string nome) : base(nome, Dado.Range(100, 150), Dado.Range(15, 20), Classe.Arqueiro) { }

    public override int Atacar()
    {
        int danoBase = base.Atacar();

        if (Dado.Chance(20))
        {
            int danoCritico = danoBase * 2;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"CRÍTICO! {Nome} acerta um tiro preciso, causando {danoCritico} de dano!");
            Console.ResetColor();
            return danoCritico;
        }

        return danoBase;
    }

    public override void UsarPoderEspecial(Personagem alvo)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine($"(ESPECIAL) {Nome} dispara uma RAJADA DE FLECHAS em {alvo.Nome}!");
        Console.ResetColor();
        for (int i = 0; i < 3; i++)
        {
            int dano = Dado.Rolar(8) + DanoBase / 2;
            alvo.ReceberDano(dano);
            if (!alvo.EstaVivo) break;
        }
    }
}