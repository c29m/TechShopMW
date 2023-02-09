using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ProductModel
/// </summary>
public class ProductModel
{
    public string InsertProduct(Product product)
    {
        try
        {
            TechShopDBEntities db = new TechShopDBEntities();
            db.Products.Add(product);
            db.SaveChanges();
            return $"{product.Name} was successfully inserted.";
        }
        catch(Exception ex)
        {
            return $"Error: {ex}";
        }
    }
    
    public string UpdateProduct(int id, Product product)
    {
        try
        {
            TechShopDBEntities db = new TechShopDBEntities();

            //Fetch from db
            Product p = db.Products.Find(id);
            p.Name = product.Name;
            p.TypeId= product.TypeId;
            p.Price = product.Price;
            p.Description = product.Description;
            p.Image = product.Image;

            db.SaveChanges();
            return $"{product.Name} was successfully updated.";
        }
        catch (Exception ex)
        {
            return $"Error: {ex}";
        }
    }

    public string DeleteProduct(int id)
    {
        try
        {
            TechShopDBEntities db = new TechShopDBEntities();
            Product p = db.Products.Find(id);
            db.Products.Attach(p);
            db.Products.Remove(p);
            db.SaveChanges();
            return $"{p.Name} was successfully deleted.";
        }
        catch (Exception ex)
        {
            return $"Error: {ex}";
        }
    }
}