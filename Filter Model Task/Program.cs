using Filter_Model_Task.Models;
using Filter_Model_Task.Services;


var userService = new UserService();
var credentialService = new UserCredentialsService();
var registerService = new RegistrationService(userService, credentialService);

registerService.Register("David", "Smith", "john.smith@example.com", "Password123");
registerService.Register("Emily", "Johnson", "emily.johnson@example.com", "SecurePass456");
registerService.Register("Michael", "Davis", "michael.davis@example.com", "P@ssw0rd789");
registerService.Register("Sarah", "Williams", "sarah.williams@example.com", "SecretCode987");
registerService.Register("David", "Brown", "david.brown@example.com", "HiddenKey2023");
registerService.Register("Jessica", "Martinez", "jessica.martinez@example.com", "SafeWord567");
registerService.Register("Christopher", "Taylor", "christopher.taylor@example.com", "Protected321");
registerService.Register("Olivia", "Anderson", "olivia.anderson@example.com", "PrivateAccess876");
registerService.Register("Matthew", "Wilson", "matthew.wilson@example.com", "ClassifiedPass1");
registerService.Register("Sophia", "Jackson", "sophia.jackson@example.com", "LockedIn5678");


var filterModel = new UserFilterModel("David", null, 10, 1);
var filteredUsers = userService.Filter(filterModel);
filteredUsers.ForEach(Console.WriteLine);

Console.Write("Input search keyword: ");
var result = userService.Search(Console.ReadLine(), 10, 1);
result.ForEach(Console.WriteLine);