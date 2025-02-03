using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ModelCabinet.Server.Migrations
{
    /// <inheritdoc />
    public partial class AddedTagging : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tag",
                columns: table => new
                {
                    TagID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TagName = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tag", x => x.TagID);
                });

            migrationBuilder.CreateTable(
                name: "AssetTag",
                columns: table => new
                {
                    AssetTagsTagID = table.Column<int>(type: "int", nullable: false),
                    TaggedAssetsAssetId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetTag", x => new { x.AssetTagsTagID, x.TaggedAssetsAssetId });
                    table.ForeignKey(
                        name: "FK_AssetTag_Asset_TaggedAssetsAssetId",
                        column: x => x.TaggedAssetsAssetId,
                        principalTable: "Asset",
                        principalColumn: "AssetId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssetTag_Tag_AssetTagsTagID",
                        column: x => x.AssetTagsTagID,
                        principalTable: "Tag",
                        principalColumn: "TagID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectTag",
                columns: table => new
                {
                    ProjectTagsTagID = table.Column<int>(type: "int", nullable: false),
                    TaggedProjectsProjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectTag", x => new { x.ProjectTagsTagID, x.TaggedProjectsProjectId });
                    table.ForeignKey(
                        name: "FK_ProjectTag_Project_TaggedProjectsProjectId",
                        column: x => x.TaggedProjectsProjectId,
                        principalTable: "Project",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectTag_Tag_ProjectTagsTagID",
                        column: x => x.ProjectTagsTagID,
                        principalTable: "Tag",
                        principalColumn: "TagID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Asset",
                keyColumn: "AssetId",
                keyValue: 1,
                columns: new[] { "DateCreation", "DateUpdated", "Path" },
                values: new object[] { new DateTime(2025, 2, 3, 15, 33, 13, 315, DateTimeKind.Local).AddTicks(8202), new DateTime(2025, 2, 3, 15, 33, 13, 315, DateTimeKind.Local).AddTicks(8204), "C:\\Projects\\Visual_Studio\\ASP-NET\\ModelCabinet-Fork\\ModelCabinet.Server\\bin\\Debug\\net8.0\\Assets\\TestProject\\HelloWorld.stl" });

            migrationBuilder.UpdateData(
                table: "Asset",
                keyColumn: "AssetId",
                keyValue: 2,
                columns: new[] { "DateCreation", "DateUpdated", "Path" },
                values: new object[] { new DateTime(2025, 2, 3, 15, 33, 13, 315, DateTimeKind.Local).AddTicks(8209), new DateTime(2025, 2, 3, 15, 33, 13, 315, DateTimeKind.Local).AddTicks(8210), "C:\\Projects\\Visual_Studio\\ASP-NET\\ModelCabinet-Fork\\ModelCabinet.Server\\bin\\Debug\\net8.0\\Assets\\TestProject\\3DBenchy.stl" });

            migrationBuilder.UpdateData(
                table: "Project",
                keyColumn: "ProjectId",
                keyValue: 1,
                columns: new[] { "CreationDate", "ModifiedDate" },
                values: new object[] { new DateTime(2025, 2, 3, 15, 33, 13, 315, DateTimeKind.Local).AddTicks(7995), new DateTime(2025, 2, 3, 15, 33, 13, 315, DateTimeKind.Local).AddTicks(8047) });

            migrationBuilder.UpdateData(
                table: "Project",
                keyColumn: "ProjectId",
                keyValue: 2,
                columns: new[] { "CreationDate", "ModifiedDate" },
                values: new object[] { new DateTime(2025, 2, 3, 15, 33, 13, 315, DateTimeKind.Local).AddTicks(8051), new DateTime(2025, 2, 3, 15, 33, 13, 315, DateTimeKind.Local).AddTicks(8052) });

            migrationBuilder.InsertData(
                table: "Tag",
                columns: new[] { "TagID", "TagName" },
                values: new object[,]
                {
                    { 1, "Testing" },
                    { 2, "In Development" },
                    { 3, "Ready To Print" },
                    { 4, "Modular" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AssetTag_TaggedAssetsAssetId",
                table: "AssetTag",
                column: "TaggedAssetsAssetId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectTag_TaggedProjectsProjectId",
                table: "ProjectTag",
                column: "TaggedProjectsProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Tag_TagName",
                table: "Tag",
                column: "TagName",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AssetTag");

            migrationBuilder.DropTable(
                name: "ProjectTag");

            migrationBuilder.DropTable(
                name: "Tag");

            migrationBuilder.UpdateData(
                table: "Asset",
                keyColumn: "AssetId",
                keyValue: 1,
                columns: new[] { "DateCreation", "DateUpdated", "Path" },
                values: new object[] { new DateTime(2024, 11, 27, 12, 31, 28, 793, DateTimeKind.Local).AddTicks(3778), new DateTime(2024, 11, 27, 12, 31, 28, 793, DateTimeKind.Local).AddTicks(3786), "C:\\Users\\gaski\\source\\repos\\ModelCabinet\\ModelCabinet.Server\\bin\\Debug\\net8.0\\Assets\\TestProject\\HelloWorld.stl" });

            migrationBuilder.UpdateData(
                table: "Asset",
                keyColumn: "AssetId",
                keyValue: 2,
                columns: new[] { "DateCreation", "DateUpdated", "Path" },
                values: new object[] { new DateTime(2024, 11, 27, 12, 31, 28, 793, DateTimeKind.Local).AddTicks(3800), new DateTime(2024, 11, 27, 12, 31, 28, 793, DateTimeKind.Local).AddTicks(3804), "C:\\Users\\gaski\\source\\repos\\ModelCabinet\\ModelCabinet.Server\\bin\\Debug\\net8.0\\Assets\\TestProject\\3DBenchy.stl" });

            migrationBuilder.UpdateData(
                table: "Project",
                keyColumn: "ProjectId",
                keyValue: 1,
                columns: new[] { "CreationDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 11, 27, 12, 31, 28, 793, DateTimeKind.Local).AddTicks(3181), new DateTime(2024, 11, 27, 12, 31, 28, 793, DateTimeKind.Local).AddTicks(3290) });

            migrationBuilder.UpdateData(
                table: "Project",
                keyColumn: "ProjectId",
                keyValue: 2,
                columns: new[] { "CreationDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 11, 27, 12, 31, 28, 793, DateTimeKind.Local).AddTicks(3300), new DateTime(2024, 11, 27, 12, 31, 28, 793, DateTimeKind.Local).AddTicks(3305) });
        }
    }
}
