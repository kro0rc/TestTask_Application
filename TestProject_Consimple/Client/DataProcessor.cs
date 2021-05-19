using System;
using System.Collections.Generic;
using TestProject_Consimple.Models;

namespace TestProject_Consimple.Client
{
    internal class DataProcessor : IDataProcessor
    {
        public List<Tuple<string, string>> CreateTable(BaseModel model)
        {
            List<Tuple<string, string>> result = new List<Tuple<string, string>>();
            List<ProductModel> products = model.Products;
            List<CategoryModel> categories = model.Categories;
            
            foreach(ProductModel product in products)
            {
                result.Add(new Tuple<string, string>(product.Name, categories.Find(x => x.Id == product.CategoryId).Name.ToString()));
            }

            return result;
        }
    }
}
