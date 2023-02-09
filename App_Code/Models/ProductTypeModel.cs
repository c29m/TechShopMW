using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ProductTypeTypeModel
/// </summary>
public class ProductTypeTypeModel
{
    public string InsertProductType(ProductType productType)
    {
        try
        {
            TechShopDBEntities db = new TechShopDBEntities();
            db.ProductTypes.Add(productType);
            db.SaveChanges();
            return $"{productType.Name} was successfully inserted.";
        }
        catch (Exception ex)
        {
            return $"Error: {ex}";
        }
    }

    public string UpdateProductType(int id, ProductType productType)
    {
        try
        {
            TechShopDBEntities db = new TechShopDBEntities();
            ProductType p = db.ProductTypes.Find(id);
            p.Name = productType.Name;
            //p.Products = productType.Products;
            db.SaveChanges();
            return $"{productType.Name} was successfully updated.";
        }
        catch (Exception ex)
        {
            return $"Error: {ex}";
        }
    }

    public string DeleteProductType(int id)
    {
        try
        {
            TechShopDBEntities db = new TechShopDBEntities();
            ProductType p = db.ProductTypes.Find(id);
            db.ProductTypes.Attach(p);
            db.ProductTypes.Remove(p);
            db.SaveChanges();
            return $"{p.Name} was successfully deleted.";
        }
        catch (Exception ex)
        {
            return $"Error: {ex}";
        }
    }
}