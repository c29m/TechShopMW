using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CartModel
/// </summary>
public class CartModel
{
    public string InsertCart(Cart cart)
    {
        try
        {
            TechShopDBEntities db = new TechShopDBEntities();
            db.Carts.Add(cart);
            db.SaveChanges();
            return $"{cart.DatePurchased} was successfully inserted.";
        }
        catch (Exception ex)
        {
            return $"Error: {ex}";
        }
    }

    public string UpdateCart(int id, Cart cart)
    {
        try
        {
            TechShopDBEntities db = new TechShopDBEntities();
            Cart c = db.Carts.Find(id);
            c.IsInCart = cart.IsInCart;
            c.DatePurchased = cart.DatePurchased;
            c.ClientId = cart.ClientId;
            c.Amount = cart.Amount;
            c.ProductId = cart.ProductId;
            db.SaveChanges();
            return $"{cart.DatePurchased} was successfully updated.";
        }
        catch (Exception ex)
        {
            return $"Error: {ex}";
        }
    }

    public string DeleteCart(int id)
    {
        try
        {
            TechShopDBEntities db = new TechShopDBEntities();
            Cart c = db.Carts.Find(id);
            db.Carts.Attach(c);
            db.Carts.Remove(c);
            db.SaveChanges();
            return $"{c.DatePurchased} was successfully deleted.";
        }
        catch (Exception ex)
        {
            return $"Error: {ex}";
        }
    }
}