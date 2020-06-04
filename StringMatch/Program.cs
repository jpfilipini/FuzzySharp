using System;
using FuzzySharp;
using Microsoft.VisualBasic.FileIO;

namespace StringMatch
{
    class Program
    {
        static void Main(string[] args)
        {

            //O arquivo se encontra na pasta Data, dentro do projeto

            Console.WriteLine("Digite o caminho onde está o arquivo hotel.csv: ");
            string nome = Console.ReadLine();
            string path = nome + @"\hotel.csv";
            Console.WriteLine(path);            


            using (TextFieldParser csvParser = new TextFieldParser(path))
            {

                // Define o delimitador, o icone de comentários, e se existem campos entre aspas
                csvParser.CommentTokens = new string[] { "#" };
                csvParser.SetDelimiters(new string[] { "," });
                csvParser.HasFieldsEnclosedInQuotes = true;

                csvParser.ReadLine();

                //Lógica para salvar nas variaveis o conteudo presente no arquivo hotel.csv, respeitando o delimitador setado acima
                while (!csvParser.EndOfData)
                {

                    string[] fields = csvParser.ReadFields();
                    string hotel1 = fields[0];
                    string hotel2 = fields[1];


                    //Percentual de match individual de cada linha do dataset
                    int match = Fuzz.TokenSetRatio(hotel1, hotel2);
                    Console.WriteLine("Percentual de match: " + match + "%");
                }
            }

        }
    }
}
