using ArchiveSeparator.Services;
using System;
using System.IO;

class FileSeparator
{
    public static void Main()
    {
        //Localização dos arquivos a serem movidos
        string inputDirectory = "";

        //Localização à qual os arquivos serão movidos
        string outputDirectory = "";

        //Número de arquivos a serem movidos por pasta
        int filesPerFolder = 600000;

        ArchiveSeparatorService.SeparateFiles(inputDirectory, outputDirectory, filesPerFolder);

        Console.WriteLine("Separação de arquivos concluída com sucesso.");
        Console.ReadKey();
    }
  
}
