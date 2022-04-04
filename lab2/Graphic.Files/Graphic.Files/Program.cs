using MetadataExtractor;
using System.CommandLine.DragonFruit;
using System.Diagnostics;
using System.Drawing;

namespace Graphic.Files
{
    public static class Program
    {
        /// <param name="file">File to process</param>
        /// <param name="directory">Directory to process all files</param>
        public static void Main(
            string file = null,
            string directory = null)
        {
            if (file != null)
            {
                OpenFile(file);
            }        
            else if (directory != null)
            {
                OpenDirectory(directory);
            }
            else
            {
                Console.WriteLine("Please, provide correct file or " +
                    "directory via command line arguments --file or --directory");
            }
        }

        private static void OpenFile(string path)
        {
            var fileInfo = new FileInfo(path);

            try
            {
                var image = new Bitmap(path);
                
                Console.WriteLine($"\r\n" +
                    $"File name: {fileInfo.Name}\r\n" +
                    $"File size: {fileInfo.Length} bytes\r\n" +
                    $"Image size: {image.Size}\r\n" +
                    $"Horizontal resolution: {image.HorizontalResolution} pixels per inch\r\n" +
                    $"Color depth: {image.PixelFormat}"); 
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\r\nAn error occured while processing " +
                    $"file as standard bitmap: {ex.Message}\r\n" +
                    $"File path: \"{path}\"");
            }

            try
            {
                ExtractMetadata(path);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\r\nAn error occured while " +
                    $"retrieving file metadata: {ex.Message}\r\n" +
                    $"File path: \"{path}\"");
            }

            Console.WriteLine("----------------------------------------------------------------");
        }

        private static void ExtractMetadata(string path)
        {
            var directories = ImageMetadataReader.ReadMetadata(path);

            Console.WriteLine("Image metadata:");

            foreach (var directory in directories)
            {
                foreach (var tag in directory.Tags)
                {
                    Console.WriteLine($"\t{directory.Name} - {tag.Name} = {tag.Description}");
                }
            }
        }

        private static void OpenDirectory(string path)
        {
            var directory = new DirectoryInfo(path);
            var stopwatch = new Stopwatch();

            var totalFiles = 0L;

            Console.WriteLine($"\r\nAnalyze directory: {directory.Name}");

            stopwatch.Start();

            foreach (var file in directory.EnumerateFiles())
            {
                OpenFile(file.FullName);
                totalFiles++;
            }

            stopwatch.Stop();

            Console.WriteLine(
                $"Total analyzed files: {totalFiles}\r\n" +
                $"Elapsed time: {stopwatch.ElapsedMilliseconds} ms");
        }
    }
}