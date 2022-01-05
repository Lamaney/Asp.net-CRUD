using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace DotnetCrud.Models
{
    public class SchoolContext:DbContext
    {

        public SchoolContext(DbContextOptions <SchoolContext> options):base(options)
        {


        }        


        public DbSet<Student> student{get;set;}


    }



}
