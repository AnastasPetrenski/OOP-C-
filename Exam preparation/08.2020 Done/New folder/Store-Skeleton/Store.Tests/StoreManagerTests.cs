using NUnit.Framework;
using System;

namespace Store.Tests
{
    public class StoreManagerTests
    {
        private Product product;
        private StoreManager manager;

        [SetUp]
        public void Setup()
        {
            string name = "Test";
            int quantity = 10;
            decimal price = 100;

            this.product = new Product(name, quantity, price);

            this.manager = new StoreManager();
        }

        [Test]
        public void CreateProduct()
        {
            Assert.AreEqual("Test", product.Name);
            Assert.AreEqual(10, product.Quantity);
            Assert.AreEqual(100, product.Price);
        }

        [Test]
        public void CreateManager()
        {
            Assert.AreEqual(0, manager.Count);
            Assert.IsNotNull(manager);
        }

        [Test]
        public void AddProduct()
        {
            manager.AddProduct(product);

            Assert.AreEqual(1, manager.Count);
        }

        [Test]
        public void AddNullProduct()
        {
            Assert.Throws<ArgumentNullException>(() => manager.AddProduct(null));
        }

        [Test]
        public void AddProductWithNegativeQuantity()
        {
            product.Quantity = 0;

            Assert.Throws<ArgumentException>(() => manager.AddProduct(product));
        }

        [Test]
        public void CollectionAsReadonly()
        {
            manager.AddProduct(product);
            var collection = manager.Products.GetType().Name;

            Assert.AreEqual("ReadOnlyCollection`1", collection);
        }

        [Test]
        public void BuyProduct()
        {
            manager.AddProduct(product);
            var expectedSum = 500;

            Assert.AreEqual(expectedSum, manager.BuyProduct("Test", 5));
        }

        [Test]
        public void BuyNullProduct()
        {
            manager.AddProduct(product);

            Assert.Throws<ArgumentNullException>(() => manager.BuyProduct("Null", 5));
        }

        [Test]
        public void BuyMoreProducts()
        {
            manager.AddProduct(product);

            Assert.Throws<ArgumentException>(() => manager.BuyProduct("Test", 15));
        }

        [Test]
        public void GetMostExpensive()
        {
            manager.AddProduct(new Product("Test2", 12, 10));
            manager.AddProduct(product);

            var expected = manager.GetTheMostExpensiveProduct();

            Assert.That(expected, Is.EqualTo(product));
        }

    }
}