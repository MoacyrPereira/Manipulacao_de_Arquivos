using System;
using System.IO;
using System.Globalization;
using ManipulacaoArquivos.Entidades;

namespace ManipulacaoArquivos
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Insira o caminho completo do arquivo: ");
            string sourceFilePath = Console.ReadLine();

            try
            {
                string[] lines = File.ReadAllLines(sourceFilePath); //Le tudo no diretorio

                //Criar pasta e arquivo
                string sourceFolderPath = Path.GetDirectoryName(sourceFilePath);
                string targetFolderPath = sourceFolderPath + @"\out";
                string targetFilePath = targetFolderPath + @"\summary.csv";

                Directory.CreateDirectory(targetFolderPath);

                using (StreamWriter sw = File.AppendText(targetFilePath))
                {
                    foreach (string line in lines)
                    {
                        string[] fields = line.Split(',');
                        string name = fields[0];
                        double price = double.Parse(fields[1], CultureInfo.InvariantCulture);
                        int quantity = int.Parse(fields[2]);


                        Produto prod = new Produto(name, price, quantity);

                        sw.WriteLine(prod.Name + "," + prod.Total().ToString("F2", CultureInfo.InvariantCulture));

                    }
                }

            }
            catch (IOException e)
            {
                Console.WriteLine("Erro!!" + e.Message);

            }

        }
    }
}
