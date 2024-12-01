using Project11_TriggerOrderStock.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Project11_TriggerOrderStock
{
    internal class Program
    {
        static void Main(string[] args)
        {
           Db11Project20Entities dbEntity = new Db11Project20Entities();

            Console.WriteLine("### SİPARİŞ STOK SİSTEMİ ###");
            Console.WriteLine();
            Console.WriteLine("1- Ürün Listesi");
            Console.WriteLine("2- Sipariş Listesi");
            Console.WriteLine("3-Kasa Durumu");
            Console.WriteLine("4-Yeni Ürün Satışı");
            Console.WriteLine("5-İşlem Sayacı");
            Console.WriteLine("6-Ürün Stok Güncelleme");
            Console.WriteLine();
            Console.WriteLine("---------------------------");
            Console.WriteLine();

            Console.Write("Lütfen yapmakistediğiniz işlemi seçin: ");
            string number = Console.ReadLine();
            Console.WriteLine();

            if (number == "1")
            {
                Console.WriteLine("---- Ürün Listesi: ----");
                var values = dbEntity.TblProducts.ToList();
                foreach (var value in values)
                {
                    Console.WriteLine(value.ProductId+" -- Ürün İsmi: "+value.ProductName + " -- Stok Sayısı: " +  value.ProductStock + "-- Ürün Fiyatı: " + value.ProductPrice + "TL" );
                }
            }
            if (number == "2")
            {
                Console.WriteLine("---- Sipariş Listesi: ----");

                var values2 = dbEntity.TblOrders.ToList();
                foreach (var value in values2) 
                {
                    Console.WriteLine(value.OrderId + " -- Müşteri İsmi: " + value.Customer +" -- Ürün Adı: "+value.TblProduct.ProductName+ " -- Adet: " + value.Quantity + " -- Birim Fiyat: " + value.UnitPrice + " TL" + " -- Total Fiyat: " + value.TotalPrice + " TL");

                }

            }
            if (number == "3")
            {
                Console.WriteLine("---- Kasa Durumu: ----");

                var values = dbEntity.TblCashRegisters.Select(x=>x.Balance).FirstOrDefault();
                Console.WriteLine("Kasadaki Toplam Tutar: "+values+" TL");



            }
            if (number == "4")
            {
                Console.WriteLine("---- Yeni Ürün Sipariş Girişi  ----");

                Console.Write("Müşteri Adı: ");
                string customer = Console.ReadLine();
                Console.Write("Ürün Id: ");
                int productid = int.Parse(Console.ReadLine());
                Console.Write("Ürün Adedi: ");
                int quantity = int.Parse(Console.ReadLine());

                Console.WriteLine();
                Console.WriteLine("---- Ürün Bilgileri ----");
                Console.WriteLine();
                var productName=dbEntity.TblProducts.Where(x=>x.ProductId==productid).Select(x=>x.ProductName).FirstOrDefault();
                Console.WriteLine("Ürün Adı: "+productName);

                var productUnitPrice = dbEntity.TblProducts.Where(x=> x.ProductId == productid).Select(y=>y.ProductPrice).FirstOrDefault();
              
                Console.WriteLine("Ürünün Birim Fiyatı: "+ productUnitPrice+"TL");

              decimal totalPrice = decimal.Parse((quantity*productUnitPrice).ToString());
               // Console.WriteLine("Ürünün Total Fiyatı: "+productUnitPrice*quantity+"TL");
                Console.WriteLine("Ürünün Total Fiyatı: "+totalPrice+"TL");
                Console.WriteLine();
               
                
                TblOrder tblOrder = new TblOrder();
                tblOrder.UnitPrice=productUnitPrice;
                tblOrder.Quantity=quantity;
                tblOrder.ProductId=productid;
                tblOrder.TotalPrice=totalPrice;
               tblOrder.Customer=customer;

                dbEntity.TblOrders.Add(tblOrder);
                dbEntity.SaveChanges();
            }

            if (number == "5") 
            {
                var value=dbEntity.TblProcesses.Select(x=>x.Process).FirstOrDefault();
                  
            }

            Console.Read();
        }
    }
}
