using System;

namespace Problema00
{
    class Program
    {
        public static void Main(string[] args)
        {
            var datos = Console.ReadLine();
            var numeros = datos.Split(' ');

            var a = int.Parse(numeros[0]);
            var b = int.Parse(numeros[1]);

            var c = a + b;
            Console.WriteLine(c);
        }
    }
}