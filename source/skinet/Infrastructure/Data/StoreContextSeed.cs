using Core.Entities;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Data
{
    public class StoreContextSeed
    {
        public static async Task SeedAsync(StoreContext context, ILoggerFactory loggerFactory)
        {
            try
            {
                if(!context.Products.Any())
                {
                    var productsData = File.ReadAllText("../Infrastructure/Data/products.csv");
                    foreach(var line in productsData.Split('\n'))
                    try
                    {
                        if(line.StartsWith("identifier"))
                            continue;
                        
                        var cols = line.Split(',');

                        var title = cols[3];
                        var description = cols[4];
                        int.TryParse(cols[13], out var price);
                        var product = new Product()
                        {
                            Name = title,
                            Description = description,
                            Price = price,
                            ProductBrandId = 1,
                            ProductTypeId = 1
                        };

                        context.Products.Add(product);
                    }
                    catch
                    {
                        continue;
                    }

                    await context.SaveChangesAsync();
                }
            }
            catch(Exception ex)
            {
                var logger = loggerFactory.CreateLogger<StoreContextSeed>();
                logger.LogError("Exception" + ex.Message);
                logger.LogError("InnerException" + ex.InnerException.Message);
            }
        }
    }
}