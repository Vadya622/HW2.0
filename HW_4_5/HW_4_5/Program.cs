using System;
using System.Collections.Generic;
using System.Linq;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string Description { get; set; }
}

public class ProductRepository
{
    private List<Product> products;

    public ProductRepository()
    {
        products = new List<Product>();
    }

    // Метод создания записи в таблице Product
    public Product CreateProduct(string name, decimal price, string description)
    {
        var product = new Product
        {
            Id = products.Count + 1,
            Name = name,
            Price = price,
            Description = description
        };

        products.Add(product);
        return product;
    }

    // Метод чтения записи из таблицы Product по идентификатору
    public Product ReadProduct(int productId)
    {
        return products.FirstOrDefault(p => p.Id == productId);
    }

    // Метод обновления записи в таблице Product
    public Product UpdateProduct(int productId, string name = null, decimal? price = null, string description = null)
    {
        var product = products.FirstOrDefault(p => p.Id == productId);
        if (product != null)
        {
            if (name != null)
            {
                product.Name = name;
            }
            if (price != null)
            {
                product.Price = price.Value;
            }
            if (description != null)
            {
                product.Description = description;
            }
        }
        return product;
    }

    // Метод удаления записи из таблицы Product по идентификатору
    public bool DeleteProduct(int productId)
    {
        var product = products.FirstOrDefault(p => p.Id == productId);
        if (product != null)
        {
            products.Remove(product);
            return true;
        }
        return false;
    }

    // Подкачка с запросом фильтрации и упорядочивания для таблицы Product
    public List<Product> FetchProducts(int pageNumber, decimal? priceFilter = null, string nameFilter = null, int pageSize = 20)
    {
        var filteredProducts = products;

        if (priceFilter != null)
        {
            filteredProducts = filteredProducts.Where(p => p.Price == priceFilter).ToList();
        }

        if (nameFilter != null)
        {
            filteredProducts = filteredProducts.Where(p => p.Name.Contains(nameFilter)).ToList();
        }

        // Учитываем пагинацию
        var startIndex = (pageNumber - 1) * pageSize;
        var productsForPage = filteredProducts.Skip(startIndex).Take(pageSize).ToList();

        return productsForPage;
    }
}

// Пример использования репозитория ProductRepository
class Program
{
    static void Main(string[] args)
    {
        var repository = new ProductRepository();

        // Создание продукта
        var createdProduct = repository.CreateProduct("Название продукта", 100, "Описание продукта");

        // Чтение продукта
        var readProduct = repository.ReadProduct(createdProduct.Id);

        // Обновление продукта
        var updatedProduct = repository.UpdateProduct(createdProduct.Id, "Новое название продукта", 150, "Новое описание продукта");

        // Удаление продукта
        var isDeleted = repository.DeleteProduct(createdProduct.Id);

        // Получение продуктов с фильтрацией и пагинацией
        var filteredProducts = repository.FetchProducts(1, 100, "Название", 20);

        // Используйте результаты по вашему усмотрению
    }
}
