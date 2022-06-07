
using System.IO.Compression;

var path = @"Desktop.zip";

using (var zip = ZipFile.OpenRead(path))
{

    foreach (var entry in zip.Entries)
    {
        Console.WriteLine($"文件名是 {entry.FullName}");
        using (var stream = entry.Open())
        {
            using (var reader = new StreamReader(stream))
            {
                var str = reader.ReadToEnd();
                Console.WriteLine($"内容是 {str}");
            }
        }

    }
}

























