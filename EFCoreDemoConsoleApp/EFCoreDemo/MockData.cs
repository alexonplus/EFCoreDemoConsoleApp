using EFCoreDemo.Models;

namespace EFCoreDemo;

public static class MockData
{
    public static readonly List<InventoryItem> Inventory =
    [
        new() { Id = 1, Name = "USB-C Cable", Category = "Electronics", Quantity = 120, PricePerUnit = 99.00m },
        new() { Id = 2, Name = "Wireless Mouse", Category = "Electronics", Quantity = 45, PricePerUnit = 249.00m },
        new() { Id = 3, Name = "Mechanical Keyboard", Category = "Electronics", Quantity = 30, PricePerUnit = 1299.00m },
        new() { Id = 4, Name = "HDMI Cable", Category = "Electronics", Quantity = 200, PricePerUnit = 79.00m },
        new() { Id = 5, Name = "Laptop Stand", Category = "Electronics", Quantity = 25, PricePerUnit = 499.00m },

        new() { Id = 6, Name = "Notebook A5", Category = "Office", Quantity = 300, PricePerUnit = 29.00m },
        new() { Id = 7, Name = "Ballpoint Pen", Category = "Office", Quantity = 500, PricePerUnit = 9.00m },
        new() { Id = 8, Name = "Whiteboard Marker", Category = "Office", Quantity = 120, PricePerUnit = 39.00m },
        new() { Id = 9, Name = "Sticky Notes", Category = "Office", Quantity = 250, PricePerUnit = 19.00m },
        new() { Id = 10, Name = "Desk Organizer", Category = "Office", Quantity = 40, PricePerUnit = 199.00m },

        new() { Id = 11, Name = "Coffee Beans 1kg", Category = "Food", Quantity = 60, PricePerUnit = 249.00m },
        new() { Id = 12, Name = "Green Tea Box", Category = "Food", Quantity = 90, PricePerUnit = 59.00m },
        new() { Id = 13, Name = "Chocolate Bar", Category = "Food", Quantity = 400, PricePerUnit = 25.00m },
        new() { Id = 14, Name = "Protein Bar", Category = "Food", Quantity = 150, PricePerUnit = 35.00m },
        new() { Id = 15, Name = "Mineral Water 0.5L", Category = "Food", Quantity = 600, PricePerUnit = 15.00m },

        new() { Id = 16, Name = "T-Shirt Medium", Category = "Clothing", Quantity = 80, PricePerUnit = 199.00m },
        new() { Id = 17, Name = "Hoodie Large", Category = "Clothing", Quantity = 35, PricePerUnit = 599.00m },
        new() { Id = 18, Name = "Baseball Cap", Category = "Clothing", Quantity = 70, PricePerUnit = 149.00m },
        new() { Id = 19, Name = "Socks (5-pack)", Category = "Clothing", Quantity = 100, PricePerUnit = 129.00m },
        new() { Id = 20, Name = "Winter Jacket", Category = "Clothing", Quantity = 15, PricePerUnit = 1799.00m },

        new() { Id = 21, Name = "Hammer", Category = "Tools", Quantity = 40, PricePerUnit = 199.00m },
        new() { Id = 22, Name = "Screwdriver Set", Category = "Tools", Quantity = 25, PricePerUnit = 349.00m },
        new() { Id = 23, Name = "Measuring Tape", Category = "Tools", Quantity = 60, PricePerUnit = 89.00m },
        new() { Id = 24, Name = "Cordless Drill", Category = "Tools", Quantity = 12, PricePerUnit = 1499.00m },
        new() { Id = 25, Name = "Utility Knife", Category = "Tools", Quantity = 90, PricePerUnit = 59.00m },

        new() { Id = 26, Name = "LED Light Bulb", Category = "Home", Quantity = 200, PricePerUnit = 49.00m },
        new() { Id = 27, Name = "Cushion Cover", Category = "Home", Quantity = 55, PricePerUnit = 129.00m },
        new() { Id = 28, Name = "Curtains", Category = "Home", Quantity = 20, PricePerUnit = 699.00m },
        new() { Id = 29, Name = "Wall Clock", Category = "Home", Quantity = 30, PricePerUnit = 299.00m },
        new() { Id = 30, Name = "Floor Lamp", Category = "Home", Quantity = 10, PricePerUnit = 1199.00m },

        new() { Id = 31, Name = "Football", Category = "Sports", Quantity = 45, PricePerUnit = 249.00m },
        new() { Id = 32, Name = "Yoga Mat", Category = "Sports", Quantity = 70, PricePerUnit = 299.00m },
        new() { Id = 33, Name = "Dumbbell 10kg", Category = "Sports", Quantity = 25, PricePerUnit = 499.00m },
        new() { Id = 34, Name = "Resistance Bands", Category = "Sports", Quantity = 90, PricePerUnit = 149.00m },
        new() { Id = 35, Name = "Water Bottle", Category = "Sports", Quantity = 110, PricePerUnit = 99.00m }
    ];
}
