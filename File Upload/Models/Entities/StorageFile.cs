#pragma warning disable CS8618

using FileBaseContext.Abstractions.Models.Entity;

namespace File_Upload.Models.Entities;

public class StorageFile : IFileSetEntity<Guid>
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public string Extension { get; set; }

    public long Size { get; set; }

    public Guid UserId { get; set; }
}