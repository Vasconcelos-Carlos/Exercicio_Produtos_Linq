using System;
using System.IO;
using Exercicio_Resolvido_Produtos.Entidades;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
namespace Exercicio_Resolvido_Produtos
{
    class Program
    {
        static void Main(string[] args)
        {
            //Receber caminho onde esta localizado o arquivo
            Console.Write("Informe o Caminho do arquivo que será lido: ");
            string Caminho = Console.ReadLine();

            //Criando uma lista do tipo PRODUTO, para armazenar os dalos coletados do arquivo
            List<Produto> Lista = new List<Produto>();

            //
            using(StreamReader sr = File.OpenText(Caminho))
            {
                while(!sr.EndOfStream) //Enquato o meu leitor nao chegar ao fim do arquivo
                {
                    string[] campos = sr.ReadLine().Split(','); //criando um vetor para armazenar os dados separados pelo meu SPLIT(usando a virgula como separador).
                    string nome = campos[0]; //A variavel NOME ira receber o dado na posiçao [0] do vetor, dado recortado pelo Split.
                    double preco = double.Parse(campos[1], CultureInfo.InvariantCulture); // Variavel preco ira receber os dados na posiçao [1] do vetor.

                    Lista.Add(new Produto(nome, preco)); //Inserindo os dados do tipo PRODUTO na lista
                }
            }

            //CRIANDO UMA LISTA DENTRO DA LISTA PRODUTP, CONTENDO APENAS OS VALORES
            var avg = Lista //A fonte onde os daddos estao armazenados
                .Select(p => p.Preco) //Irá selecionar apenas os NOMES dos preço 
                .DefaultIfEmpty(0.0).Average(); //A funçao '.Avarage' pertence ao LINQ e calcula a media

            Console.WriteLine("Preço medio: " + avg.ToString("F2",CultureInfo.InvariantCulture));

            var nomes = Lista //A fonte onde os daddos estao armazenados
                .Where(p => p.Preco < avg) //Vai selecionar apenas os produtos onde(Where) o Preco for menor que a medida. 
                .OrderByDescending(p => p.Nome) //Irá selecionar os produtos em ordem decrescente (OrderByDescending)
                .Select(p => p.Nome);// Irá selecionar apenas os NOMES dos produtos 

            foreach(string nome in nomes)
            {
                Console.WriteLine(nome);
            }


        

        }
    }
}
