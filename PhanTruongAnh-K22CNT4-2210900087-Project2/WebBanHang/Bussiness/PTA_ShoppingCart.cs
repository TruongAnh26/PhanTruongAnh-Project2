using Antlr.Runtime.Tree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebBanHang.Models;

namespace WebBanHang.Bussiness
{
    public class PTA_ShoppingCart
    {
        public List<PTACartItem> Items { get; set; }
        public PTA_ShoppingCart() { 
            Items = new List<PTACartItem>();
        }

        // them gio hang
        public void AddToCart(PTACartItem item)
        {
            var existingItem = Items.FirstOrDefault(x=> x.ID == item.ID);
            if (existingItem != null)
            {
                existingItem.SoLuongMua += item.SoLuongMua;
            }
            else
            {
                Items.Add(item);
            }
        }
        public void RemoveCartItem(int id)
        {
            var itemToRemove = Items.FirstOrDefault(x=> x.ID==id);
            if (itemToRemove != null)
            {
                Items.Remove(itemToRemove);
            }
        }

        public float GetTongThanhTien()
        {
            return Items.Sum(x => x.SoLuongMua * x.DonGiaMua);
        }

        //cap nhat shopping cart
        public void UpdateFromCart(int id, int quantity)
        {
            var existing = Items.FirstOrDefault(x => x.ID == id);
            if (existing != null)
            {
                existing.SoLuongMua = quantity;
            }
        }
    }
}