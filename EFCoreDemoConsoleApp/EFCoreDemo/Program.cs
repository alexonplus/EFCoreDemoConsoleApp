using EFCoreDemo.Data;
using EFCoreDemo.Models;

namespace EFCoreDemo;

internal class Program
{
    static void Main(string[] args)
    {
        using var context = new AppDbContext();
        //context.Database.EnsureCreated();

        while (true)
        {
            Console.WriteLine("\n=== Menu ===");
            Console.WriteLine("Product:  1.Create  2.Read All  3.Update  4.Delete");
            Console.WriteLine("Employee: 5.Create  6.Read All  7.Update  8.Delete");
            Console.WriteLine("0. Exit");
            Console.Write("Choice: ");

            var choice = Console.ReadLine();
            switch (choice)
            {
                case "1": CreateProduct(context); break;
                case "2": ReadAllProducts(context); break;
                case "3": UpdateProduct(context); break;
                case "4": DeleteProduct(context); break;
                case "5": CreateEmployee(context); break;
                case "6": ReadAllEmployees(context); break;
                case "7": UpdateEmployee(context); break;
                case "8": DeleteEmployee(context); break;
                case "0": return;
                default: Console.WriteLine("Invalid choice."); break;
            }
        }
    }

    static void CreateProduct(AppDbContext context)
    {
        Console.Write("Name: ");
        var name = Console.ReadLine() ?? "";
        Console.Write("Price: ");
        if (!decimal.TryParse(Console.ReadLine(), out var price))
        {
            Console.WriteLine("Invalid price.");
            return;
        }
        Console.Write("Stock: ");
        if (!int.TryParse(Console.ReadLine(), out var stock))
        {
            Console.WriteLine("Invalid stock.");
            return;
        }

        var product = new Product { Name = name, Price = price, Stock = stock };
        context.Products.Add(product);
        context.SaveChanges();
        Console.WriteLine($"Created product with Id: {product.Id}");
    }

    static void ReadAllProducts(AppDbContext context)
    {
        var products = context.Products.ToList();
        if (products.Count == 0)
        {
            Console.WriteLine("No products.");
            return;
        }
        foreach (var p in products)
            Console.WriteLine($"Id: {p.Id} | {p.Name} | ${p.Price} | Stock: {p.Stock}");
    }

    static void UpdateProduct(AppDbContext context)
    {
        Console.Write("Product Id to update: ");
        if (!int.TryParse(Console.ReadLine(), out var id))
        {
            Console.WriteLine("Invalid id.");
            return;
        }

        var product = context.Products.Find(id);
        if (product == null)
        {
            Console.WriteLine("Product not found.");
            return;
        }

        Console.Write($"Name [{product.Name}]: ");
        var name = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(name)) product.Name = name;

        Console.Write($"Price [{product.Price}]: ");
        var priceInput = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(priceInput) && decimal.TryParse(priceInput, out var price))
            product.Price = price;

        Console.Write($"Stock [{product.Stock}]: ");
        var stockInput = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(stockInput) && int.TryParse(stockInput, out var stock))
            product.Stock = stock;

        context.SaveChanges();
        Console.WriteLine("Updated.");
    }

    static void DeleteProduct(AppDbContext context)
    {
        Console.Write("Product Id to delete: ");
        if (!int.TryParse(Console.ReadLine(), out var id))
        {
            Console.WriteLine("Invalid id.");
            return;
        }

        var product = context.Products.Find(id);
        if (product == null)
        {
            Console.WriteLine("Product not found.");
            return;
        }

        context.Products.Remove(product);
        context.SaveChanges();
        Console.WriteLine("Deleted.");
    }

    static void CreateEmployee(AppDbContext context)
    {
        Console.Write("Name: ");
        var name = Console.ReadLine() ?? "";
        Console.Write("Email: ");
        var email = Console.ReadLine() ?? "";
        Console.Write("Department: ");
        var department = Console.ReadLine() ?? "";

        var employee = new Employee { Name = name, Emailsss = email, Department = department };
        context.Employees.Add(employee);
        context.SaveChanges();
        Console.WriteLine($"Created employee with Id: {employee.Id}");
    }

    static void ReadAllEmployees(AppDbContext context)
    {
        var employees = context.Employees.ToList();
        if (employees.Count == 0)
        {
            Console.WriteLine("No employees.");
            return;
        }
        foreach (var e in employees)
            Console.WriteLine($"Id: {e.Id} | {e.Name} | {e.Emailsss} | {e.Department}");
    }

    static void UpdateEmployee(AppDbContext context)
    {
        Console.Write("Employee Id to update: ");
        if (!int.TryParse(Console.ReadLine(), out var id))
        {
            Console.WriteLine("Invalid id.");
            return;
        }

        var employee = context.Employees.Find(id);
        if (employee == null)
        {
            Console.WriteLine("Employee not found.");
            return;
        }

        Console.Write($"Name [{employee.Name}]: ");
        var name = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(name)) employee.Name = name;

        Console.Write($"Email [{employee.Emailsss}]: ");
        var email = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(email)) employee.Emailsss = email;

        Console.Write($"Department [{employee.Department}]: ");
        var department = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(department)) employee.Department = department;

        context.SaveChanges();
        Console.WriteLine("Updated.");
    }

    static void DeleteEmployee(AppDbContext context)
    {
        Console.Write("Employee Id to delete: ");
        if (!int.TryParse(Console.ReadLine(), out var id))
        {
            Console.WriteLine("Invalid id.");
            return;
        }

        var employee = context.Employees.Find(id);
        if (employee == null)
        {
            Console.WriteLine("Employee not found.");
            return;
        }

        context.Employees.Remove(employee);
        context.SaveChanges();
        Console.WriteLine("Deleted.");
    }
}
