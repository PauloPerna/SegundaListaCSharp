using CsvHelper;
using System.Globalization;

namespace Principal
{
    public class LeitorCSV
    {
        public static int[,] LeitorMatriz(string FullPathMatriz)
        {
            // Configuracao do CsvHelper: Não temos um Header
            var config = new CsvHelper.Configuration.CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = false,
            };

            // StreamReader, onde passamos o caminho do arquivo que será lido
            using var reader = new StreamReader(FullPathMatriz);
            // Criação do CsvParser
            using var csv = new CsvParser(reader, config);

            // Se não houver registros... retornamos um array vazio
            if(!csv.Read())
                return new int[0,0] {};

            // Código semelhante ao feito em aula
            // Temos como premissa de que a matriz será quadrada
            var numColunas = csv.Record.Length;
            var distancias = new int[numColunas, numColunas];
            // Preenchemos o array distancias com os valores
            for (int i = 0; i < numColunas; i++)
            {
                var linha = csv.Record;
                for (int j = 0; j < numColunas; j++)
                {
                    distancias[i, j] = int.Parse(linha[j]);
                }
                csv.Read();
            }

            return distancias;
        }
        public static int[] LeitorPercurso(string FullPathPercurso)
        {
            // Configuracao do CsvHelper: Não temos um Header
            var config = new CsvHelper.Configuration.CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = false,
            };

            // StreamReader, onde passamos o caminho do arquivo que será lido
            using var reader = new StreamReader(FullPathPercurso);
            // Criação do CsvParser
            using var csv = new CsvParser(reader, config);

            // Se não houver registros... retornamos um array vazio
            if(!csv.Read())
                return new int[0] {};

            // Essa leitura será mais simples, pois faremos
            // apenas a primeira linha
            var numColunas = csv.Record.Length;
            var percurso = new int[numColunas];
            // Preenchemos o array percurso com os valores
            var linha = csv.Record;
            percurso = Array.ConvertAll(linha, c => int.Parse(c));

            return percurso;
        }
    }
}