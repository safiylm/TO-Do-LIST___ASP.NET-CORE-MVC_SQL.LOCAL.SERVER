using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TODOLIST_ASP.NET_CORE_MVC.Models;

namespace TODOLIST_ASP.NET_CORE_MVC.Data
{
    public class TodolistContext : DbContext
    {
        public TodolistContext (DbContextOptions<TodolistContext> options)
            : base(options)
        {
        }

        public DbSet<TodolistModel> TodolistModelDB { get; set; }
    }
}
