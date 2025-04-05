using System.Linq;

namespace Lab2;


public class Data
{
    public String[] A = {
        "Fallout 3", "Daxter 2", "System Shok 2", "Morrowind", "Pes 2013"
    };

    public int[] B = { 2, -7, -10, 6, 7, 9, 3 };

    public String[] C = {
        "Light Green", "Red", "Green", "Yellow", "Puprle", "Dark Green",
        "Light Red", "Dark Red", "Dark Yellow", "Light Yellow"
    };


    public List<Car> cars = new List<Car> 
    {
        new Car(250f, "Black", "BMW", 5),
        new Car(220f, "Red", "Toyota", 5),
        new Car(240f, "White", "BMW", 4),
        new Car(260f, "Blue", "BMW", 5),
        new Car(210f, "Silver", "Ford", 4),
    };

    public List<Products> products = new List<Products> 
    {
        new Products("Laptop", 15, "High performance gaming laptop"),
        new Products("Smartphone", 0, "Latest model with AI camera"),
        new Products("Keyboard", 30, "Mechanical keyboard with RGB"),
        new Products("Monitor", 0, "27-inch 4K UHD display"),
        new Products("Mouse", 50, "Ergonomic wireless mouse"),
        new Products("Webcam", 0, "HD webcam with autofocus"),
        new Products("USB Hub", 25, "4-port USB 3.0 hub"),
        new Products("External HDD", 10, "1TB portable hard drive")
    };


    public List<string> myCars = new List<String> { "Yugo", "Aztec", "BMW" };
    public List<string> yourCars = new List<String> { "BMW", "Saab", "Aztec" };


    public class Car
    {
        public float MaxSpeed { get; set; }
        public string Color { get; set; }
        public string Brand { get; set; }
        public int NumberOfSeats { get; set; }

        public Car() 
        {
            MaxSpeed = 0;
            Color = string.Empty;
            Brand = string.Empty;
            NumberOfSeats = 0;
        }
        public Car(float maxSpeed, string color, string brand, int numberOfSeats)
        {
            MaxSpeed = maxSpeed;
            Color = color;
            Brand = brand;
            NumberOfSeats = numberOfSeats;
        }
    }

    public class Products
    {
        public string Name { get; set; }
        public int CountInStorage { get; set; }
        public string Description { get; set; }

        public Products() 
        {
            Name = string.Empty;
            CountInStorage = 0;
            Description = string.Empty;
        }

        public Products(string name, int countInStorage, string description)
        {
            Name = name;
            CountInStorage = countInStorage;
            Description = description;
        }
    }
}


public static class Program
{
    static void Main(string[] args)
    {
        Data TaskData = new Data();


        // Find elements that includes Spaces
        var A_Spaces = from name in TaskData.A
                       where name.Any(Char.IsWhiteSpace)
                       select name;

        Console.WriteLine("Elements containing spaces in array 'A':");
        foreach (var A in A_Spaces)
        {
            Console.WriteLine("".PadRight(3) + A);
        }


        // Find negative numbers
        var B = from num in TaskData.B
                where num < 0
                select num;

        string res = string.Empty;
        foreach (var element in B)
        {
            res += element.ToString() + " ";
        }
        Console.WriteLine($"\n\nNegative elements in array 'B': {res}");


        // Find Green color
        var C = from color in TaskData.C
                where color.Contains("Green")
                select color;

        res = string.Empty;
        foreach (var element in C)
        {
            res += element + ", ";
        }
        Console.WriteLine($"\n\nAll shades of green in array 'C': {res}");


        // Select only BMW from the list
        var cars = from car in TaskData.cars
                   where car.Brand == "BMW"
                   select car;

        Console.WriteLine("\n\nOnly BMWs are selected from an instance of the 'Car' class:");
        foreach (var car in cars)
        {
            Console.WriteLine("".PadRight(3) + $"Brand: {car.Brand }, Top speed: {car.MaxSpeed} km/h, Number of passengers: {car.NumberOfSeats}");
        }


        // Select only products that have run out in stock
        var products = from product in TaskData.products
                       where product.CountInStorage == 0
                       select product;

        Console.WriteLine("\n\nOnly out of stock items are selected from an instance of the 'Product' class:");
        foreach (var product in products)
        {
            Console.WriteLine("".PadRight(3) + $"Item: {product.Name}, Description: {product.Description}, In Storage: {product.CountInStorage}");
        }


        // Show list only with similar items in 'myCars' and 'yourCars'
        var similarCars = from i in TaskData.myCars
                          join j in TaskData.yourCars
                          on i equals j
                          select i;

        res = string.Empty;
        foreach (var car in similarCars)
        {
            res += car + ", ";
        }
        Console.WriteLine($"\n\nFrom the arrays 'myCars' and 'yourCars' only similar car brands are selected: {res}\n\n");
    }
}
