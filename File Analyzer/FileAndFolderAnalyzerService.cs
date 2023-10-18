namespace File_Analyzer;

public class FileAndFolderAnalyzerService
{
    public int GetFoldersCount(string path)
    {
        var folders = Directory.GetDirectories(path);
        var count = folders.Count();

        foreach (var folderPath in folders)
            count += GetFoldersCount(folderPath);

        return count;
    }

    public int GetFilesCount(string path)
    {
        var directories = Directory.GetDirectories(path);
        var count = Directory.GetFiles(path).Count();

        foreach (var folderPath in directories)
            count += GetFilesCount(folderPath);

        return count;
    }

    public long GetFilesSizeSum(string path)
        => GetFilesInfo(path).Sum(file => file.Length) / 1024;
    

    public string? GetTheBiggestFilePath(string path)
        => GetFilesInfo(path).MaxBy(file => file.Length)?.FullName;
    

    private IList<FileInfo> GetFilesInfo(string path)
    {
        var directories = Directory.GetDirectories(path);
        var directoryInfo = new DirectoryInfo(path);
        var files = directoryInfo.EnumerateFiles().ToList();

        foreach (var folderPath in directories)
            files.AddRange(GetFilesInfo(folderPath));

        return files;
    }
}