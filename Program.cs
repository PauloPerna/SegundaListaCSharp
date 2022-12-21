using System;
using CsvHelper;
using System.Globalization;

namespace Principal
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Caminho do Desktop
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            // Nome dos arquivos
            string distanciasFileName = "matriz.txt";
            string percursoFileName = "caminho.txt";
            // Fullname dos arquivos
            string distanciasFullName = Path.Combine(desktopPath,distanciasFileName);
            string percursoFullName = Path.Combine(desktopPath,percursoFileName);

            // Chamamos o método static que realiza a leitura da matriz
            int[,] distancias = LeitorCSV.LeitorMatriz(distanciasFullName);

            // Chamamos o método static que realzia a leitura do percurso
            int[] percurso = LeitorCSV.LeitorPercurso(percursoFullName);
            
            // Percorremos o array cidades pegando as distancicas das cidades
            //  no array distancias e somando o total na variavel distanciaTotal
            int distanciaTotal = 0;
            int novaDistancia;
            for(int i = 0; i < percurso.Count()-1; i++)
            {
                // removemos 1 de cidades[i] para obter o índice da cidade no array
                //  distancias
                novaDistancia = distancias[percurso[i]-1,percurso[i+1]-1];
                distanciaTotal += novaDistancia;
            }
            
            // Mostramos a distancia total percorrida
            Console.WriteLine($"A distância percorrida no percurso é de {distanciaTotal}");
        }
    }
}