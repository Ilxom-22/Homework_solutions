using HT_1;

var service = new UserService(new User("user@example.com", "passw*ord123"),
                                              new User("admin@example.com", "adminPa&ss456", true),
                                              new User("anotheruser@mail.com", "secu!rePass789"));

service.Add("testuser@testmail.com", "testPas#s123");
service.Add("superadmin@adminsite.com", "SuperSecureP@ssw0rd!", true);

service.GetUsers().ForEach(Console.WriteLine);