public class OnlineMarket
{
    private readonly IPaymentProvider _paymentProvider;
    private IDebitCard _bankAccount;
    private readonly Dictionary<string, Product> _products;
    private readonly Dictionary<Product, int> _productsWithQuantity;
    private static OnlineMarket _instance;
    



    private OnlineMarket(IPaymentProvider paymentProvider, IDebitCard card)
    {
        if (paymentProvider == null)
            throw new ArgumentNullException(nameof(paymentProvider));

        if (card == null)
            throw new ArgumentNullException(nameof(card));

        _paymentProvider = paymentProvider;
        _bankAccount = card;
        _products = new Dictionary<string, Product>();
        _productsWithQuantity = new Dictionary<Product, int>();
    }



    public static OnlineMarket GetInstance(IPaymentProvider paymentProvider, IDebitCard card)
    {
        if (_instance == null)
            _instance = new OnlineMarket(paymentProvider, card);
        
        return _instance;
    }



    public void Add(Product product, int quantity = 1)
    {
        if (_productsWithQuantity.ContainsKey(product))
            _productsWithQuantity[product] += quantity;
        else
        {
            _products.Add(product.Name, product);
            _productsWithQuantity[product] = quantity;
        }
    }



    public void Buy(string name, int quantity, IDebitCard card)
    {
        if (_products.ContainsKey(name) && _productsWithQuantity[_products[name]] >= quantity)
        {
            var product = _products[name];
            var totalPrice = product.Price * quantity;
            try
            {
                _paymentProvider.Transfer(card, _bankAccount, totalPrice);
                _productsWithQuantity[product] -= quantity;
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        else
        {
            Console.WriteLine("There is no such product or not enough quantity in the inventory!");
        }
    }
}