using System;

namespace Principal
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Distancias conforme exercício do Class
            int[,] distancias = new int[5,5]
            {
                {00,15,30,05,12},
                {15,00,10,17,28},
                {30,10,00,03,11},
                {05,17,03,00,80},
                {12,28,11,80,00}
            };

            Console.WriteLine("Entre com o percurso no formato \"1, 2, 4, 2\"");
            // armazenamos as cidades do percurso na variável abaixo
            string[] input = Console.ReadLine().Split(",");
            // transformamos em inteiro, assim podemos acessar as distâncias diretamente no
            //  array distancias
            int[] cidades = Array.ConvertAll(input, c => int.Parse(c));
            
            // Percorremos o array cidades pegando as distancicas das cidades
            //  no array distancias e somando o total na variavel distanciaTotal
            int distanciaTotal = 0;
            int novaDistancia;
            for(int i = 0; i < cidades.Count()-1; i++)
            {
                // removemos 1 de cidades[i] para obter o índice da cidade no array
                //  distancias
                novaDistancia = distancias[cidades[i]-1,cidades[i+1]-1];
                distanciaTotal += novaDistancia;
            }
            
            // Mostramos a distancia total percorrida
            Console.WriteLine($"A distância percorrida no no percurso é de {distanciaTotal}");
        }
    }
}