using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace WebApplication1.Migrations
{
    public partial class SecondMigrationAddingSauces : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO[dbo].[Sauces] ([Id], [Name]) VALUES(1, N'Majonez')");
            migrationBuilder.Sql("INSERT INTO[dbo].[Sauces] ([Id], [Name]) VALUES(2, N'Keczup')");
            migrationBuilder.Sql("INSERT INTO[dbo].[Sauces] ([Id], [Name]) VALUES(3, N'Duński')");
            migrationBuilder.Sql("INSERT INTO[dbo].[Sauces] ([Id], [Name]) VALUES(4, N'Musztarda')");
            migrationBuilder.Sql("INSERT INTO[dbo].[Sauces] ([Id], [Name]) VALUES(5, N'Tysiąca wysp')");
            migrationBuilder.Sql("INSERT INTO[dbo].[Sauces] ([Id], [Name]) VALUES(6, N'Diabolo')");
            migrationBuilder.Sql("INSERT INTO[dbo].[Sauces] ([Id], [Name]) VALUES(7, N'Arabski Łagodny')");
            migrationBuilder.Sql("INSERT INTO[dbo].[Sauces] ([Id], [Name]) VALUES(8, N'Arabski Ostry')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
