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
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(John_Doe_Food_Ltd.Models.LibraryContext context)
        {
            var Suppliers = new List<Supplier>
            {
                new Supplier{SupplierName="Steven's Farming Co",SupplierType="Farm",TelephoneNo="0854463290",Email="StevenFarming@gmail.com",Address="98 Country Road Wicklow"},
                new Supplier{SupplierName="John's Manufacturing",SupplierType="Factory",TelephoneNo="0872468231",Email="JohnSmith@gmail.com",Address="280 Industrial Road Dublin"},
                new Supplier{SupplierName="Nela Wholeseller",SupplierType="Wholeseller",TelephoneNo="0897745689",Email="Nela@hotmail.com",Address="32 Commerical Road Cork"},
                new Supplier{SupplierName="Smith's Farming Ltd",SupplierType="Farm",TelephoneNo="0837776629",Email="SmithFarming@yahoo.com",Address="69 Country Road Donegal"},
                new Supplier{SupplierName="Eamonn Industrial Plant",SupplierType="Factory",TelephoneNo="0829866329",Email="EamonnIndustry@gmail.com",Address="24 Industrial Road Cork"}
            };
            Suppliers.ForEach(s => context.Suppliers.AddOrUpdate(Supplier => Supplier.SupplierName, s));
            context.SaveChanges();
            var Catalouge = new List<Catalouge>
            {
                new Catalouge{FoodName="Ben's Pringels",FoodType="Snack",CommericalGood=true,Supplier=Suppliers.Where(s => (s.SupplierName=="John's Manufacturing")).ToList()},
                new Catalouge{FoodName="John's Home Made Meals",FoodType="Meal",CommericalGood=false, Supplier=Suppliers.Where(s => (s.SupplierName=="Nela Wholeseller")).ToList()},
                new Catalouge{FoodName="Steven Apples",FoodType="Fruit",CommericalGood=true, Supplier=Suppliers.Where(s => (s.SupplierName=="Steven's Farming Co")).ToList()},
                new Catalouge{FoodName="Steven Carrots",FoodType="Veg",CommericalGood=true, Supplier=Suppliers.Where(s => (s.SupplierName=="Steven's Farming Co")).ToList()},
                new Catalouge{FoodName="John's Microwave Meal",FoodType="Meal",CommericalGood=false, Supplier=Suppliers.Where(s => (s.SupplierName=="John's Manufacturing")).ToList()},
                new Catalouge{FoodName="Nutella Cakes",FoodType="Pastry",CommericalGood=true, Supplier=Suppliers.Where(s => (s.SupplierName=="Nela Wholeseller")).ToList()},
                new Catalouge{FoodName="Smith's Pork",FoodType="Meat",CommericalGood=true, Supplier=Suppliers.Where(s => (s.SupplierName=="Smith's Farming Ltd")).ToList()},
                new Catalouge{FoodName="Smith's Beef",FoodType="Meat",CommericalGood=true, Supplier=Suppliers.Where(s => (s.SupplierName=="Smith's Farming Ltd")).ToList()},
                new Catalouge{FoodName="Eamonn Buns",FoodType="Pastry",CommericalGood=false, Supplier=Suppliers.Where(s => (s.SupplierName=="Eamonn Industrial Plant")).ToList()},
                new Catalouge{FoodName="Eamonn Sponge Cake",FoodType="Pastry",CommericalGood=false, Supplier=Suppliers.Where(s => (s.SupplierName=="Eamonn Industrial Plant")).ToList()},
                new Catalouge{FoodName="Nela's Imported Canned Foods",FoodType="Canned",CommericalGood=false, Supplier=Suppliers.Where(s => (s.SupplierName=="Nela Wholeseller")).ToList()},
                new Catalouge{FoodName="Eamonn's Local Canned Foods",FoodType="Canned",CommericalGood=true, Supplier=Suppliers.Where(s => (s.SupplierName=="Eamonn Industrial Plant")).ToList()}
            };
            Catalouge.ForEach(c => context.Catalouges.AddOrUpdate(Catalouges => Catalouges.FoodName, c));
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
                new Order{DateOrdered=new DateTime(2020,11,10), Product=Catalouge.Where(p =>(p.FoodName=="John's Home Made Meals")).ToList(), Customer=Customer.Where(c=>(c.CustomerName=="Ana")).ToList()},
                new Order{DateOrdered=new DateTime(2020,11,07), Product=Catalouge.Where(p =>(p.FoodName=="Ben's Pringels")).ToList(), Customer=Customer.Where(c=>(c.CustomerName=="Siobhan")).ToList()},
                new Order{DateOrdered=new DateTime(2020,10,09), Product=Catalouge.Where(p =>(p.FoodName=="Smith's Pork")).ToList(), Customer=Customer.Where(c=>(c.CustomerName=="Shauna")).ToList()},
                new Order{DateOrdered=new DateTime(2020,10,22), Product=Catalouge.Where(p =>(p.FoodName=="Eamonn Buns")).ToList(), Customer=Customer.Where(c=>(c.CustomerName=="Migel")).ToList()},
                new Order{DateOrdered=new DateTime(2020,11,03), Product=Catalouge.Where(p =>(p.FoodName=="Steven Carrots")).ToList(), Customer=Customer.Where(c=>(c.CustomerName=="Ben")).ToList()},
                new Order{DateOrdered=new DateTime(2020,09,18), Product=Catalouge.Where(p =>(p.FoodName=="Nela's Imported Canned Foods")).ToList(), Customer=Customer.Where(c=>(c.CustomerName=="Garry")).ToList()},
                new Order{DateOrdered=new DateTime(2020,10,10), Product=Catalouge.Where(p =>(p.FoodName=="Eamonn's Local Canned Foods")).ToList(), Customer=Customer.Where(c=>(c.CustomerName=="Ben")).ToList()},
                new Order{DateOrdered=new DateTime(2020,09,22), Product=Catalouge.Where(p =>(p.FoodName=="John's Microwave Meal")).ToList(), Customer=Customer.Where(c=>(c.CustomerName=="Emanuela")).ToList()},
                new Order{DateOrdered=new DateTime(2020,08,16), Product=Catalouge.Where(p =>(p.FoodName=="Smith's Pork")).ToList(), Customer=Customer.Where(c=>(c.CustomerName=="Shauna")).ToList()},
                new Order{DateOrdered=new DateTime(2020,11,02), Product=Catalouge.Where(p =>(p.FoodName=="Eamonn Sponge Cake")).ToList(), Customer=Customer.Where(c=>(c.CustomerName=="Ana")).ToList()},
                new Order{DateOrdered=new DateTime(2019,12,08), Product=Catalouge.Where(p =>(p.FoodName=="Nela's Imported Canned Foods")).ToList(), Customer=Customer.Where(c=>(c.CustomerName=="Migel")).ToList()},
                new Order{DateOrdered=new DateTime(2020,12,01), Product=Catalouge.Where(p =>(p.FoodName=="Steven Apples")).ToList(),  Customer=Customer.Where(c=>(c.CustomerName=="Ben")).ToList()},
                new Order{DateOrdered=new DateTime(2019,11,11), Product=Catalouge.Where(p =>(p.FoodName=="Nutella Cakes")).ToList(), Customer=Customer.Where(c=>(c.CustomerName=="Ben")).ToList()}
            };
            Orders.ForEach(o => context.Orders.AddOrUpdate(Order => Order.DateOrdered, o));
            context.SaveChanges();
        }
    }
}
