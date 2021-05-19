using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestProject_Consimple.View;

namespace TestProject_Consimple.Models
{
    public class BaseModel
    {
        public List<ProductModel> Products { get; set; }
        public List<CategoryModel> Categories { get; set; }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            if (Products?.Count > 0)
            {
                foreach (var product in Products)
                {
                    var category = Categories?.FirstOrDefault(x => x.Id == product.CategoryId);
                    result.AppendFormat("{0, -21} {1,-5} {2, -21}\n", product.Name, MessageTemplates.tableSeparator, category?.Name ?? MessageTemplates.noCategoryTemplate);
                }
            }

            return result.ToString();
        }
    }
}
