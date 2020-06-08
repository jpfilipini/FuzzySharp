using System;
using System.Text;
using BoomTown.FuzzySharp;
using Microsoft.VisualBasic.FileIO;

namespace FuzzySharp
{
    class Program
    {
        static void Main(string[] args)
        {

            //O arquivo se encontra na pasta Data, dentro do projeto
            Console.WriteLine("Digite o caminho onde está o arquivo alunos.csv: ");
            string nome = Console.ReadLine();
            string path = nome + @"\alunos.csv";
            Console.WriteLine(path);

            var encode = Encoding.GetEncoding("ISO-8859-1");

            using (TextFieldParser csvParser = new TextFieldParser(path, encode))
            {

                // Define o delimitador, o icone de comentários, e se existem campos entre aspas
                csvParser.CommentTokens = new string[] { "#" };
                csvParser.SetDelimiters(new string[] { "," });
                csvParser.HasFieldsEnclosedInQuotes = true;

                csvParser.ReadLine();

                //Lógica para salvar nas variaveis o conteudo presente no arquivo alunos.csv, respeitando o delimitador setado acima
                while (!csvParser.EndOfData)
                {
                   
                    string[] fields = csvParser.ReadFields();
                    //Lê o primeiro conteúdo até encontrar um delimitador
                    string nome_aluno = fields[0];

                    //Lê o conteúdo após o delimitador e chama o método para remover a acentuação
                    string nome_ficticio = fields[1].removerAcentos();

                    //Percentual de match individual de cada linha do dataset
                    int match = Fuzzy.WeightedRatio(nome_aluno, nome_ficticio);
                    Console.WriteLine("Nome do Aluno: " + nome_aluno + " Nome Ficticio: " + nome_ficticio + " Percentual de match: " + match + "%");
                }
            }
        }
    }
}
