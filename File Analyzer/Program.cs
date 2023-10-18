
using File_Analyzer;

var path = @"D:\C# Homework\Homework_solutions\File Analyzer\bin\Debug\net7.0";
var fileService = new FileAndFolderAnalyzerService();

Console.WriteLine($"Directories count: {fileService.GetFoldersCount(path)}");
Console.WriteLine($"Files count: {fileService.GetFilesCount(path)}");
Console.WriteLine($"Files Size: {fileService.GetFilesSizeSum(path)} KB");
Console.WriteLine($"Biggest File's full path: {fileService.GetTheBiggestFilePath(path)}");