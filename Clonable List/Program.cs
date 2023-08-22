
using Clonable_List;

var storageList = new ClonableList<StorageFile>();

List<StorageFile> storageFiles = new List<StorageFile>()
{
    new StorageFile( "File1.txt", "Text file", 1024),
    new StorageFile("File2.jpg", "Image file", 2048),
    new StorageFile("File3.docx", "Document file", 512)
};

storageList.AddRange(storageFiles);

var newStorageList = storageList.Clone();

storageFiles[0].Name = "ChangedFile.txt";

Print(storageList);
Print(newStorageList);


void Print<T> (IList<T> list)
{
    foreach (var item in list)
        Console.WriteLine(item);

    Console.WriteLine();
}