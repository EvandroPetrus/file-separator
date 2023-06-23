using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchiveSeparator.Services
{
    public class ArchiveSeparatorService
    {
        public static void SeparateFiles(string inputDirectory, string outputDirectory, int filesPerFolder)
        {
            try
            {
                #region Validação de existência de diretórios
                if (!Directory.Exists(inputDirectory))
                {
                    Console.WriteLine("Source directory does not exist.");
                    return;
                }

                if (!Directory.Exists(outputDirectory))
                {
                    Directory.CreateDirectory(outputDirectory);
                }
                #endregion

                string[] files = Directory.GetFiles(inputDirectory);
                int fileCount = files.Length;
                int folderCount = (int)Math.Ceiling((double)fileCount / filesPerFolder);

                for (int i = 0; i < folderCount; i++)
                {
                    string folderPath = Path.Combine(outputDirectory, $"Pasta{i + 1}");
                    Directory.CreateDirectory(folderPath);

                    for (int j = i * filesPerFolder; j < Math.Min((i + 1) * filesPerFolder, fileCount); j++)
                    {
                        string filePath = files[j];
                        string fileName = Path.GetFileName(filePath);
                        string destinationPath = Path.Combine(folderPath, fileName);
                        File.Move(filePath, destinationPath);
                    }
                }
            }

            catch(NullReferenceException ex)
            {
                Console.WriteLine($"Há uma referência nula. {ex.Message}");
            }

            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu o seguinte erro: {ex.Message}");
            }
        }
    }
}
