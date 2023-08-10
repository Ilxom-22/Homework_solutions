var paymentService = UzumPaymentProvider.GetInstance(new MilliyHumo("9700871335299087", "Agrobank"), 2);
var card1 = new MilliyHumo("6400138743890906", "Aloqabank");

var market = OnlineMarket.GetInstance(paymentService, card1);

var product1 = new Product("CyberGuard Pro VPN Router", 199.90m);
var product2 = new Product("DataSaver Plus External Hard Drive - 2TB", 129.95m);
var product3 = new Product("PixelView UltraWide Curved Monitor - 34", 499m);
var product4 = new Product("CodeMaster Pro Mechanical Keyboard", 89.99m);
var product5 = new Product("NetBlaze Secure Antivirus Software - 1 Year Subscription", 49.99m);

market.Add(product1, 5);
market.Add(product2);
market.Add(product3, 10);
market.Add(product4, 7);
market.Add(product5);

var myCard = new KaptalUzCard("7899239147283324", "UniversalBank");
myCard.Balance = 1000;

market.Buy("PixelView UltraWide Curved Monitor - 34", 1, myCard);
market.Buy("CodeMaster Pro Mechanical Keyboard", 2, myCard);
Console.WriteLine($"My Balance: {myCard.Balance.ToString("c")}");
Console.WriteLine($"Market balance: {card1.Balance.ToString("c")}");

