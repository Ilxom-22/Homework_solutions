using User_folders.SeedData;
using User_folders.Services;

var users = SeedData.GetUsers().ToList();

var directoryService = new DirectoryService();
var fileService = new FileService();
var cleanUpService = new CleanUpService(directoryService, fileService);

directoryService.CreateUserFolders(users);

for (var i = 0; i < users.Count; ++i)
    fileService.CreateFilesForUser(directoryService.GetUserFolderPath(users[i]));

cleanUpService.CleanUp();