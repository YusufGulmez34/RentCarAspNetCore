using System;
using System.Collections.Generic;
using System.IO;
using Business.Abstract;
using Business.Concrete;
using Core.Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var stream = new FileStream("C:\\Users\\walte\\Desktop\\RentCar\\WebApı\\wwwroot\\Images", FileMode.Create))
            {
                //stream.Flush();
            }
        }
    }
}
