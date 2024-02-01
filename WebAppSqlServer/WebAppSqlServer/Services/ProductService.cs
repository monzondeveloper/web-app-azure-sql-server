﻿using Microsoft.FeatureManagement;
using System.Data.SqlClient;
using WebAppSqlServer.Models;

namespace WebAppSqlServer.Services
{
    public class ProductService : IProductService
    {
        private readonly IConfiguration _configuration;
        private readonly IFeatureManager _featureManager;

        public ProductService(IConfiguration configuration, IFeatureManager featureManager)
        {
            _configuration = configuration;
            _featureManager = featureManager;
        }

        public async Task<bool> IsBeta()
        {
            if (await _featureManager.IsEnabledAsync("beta"))
                return true;

            return false;
        }

        public List<Product> GetProducts()
        {
            SqlConnection conn = GetConnection();

            var products = new List<Product>();

            string statement = "SELECT ProductId, ProductName, Quantity FROM Products";

            conn.Open();

            SqlCommand cmd = new SqlCommand(statement, conn);

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Product product = new Product
                    {
                        ProductId = reader.GetInt32(0),
                        ProductName = reader.GetString(1),
                        Quantity = reader.GetInt32(2)
                    };

                    products.Add(product);
                }
            }

            conn.Close();
            conn.Dispose();

            return products;
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(_configuration["SQLConnection"]);
        }
    }
}
