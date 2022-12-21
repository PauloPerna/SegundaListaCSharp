using System;

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

            // Leitura da matriz de distancias em um array de linhas
            string[] matriz = System.IO.File.ReadAllLines(distanciasFullName);
            // Transformamos a matriz de distancias em um jagged array, splitando as linhas
            string[][] jaggedMatriz = Array.ConvertAll(matriz, c => c.Split(","));
            // Array onde armazenaremos as distancias lidas
            // Usamos como premissa de que a matriz sempre será uma matriz quadrada
            int[,] distancias = new int[matriz.Count(),matriz.Count()];

            // Preenchemos o array distancias
            for(int i = 0; i<matriz.Count(); i++){
                for(int j = 0; j<matriz.Count(); j++){
                    int.TryParse(jaggedMatriz[i][j],out int newItem);
                    distancias[i,j] = newItem;
                }
            }

            // Leitura do percurso em um array
            string[] percurso = System.IO.File.ReadAllLines(percursoFullName);
            // Tomamos como premissa de que o percurso está escrito em apenas uma linha!
            percurso = percurso[0].Split(",");
            // Armazenamos o percurso como um array de inteiros representando as cidades
            int[] cidades = Array.ConvertAll(percurso,c => int.Parse(c));
            
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
            Console.WriteLine($"A distância percorrida no percurso é de {distanciaTotal}");
        }
    }
}