namespace Product.Models;
internal interface IProduct
{
    int Id { get; }
    string Name { get; set; }
    string Description { get; set; }
    bool IsOrdered { get; set; }
    double Price { get; set; }
    IProduct Copy();

}
