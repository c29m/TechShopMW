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


    public Cart FindItemInClientCart(int productid, string clientid)
    {
        try
        {
            using (TechShopDBEntities db = new TechShopDBEntities())
            {
                var item = (from x in db.Carts
                            where x.ProductId == productid
                            && x.ClientId == clientid
                            && x.IsInCart == true
                            select x).ToList();
                
                return item.FirstOrDefault();
            }
        }
        catch (Exception)
        {
            return null;
        }
    }


    public List<Cart> GetOrdersInCart(string userId)
    {
        TechShopDBEntities db = new TechShopDBEntities();
        List<Cart> orders = (from x in db.Carts
                             where x.ClientId == userId
                             && x.IsInCart
                             orderby x.DatePurchased
                             select x).ToList();
        return orders;
    }
    
    public int GetAmountOfOrders(string userId)
    {
        try
        {
            TechShopDBEntities db = new TechShopDBEntities();
            int amount = (from x in db.Carts
                          where x.ClientId == userId
                          && x.IsInCart
                          select x.Amount).Sum();
            return amount;
        }
        catch
        {
            return 0;
        }
    }

    public void UpdateQuantity(int id, int quantity)
    {
        TechShopDBEntities db = new TechShopDBEntities();
        Cart cart = db.Carts.Find(id);
        cart.Amount = quantity;
        db.SaveChanges();
    }

    public void MarkOrdersAsPaid(List<Cart> carts)
    {
        TechShopDBEntities db = new TechShopDBEntities();

        if(carts!=null)
        {
            foreach(Cart cart in carts)
            {
                Cart oldCart = db.Carts.Find(cart.Id);
                oldCart.DatePurchased = DateTime.Now;
                oldCart.IsInCart = false;
            }
            db.SaveChanges();
        }
    }
}