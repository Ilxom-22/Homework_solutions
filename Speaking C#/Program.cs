using Speaking_C_.Services;

var obj = new UsersManagementService();
var users = obj.GetByCreatedDate(false);

foreach (var user in users)
    Console.WriteLine(user);