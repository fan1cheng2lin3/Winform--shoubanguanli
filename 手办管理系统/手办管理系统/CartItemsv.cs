using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace 手办管理系统
{
    internal class CartItemsv
    {
        DataClasses1DataContext db = new DataClasses1DataContext();

        public CartItem Add(int customerId, int productID, int qty)
        {
            CartItem cartItem = null;

            shangpinbiao product = (from p in db.shangpinbiao where p.Goods_ID == productID select p).First();


            cartItem = new CartItem();
            cartItem.Customer_ID = customerId;
            cartItem.Proid = product.Goods_ID;
            cartItem.ProName = product.Goods_Name;
            cartItem.ListPrice = product.chengben.Value;
            cartItem.UnPrice = product.Unit_Price;
            cartItem.Qty = qty;


            int ExistCartItemCount = (from c in db.CartItem
                                      where c.Customer_ID == customerId && c.Proid == productID
                                      select c).Count();

            if (ExistCartItemCount > 0)
            {
                CartItem existCartItem = (from c in db.CartItem
                                          where c.Customer_ID == customerId && c.Proid == productID
                                          select c).First();

                existCartItem.Qty += qty;

            }
            else
            {
                db.CartItem.InsertOnSubmit(cartItem);
            }

            db.SubmitChanges();
            return cartItem;

        }


        public (decimal, decimal) GetTotalPriceByCustomerId(int customerId)
        {
            List<CartItem> list = (from c in db.CartItem
                                   where c.Customer_ID == customerId
                                   select c).ToList();

            return ((decimal)list.Sum(c => c.ListPrice * c.Qty), (decimal)list.Sum(c => (c.ListPrice - c.UnPrice) * c.Qty));

        }
    }
}
