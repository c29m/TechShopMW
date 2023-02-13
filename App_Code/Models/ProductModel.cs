using Microsoft.AspNet.Identity;
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

    public Product GetProduct(int id)
    {
        try
        {
            using (TechShopDBEntities db = new TechShopDBEntities())
            {
                Product product = db.Products.Find(id);
                return product;
            }
        }
        catch(Exception)
        {
            return null;
        }
    }

    public List<Product> GetAllProducts()
    {
        try
        {
            using (TechShopDBEntities db = new TechShopDBEntities())
            {
                List<Product> products = (from x in db.Products select x).ToList();
                return products;
            }
        }
        catch (Exception)
        {
            return null;
        }
    }
    
    public List<Product> GetProductsByType(int typeid)
    {
        try
        {
            using (TechShopDBEntities db = new TechShopDBEntities())
            {
                List<Product> products = (from x in db.Products where x.TypeId == typeid select x).ToList();
                return products;
            }
        }
        catch (Exception)
        {
            return null;
        }
    }
    
    public List<Product> GetProductsByName(string name)
    {
        try
        {
            using (TechShopDBEntities db = new TechShopDBEntities())
            {
                List<Product> products = (from x in db.Products where x.Name.Contains(name) select x).ToList();
                return products;
            }
        }
        catch (Exception)
        {
            return null;
        }
    }
    
    public List<Product> GetProductsByNameAndType(string name, int typeid)
    {
        try
        {
            using (TechShopDBEntities db = new TechShopDBEntities())
                return (from x in db.Products where x.Name.Contains(name) && x.TypeId == typeid select x).ToList();
        }
        catch (Exception)
        {
            return null;
        }
    }

    public List<Product> GetProductsByPrice(int min, int max)
    {
        try
        {
            using (TechShopDBEntities db = new TechShopDBEntities())
                return (from x in db.Products where x.Price >= min && x.Price <= max select x).ToList();
        }
        catch (Exception)
        {
            return null;
        }
    }

    public List<Product> GetProductsByNameAndPrice(string name, int min, int max)
    {
        try
        {
            using (TechShopDBEntities db = new TechShopDBEntities())
                return (from x in db.Products where x.Name.Contains(name) && x.Price >= min && x.Price <= max select x).ToList();
        }
        catch (Exception)
        {
            return null;
        }
    }

    public List<Product> GetProductsByTypeAndPrice(int typeid, int min, int max)
    {
        try
        {
            using (TechShopDBEntities db = new TechShopDBEntities())
                return (from x in db.Products where x.TypeId == typeid && x.Price >= min && x.Price <= max select x).ToList();
        }
        catch (Exception)
        {
            return null;
        }
    }

    public List<Product> GetProductsByName_Type_Price(string name, int typeid, int min, int max)
    {
        try
        {
            using (TechShopDBEntities db = new TechShopDBEntities())
                return (from x in db.Products where x.Name.Contains(name) && x.TypeId == typeid && x.Price >= min && x.Price <= max select x).ToList();
        }
        catch (Exception)
        {
            return null;
        }
    }
}