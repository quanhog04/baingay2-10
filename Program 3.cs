public abstract class Product
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }

    public abstract void DisplayProductInfo();
    public abstract void ApplyDiscount(decimal percentage);
}
public interface ISellable
{
    void Sell(int quantity);
    bool IsInStock();
}
public class MobilePhone : Product, ISellable
{
    public string Brand { get; set; }

    public override void DisplayProductInfo()
    {
        Console.WriteLine($"Điện thoại: {Name}, Giá: {Price}, Số lượng: {Stock}, Thương hiệu: {Brand}");
    }

    public override void ApplyDiscount(decimal percentage)
    {
        Price -= Price * percentage / 100;
    }

    public void Sell(int quantity)
    {
        if (quantity <= Stock)
        {
            Stock -= quantity;
            Console.WriteLine($"Đã bán {quantity} chiếc {Name}");
        }
        else
        {
            Console.WriteLine("Số lượng hàng không đủ");
        }
    }

    public bool IsInStock()
    {
        return Stock > 0;
    }
}
class Program
{
    static void Main(string[] args)
    {
        MobilePhone iphone14 = new MobilePhone { Name = "iPhone 14", Price = 25000, Stock = 100, Brand = "Apple" };
        Laptop macbookPro = new Laptop { Name = "MacBook Pro", Price = 30000, Stock = 50 };
        Accessory case = new Accessory { Name = "Ốp lưng điện thoại", Price = 200, Stock = 200 };

            iphone14.DisplayProductInfo();
            macbookPro.Sell(30);
            Console.WriteLine(case.IsInStock());
            iphone14.ApplyDiscount(10);
            iphone14.DisplayProductInfo();
        }
    }