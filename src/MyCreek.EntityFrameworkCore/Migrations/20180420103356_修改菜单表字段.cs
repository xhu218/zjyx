using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace MyCreek.Migrations
{
    public partial class 修改菜单表字段 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ParentMenuGuid",
                table: "SysMenuItem");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "SysMenuItem",
                nullable: false,
                oldClrType: typeof(Guid))
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<int>(
                name: "ParentMenuId",
                table: "SysMenuItem",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ParentMenuId",
                table: "SysMenuItem");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "SysMenuItem",
                nullable: false,
                oldClrType: typeof(int))
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<string>(
                name: "ParentMenuGuid",
                table: "SysMenuItem",
                nullable: true);
        }
    }
}
