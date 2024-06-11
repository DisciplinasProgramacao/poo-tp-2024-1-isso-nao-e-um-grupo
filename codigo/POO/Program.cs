using System;
using POO.Classes;
using POO.Classes.NovaPasta;

namespace ProgramRestaurante;

public class Program
{
    public const string NomeRestaurante = "Isso Não é Um Restaurante";
    internal static Restaurante restaurante { get; set; } = new Restaurante(NomeRestaurante);

    public static void Main(string[] args)
    {

    }

    public static void Menu() 
    {
        Console.WriteLine($"Seja bem-vindo ao Restaurante - {NomeRestaurante}!");
        while (true)
        {

            
        }
    }
}