using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebLabs.DAL.Data;
using WebLabs.DAL.Entities;

namespace WebLabs.Services
{
    public class DbInitializer
    {
        public static async Task Seed(ApplicationDbContext context,
                                    UserManager<ApplicationUser> userManager,
                                    RoleManager<IdentityRole> roleManager)
        {
            context.Database.EnsureCreated();
            if(!context.Roles.Any())
            {
                var roleAdmin = new IdentityRole
                {
                    Name = "admin",
                    NormalizedName = "admin"
                };
                var result = await roleManager.CreateAsync(roleAdmin);
            }
            if(!context.Users.Any())
            {
                var user = new ApplicationUser
                {
                    Email = "user@mail.ru",
                    UserName = "user@mail.ru"
                };
                await userManager.CreateAsync(user, "123456");
                var admin = new ApplicationUser
                { 
                    Email = "admin@mail.ru", 
                    UserName = "admin@mail.ru" 
                };
                await userManager.CreateAsync(admin, "123456");
                admin = await userManager.FindByNameAsync("admin@mail.ru");
                await userManager.AddToRoleAsync(admin, "admin");
            }
            if(!context.TehnikaGroups.Any())
            {

                context.TehnikaGroups.AddRange(
                    new List<TehnikaGroup>
                    {
                        new TehnikaGroup {GroupName = "Техника для кухни" },
                        new TehnikaGroup {GroupName = "Техника для дома" },
                        new TehnikaGroup {GroupName = "Компьютерная техника" },
                        new TehnikaGroup {GroupName = "Садовая техника" }
                    });
                await context.SaveChangesAsync();
            }
            if (!context.Tehniks.Any())
            {
                context.Tehniks.AddRange(
                    new List<Tehnika>
                    {
                        new Tehnika
                {
                    
                    Name="Холодильник",
                    Images="холодильник.jpg",
                    TehnikaGroupId=1,
                    Cost=1300,
                    Amount=7
                },
                new Tehnika
                {
                    
                    Name="Духовка",
                    Images="духовка.jpg",
                    TehnikaGroupId=1,
                    Cost=450,
                    Amount=3
                },
                new Tehnika
                {
                    
                    Name="Плита",
                    Images="Плита.jpg",
                    TehnikaGroupId=1,
                    Cost=300,
                    Amount=1
                },
                new Tehnika
                {
                    
                    Name="Посудомоечная машина",
                    Images="Посудомоечная_машина.jpg",
                    TehnikaGroupId=1,
                    Cost=550,
                    Amount=30
                },
                new Tehnika
                {
                   
                    Name="Вытяжка",
                    Images="Вытяжка.jpg",
                    TehnikaGroupId=1,
                    Cost=120,
                    Amount=4
                },
                new Tehnika
                {
                    
                    Name="Чайник",
                    Images="Чайник.jpg",
                    TehnikaGroupId=1,
                    Cost=60,
                    Amount=20

                },
                new Tehnika
                {
                    
                    Name="Микроволновка",
                    Images="Микроволновка.jpg",
                    TehnikaGroupId=1,
                    Cost=150,
                    Amount=8

                },
                new Tehnika
                {
                    
                    Name="Телевизор",
                    Images="Телевизор.jpg",
                    TehnikaGroupId=2,
                    Cost=1500,
                    Amount=7

                },
                new Tehnika
                {
                    
                    Name="Пылесос",
                    Images="Пылесос.jpg",
                    TehnikaGroupId=2,
                    Cost=160,
                    Amount=10

                },
                new Tehnika
                {
                    
                    Name="Утюг",
                    Images="Утюг.jpg",
                    TehnikaGroupId=2,
                    Cost=80,
                    Amount=8

                },
                new Tehnika
                {
                    
                    Name="Стиралка",
                    Images="Стиралка.jpg",
                    TehnikaGroupId=2,
                    Cost=880,
                    Amount=5

                },
                new Tehnika
                {
                    
                    Name="Сушилка",
                    Images="Сушилка.jpg",
                    TehnikaGroupId=2,
                    Cost=660,
                    Amount=6

                },
                new Tehnika
                {
                    
                    Name="Монитор",
                    Images="Монитор.jpg",
                    TehnikaGroupId=3,
                    Cost=200,
                    Amount=20

                },
                new Tehnika
                {
                    
                    Name="Клавиатура",
                    Images="Клавиатура.jpg",
                    TehnikaGroupId=3,
                    Cost=40,
                    Amount=4

                },
                new Tehnika
                {
                    
                    Name="Мышка",
                    Images="Мышка.jpg",
                    TehnikaGroupId=3,
                    Cost=50,
                    Amount=90

                },
                new Tehnika
                {
                   
                    Name="Колонки",
                    Images="Колонки.jpg",
                    TehnikaGroupId=3,
                    Cost=70,
                    Amount=50

                },
                new Tehnika
                {
                    
                    Name="Принтер",
                    Images="Принтер.jpg",
                    TehnikaGroupId=3,
                    Cost=100,
                    Amount=10

                },
                new Tehnika
                {
                    
                    Name="Тример",
                    Images="Тример.jpg",
                    TehnikaGroupId=4,
                    Cost=340,
                    Amount=2

                },
                new Tehnika
                {
                   
                    Name="Газонокосилка",
                    Images="Газонокосилка.jpg",
                    TehnikaGroupId=4,
                    Cost=240,
                    Amount=2

                }
             });
                await context.SaveChangesAsync();
            }
        }
    }
}
