using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialNetwork.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class userToProfile : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Profiles_ProfileId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Posts");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "Profiles",
                newName: "AccountId");

            migrationBuilder.RenameColumn(
                name: "ImageProfileUrl",
                table: "Profiles",
                newName: "UserName");

            migrationBuilder.RenameColumn(
                name: "ProfileId",
                table: "Posts",
                newName: "AuthorId");

            migrationBuilder.RenameColumn(
                name: "ImageUrl",
                table: "Posts",
                newName: "PostImageUrl");

            migrationBuilder.RenameIndex(
                name: "IX_Posts_ProfileId",
                table: "Posts",
                newName: "IX_Posts_AuthorId");

            migrationBuilder.AddColumn<int>(
                name: "AccessFailedCount",
                table: "Profiles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ConcurrencyStamp",
                table: "Profiles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "EmailConfirmed",
                table: "Profiles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "LockoutEnabled",
                table: "Profiles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "LockoutEnd",
                table: "Profiles",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedEmail",
                table: "Profiles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedUserName",
                table: "Profiles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PasswordHash",
                table: "Profiles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PhoneNumberConfirmed",
                table: "Profiles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ProfileImageUrl",
                table: "Profiles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SecurityStamp",
                table: "Profiles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "TwoFactorEnabled",
                table: "Profiles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Posts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Profiles_AuthorId",
                table: "Posts",
                column: "AuthorId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Profiles_AuthorId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "AccessFailedCount",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "ConcurrencyStamp",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "EmailConfirmed",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "LockoutEnabled",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "LockoutEnd",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "NormalizedEmail",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "NormalizedUserName",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "PhoneNumberConfirmed",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "ProfileImageUrl",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "SecurityStamp",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "TwoFactorEnabled",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Posts");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "Profiles",
                newName: "ImageProfileUrl");

            migrationBuilder.RenameColumn(
                name: "AccountId",
                table: "Profiles",
                newName: "UserID");

            migrationBuilder.RenameColumn(
                name: "PostImageUrl",
                table: "Posts",
                newName: "ImageUrl");

            migrationBuilder.RenameColumn(
                name: "AuthorId",
                table: "Posts",
                newName: "ProfileId");

            migrationBuilder.RenameIndex(
                name: "IX_Posts_AuthorId",
                table: "Posts",
                newName: "IX_Posts_ProfileId");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Profiles_ProfileId",
                table: "Posts",
                column: "ProfileId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
