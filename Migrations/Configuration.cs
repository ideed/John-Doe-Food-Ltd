namespace John_Doe_Food_Ltd.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Collections.Generic;
    using John_Doe_Food_Ltd.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<John_Doe_Food_Ltd.Models.LibraryContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(John_Doe_Food_Ltd.Models.LibraryContext context)
        {
            var Catalouge = new List<Catalouge>
            {
                new Catalouge{FoodName="Ben's Pringels",FoodType="Snack",CommericalGood=true},
                new Catalouge{FoodName="John's Home Made Meals",FoodType="Meal",CommericalGood=false},
                new Catalouge{FoodName="Steven Apples",FoodType="Fruit",CommericalGood=true},
                new Catalouge{FoodName="Steven Carrots",FoodType="Veg",CommericalGood=true},
                new Catalouge{FoodName="John's Microwave Meal",FoodType="Meal",CommericalGood=false},
                new Catalouge{FoodName="Nutella Cakes",FoodType="Pastry",CommericalGood=true},
                new Catalouge{FoodName="Smith's Pork",FoodType="Meat",CommericalGood=true},
                new Catalouge{FoodName="Smith's Beef",FoodType="Meat",CommericalGood=true},
                new Catalouge{FoodName="Eamonn Buns",FoodType="Pastry",CommericalGood=false},
                new Catalouge{FoodName="Eamonn Sponge Cake",FoodType="Pastry",CommericalGood=false},
                new Catalouge{FoodName="Nela's Imported Canned Foods",FoodType="Canned",CommericalGood=false},
                new Catalouge{FoodName="Eamonn's Local Canned Foods",FoodType="Canned",CommericalGood=true}
            };
            Catalouge.ForEach(c => context.Catalouges.AddOrUpdate(Catalouges => Catalouges.FoodName, c));
            context.SaveChanges();
            var Suppliers = new List<Supplier>
            {
                new Supplier{SupplierName="Steven's Farming Co",SupplierType="Farm",TelephoneNo="0854463290",Email="StevenFarming@gmail.com",Address="98 Country Road Wicklow",Supplies=Catalouge.Where(s =>(s.FoodName=="Steven Apples")||(s.FoodName=="Steven Carrots")).ToList()},
                new Supplier{SupplierName="John's Manufacturing",SupplierType="Factory",TelephoneNo="0872468231",Email="JohnSmith@gmail.com",Address="280 Industrial Road Dublin",Supplies=Catalouge.Where(s =>(s.FoodName=="John's Home Made Meals")||(s.FoodName=="John's Microwave Meal")).ToList()},
                new Supplier{SupplierName="Nela Wholeseller",SupplierType="Wholeseller",TelephoneNo="0897745689",Email="Nela@hotmail.com",Address="32 Commerical Road Cork",Supplies=Catalouge.Where(s =>(s.FoodName=="Ben's Pringels")||(s.FoodName=="Nutella Cakes")||(s.FoodName=="Nela's Imported Canned Foods")).ToList()},
                new Supplier{SupplierName="Smith's Farming Ltd",SupplierType="Farm",TelephoneNo="0837776629",Email="SmithFarming@yahoo.com",Address="69 Country Road Donegal",Supplies=Catalouge.Where(s =>(s.FoodName=="Smith's Pork")||(s.FoodName=="Smith's Beef")).ToList()},
                new Supplier{SupplierName="Eamonn Industrial Plant",SupplierType="Factory",TelephoneNo="0829866329",Email="EamonnIndustry@gmail.com",Address="24 Industrial Road Cork",Supplies=Catalouge.Where(s =>(s.FoodName=="Eamonn Buns")||(s.FoodName=="Eamonn Sponge Cake")||(s.FoodName=="Eamonn's Local Canned Foods")).ToList()},
            };
            Suppliers.ForEach(s => context.Suppliers.AddOrUpdate(Supplier => Supplier.SupplierName, s));
            context.SaveChanges();
            var Customer = new List<Customer>
            {
                new Customer{CustomerName="Ana",Commercial=false,TelephoneNo="0853328567",Email="ana@hotmail.com",Address="12 Residental Road Dublin"},
                new Customer{CustomerName="Ben",Commercial=true,TelephoneNo="0863343577",Email="benShopping@gmail.com",Address="14 Commerical Road Swords"},
                new Customer{CustomerName="Emanuela",Commercial=false,TelephoneNo="085544239",Email="emanuela@yahoo.com",Address="11 Residental Road Wicklow"},
                new Customer{CustomerName="Garry",Commercial=false,TelephoneNo="086653218",Email="gary@yahoo.com",Address="21 Residental Road Cork"},
                new Customer{CustomerName="Siobhan",Commercial=true,TelephoneNo="087321670",Email="siobhan@hotmail.com",Address="45 Commerical Road Dublin"},
                new Customer{CustomerName="Shauna",Commercial=true,TelephoneNo="089326732",Email="shauna@gmail.com",Address="24 Commerical Road Cork"},
                new Customer{CustomerName="Migel",Commercial=false,TelephoneNo="087322486",Email="migel@gmail.com",Address="33 Residental Road Donegal"}
            };
            Customer.ForEach(c => context.Customers.AddOrUpdate(Customers => Customers.CustomerName, c));
            context.SaveChanges();
            var Orders = new List<Order>
            {
                new Order{DateOrdered=new DateTime(2020,11,10), CatId=2, CusId=1},
                new Order{DateOrdered=new DateTime(2020,11,07), CatId=3, CusId=5},
                new Order{DateOrdered=new DateTime(2020,10,09), CatId=8, CusId=6},
                new Order{DateOrdered=new DateTime(2020,10,22), CatId=10, CusId=7},
                new Order{DateOrdered=new DateTime(2020,11,03), CatId=5, CusId=2},
                new Order{DateOrdered=new DateTime(2020,09,18), CatId=12, CusId=4},
                new Order{DateOrdered=new DateTime(2020,10,10), CatId=13, CusId=2},
                new Order{DateOrdered=new DateTime(2020,09,22), CatId=6, CusId=3},
                new Order{DateOrdered=new DateTime(2020,08,16), CatId=8, CusId=6},
                new Order{DateOrdered=new DateTime(2020,11,02), CatId=11, CusId=1},
                new Order{DateOrdered=new DateTime(2019,12,08), CatId=12, CusId=7},
                new Order{DateOrdered=new DateTime(2020,12,01), CatId=4, CusId=2},
                new Order{DateOrdered=new DateTime(2019,11,11), CatId=7, CusId=2}
            };
            Orders.ForEach(o => context.Orders.AddOrUpdate(Order => Order.CatId, o));
            context.SaveChanges();
        }
    }
}
