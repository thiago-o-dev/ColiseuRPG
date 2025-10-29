using MedievalRPG.Entities;

namespace MedievalRPG.Entities;

public class Hobbit : Personagem
{
    public Hobbit(string nome) : base(nome, Dado.Range(30, 500), Dado.Range(2, 15), Enums.Classe.Hobbit) { }

    public override void UsarPoderEspecial(Personagem alvo)
    {
        if (Dado.Chance(10))
        {
            Console.ForegroundColor = ConsoleColor.Green;
            int cura = (VidaMaxima / 100) * Dado.Range(5, 15);
            Console.WriteLine($"(ESPECIAL) {Nome} tira um SEGUNDO DESEJUM e se recupera um pouco! Que sorte!");
            Console.ResetColor();
            Curar(cura);
        }
        else if (Dado.Chance(30))
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"(ESPECIAL) {Nome} usa PÉS LEVES e se move tão rápido, acertando o inimigo por surpresa!");
            Console.ResetColor();

            int danoFurtivo = Dado.Range(5, 10);
            alvo.ReceberDano(danoFurtivo);
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            int dano = DanoBase + Dado.Range(1, 5);
            Console.WriteLine($"(ESPECIAL) {Nome} joga uma PEDRADA SORRATEIRA, usando sua sorte para acertar um ponto fraco!");
            Console.ResetColor();
            alvo.ReceberDano(dano);
        }
    }
}