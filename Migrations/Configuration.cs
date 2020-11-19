﻿namespace John_Doe_Food_Ltd.Migrations
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
            var Orders = new List<Orders>
            {
                new Orders{OrderId=0,DateOrdered=new DateTime(2020,11,10)}
            };
            var Catalouge = new List<Catalouge>
            {
                new Catalouge{FoodName="Ben's Pringels",FoodType="Snack",CommericalGood=true},
                new Catalouge{FoodName="John's Home Made Meals",FoodType="Meal",CommericalGood=false,Orders=Orders.Where(o => (o.OrderId==0)).ToList()},
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
            var Suppliers = new List<Supplier>
            {
                new Supplier{SupplierName="Steven's Farming Co",SupplierType="Farm",TelephoneNo="0854463290",Email="StevenFarming@gmail.com",Address="98 Country Road Wicklow",Supplies=Catalouge.Where(s =>(s.FoodName=="Steven Apples")||(s.FoodName=="Steven Carrots")).ToList()},
                new Supplier{SupplierName="John's Manufacturing",SupplierType="Factory",TelephoneNo="0872468231",Email="JohnSmith@gmail.com",Address="280 Industrial Road Dublin",Supplies=Catalouge.Where(s =>(s.FoodName=="John's Home Made Meals")||(s.FoodName=="John's Microwave Meal")).ToList()},
                new Supplier{SupplierName="Nela Wholeseller",SupplierType="Wholeseller",TelephoneNo="0897745689",Email="Nela@hotmail.com",Address="32 Commerical Road Cork",Supplies=Catalouge.Where(s =>(s.FoodName=="Ben's Pringels")||(s.FoodName=="Nutella Cakes")||(s.FoodName=="Nela's Imported Canned Foods")).ToList()},
                new Supplier{SupplierName="Smith's Farming Ltd",SupplierType="Farm",TelephoneNo="0837776629",Email="SmithFarming@yahoo.com",Address="69 Country Road Donegal",Supplies=Catalouge.Where(s =>(s.FoodName=="Smith's Pork")||(s.FoodName=="Smith's Beef")).ToList()},
                new Supplier{SupplierName="Eamonn Industrial Plant",SupplierType="Factory",TelephoneNo="0829866329",Email="EamonnIndustry@gmail.com",Address="24 Industrial Road Cork",Supplies=Catalouge.Where(s =>(s.FoodName=="Eamonn Buns")||(s.FoodName=="Eamonn Sponge Cake")||(s.FoodName=="Eamonn's Local Canned Foods")).ToList()},
            };
            var Customer = new List<Customer>
            {
                new Customer{CustomerName="Ana",Commercial=false,TelephoneNo="0853328567",Email="ana@hotmail.com",Address="12 Residental Road Dublin",Orders=Orders.Where(o => (o.OrderId==0)).ToList()},
                new Customer{CustomerName="Ben",Commercial=true,TelephoneNo="0863343577",Email="benShopping@gmail.com",Address="14 Commerical Road Swords"},
                new Customer{CustomerName="Emanuela",Commercial=false,TelephoneNo="085544239",Email="emanuela@yahoo.com",Address="11 Residental Road Wicklow"},
                new Customer{CustomerName="Garry",Commercial=false,TelephoneNo="086653218",Email="gary@yahoo.com",Address="21 Residental Road Cork"},
                new Customer{CustomerName="Siobhan",Commercial=true,TelephoneNo="087321670",Email="siobhan@hotmail.com",Address="45 Commerical Road Dublin"},
                new Customer{CustomerName="Shauna",Commercial=true,TelephoneNo="089326732",Email="shauna@gmail.com",Address="24 Commerical Road Cork"},
                new Customer{CustomerName="Migel",Commercial=false,TelephoneNo="087322486",Email="migel@gmail.com",Address="33 Residental Road Donegal"}
            };            
        }
    }
}
