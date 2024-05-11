using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Todo.Data.Migrations
{
    /// <inheritdoc />
    public partial class TodoUserRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Todos",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8716071C-1D9B-48FD-B3D0-F059C4FB8031",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8b9b8539-3f1c-4e16-9181-9e3b05e0d822", "AQAAAAIAAYagAAAAEPCksRBo3s+TuGLTKS1GR0lWxcCo3QTUD2IQOMqFAtVCSE7ykJ8pwHQTB6udw+pyuw==", "1a707fc0-edbd-460a-9348-a0bdfe58ec4e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "87746F88-DC38-4756-924A-B95CFF3A1D8A",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e06f9286-ca2b-4665-a993-2213422ebfd6", "AQAAAAIAAYagAAAAEO7krdcb4/Cbtmp0G5PB2joZlYbIVGxSrceCn4oc0+a60NIictcoCC8zxec3NgMbdQ==", "7c69765d-c552-49b8-9c2d-9e2cda207e10" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "D514EDC9-94BB-416F-AF9D-7C13669689C9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6482d2eb-aad0-49a1-b45d-8ca107729157", "AQAAAAIAAYagAAAAEAoBh62/MFLBHRTdp6lMquK8TPqRQzmNt4DJoSJ9bJXlkfzyQOpnG9weI50o4FFRxw==", "83893219-6984-4e5b-8afd-2720fed72bcd" });

            migrationBuilder.UpdateData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate", "UserId" },
                values: new object[] { new DateTime(2024, 5, 11, 21, 57, 0, 355, DateTimeKind.Local).AddTicks(6860), new DateTime(2024, 5, 11, 20, 57, 0, 355, DateTimeKind.Local).AddTicks(6859), "D514EDC9-94BB-416F-AF9D-7C13669689C9" });

            migrationBuilder.UpdateData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate", "UserId" },
                values: new object[] { new DateTime(2024, 5, 11, 21, 57, 0, 355, DateTimeKind.Local).AddTicks(6869), new DateTime(2024, 5, 11, 20, 57, 0, 355, DateTimeKind.Local).AddTicks(6868), "D514EDC9-94BB-416F-AF9D-7C13669689C9" });

            migrationBuilder.UpdateData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EndDate", "StartDate", "UserId" },
                values: new object[] { new DateTime(2024, 5, 12, 1, 57, 0, 355, DateTimeKind.Local).AddTicks(6872), new DateTime(2024, 5, 11, 20, 57, 0, 355, DateTimeKind.Local).AddTicks(6871), "D514EDC9-94BB-416F-AF9D-7C13669689C9" });

            migrationBuilder.UpdateData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "EndDate", "StartDate", "UserId" },
                values: new object[] { new DateTime(2024, 5, 18, 20, 57, 0, 355, DateTimeKind.Local).AddTicks(6874), new DateTime(2024, 5, 11, 20, 57, 0, 355, DateTimeKind.Local).AddTicks(6874), "D514EDC9-94BB-416F-AF9D-7C13669689C9" });

            migrationBuilder.UpdateData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "EndDate", "StartDate", "UserId" },
                values: new object[] { new DateTime(2024, 5, 14, 20, 57, 0, 355, DateTimeKind.Local).AddTicks(6878), new DateTime(2024, 5, 11, 20, 57, 0, 355, DateTimeKind.Local).AddTicks(6878), "87746F88-DC38-4756-924A-B95CFF3A1D8A" });

            migrationBuilder.UpdateData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "EndDate", "StartDate", "UserId" },
                values: new object[] { new DateTime(2024, 5, 21, 20, 57, 0, 355, DateTimeKind.Local).AddTicks(6881), new DateTime(2024, 5, 11, 20, 57, 0, 355, DateTimeKind.Local).AddTicks(6880), "87746F88-DC38-4756-924A-B95CFF3A1D8A" });

            migrationBuilder.CreateIndex(
                name: "IX_Todos_UserId",
                table: "Todos",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Todos_AspNetUsers_UserId",
                table: "Todos",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Todos_AspNetUsers_UserId",
                table: "Todos");

            migrationBuilder.DropIndex(
                name: "IX_Todos_UserId",
                table: "Todos");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Todos");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8716071C-1D9B-48FD-B3D0-F059C4FB8031",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "216ce114-86b5-49ee-b904-11c45cd2239e", "AQAAAAIAAYagAAAAECTnrmMqjLuUCqBZzApyjguKBeZUjWmQKfpnVJfUTgsg9NgfhK19bY1dzHQ5BByxJw==", "70f13fe1-6fcb-44fb-9f76-b64aa7145998" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "87746F88-DC38-4756-924A-B95CFF3A1D8A",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1b16f8c7-78a2-41e8-b18a-68c6edd0c19f", "AQAAAAIAAYagAAAAEAMo6ikGNy8X3I/OSlzVi/0A/HZxH2ltYCcuFNu7YjvMCkq5/AvPX+Fvvzrli1FLTQ==", "c3e02507-905c-499c-a4ff-6c0e3e6d3530" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "D514EDC9-94BB-416F-AF9D-7C13669689C9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1f17a315-a697-4040-9251-0747f464da90", "AQAAAAIAAYagAAAAEPlU42TCWJGkDHUgXeQq/WsRKKzZ+M1TGard55dQol4UN1D4sreQNIv2N3pdqJIDcg==", "dc5b248e-ee04-41aa-88c0-761523c2869b" });

            migrationBuilder.UpdateData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 5, 10, 3, 49, 3, 386, DateTimeKind.Local).AddTicks(3038), new DateTime(2024, 5, 10, 2, 49, 3, 386, DateTimeKind.Local).AddTicks(3037) });

            migrationBuilder.UpdateData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 5, 10, 3, 49, 3, 386, DateTimeKind.Local).AddTicks(3047), new DateTime(2024, 5, 10, 2, 49, 3, 386, DateTimeKind.Local).AddTicks(3047) });

            migrationBuilder.UpdateData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 5, 10, 7, 49, 3, 386, DateTimeKind.Local).AddTicks(3050), new DateTime(2024, 5, 10, 2, 49, 3, 386, DateTimeKind.Local).AddTicks(3050) });

            migrationBuilder.UpdateData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 5, 17, 2, 49, 3, 386, DateTimeKind.Local).AddTicks(3053), new DateTime(2024, 5, 10, 2, 49, 3, 386, DateTimeKind.Local).AddTicks(3052) });

            migrationBuilder.UpdateData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 5, 13, 2, 49, 3, 386, DateTimeKind.Local).AddTicks(3058), new DateTime(2024, 5, 10, 2, 49, 3, 386, DateTimeKind.Local).AddTicks(3058) });

            migrationBuilder.UpdateData(
                table: "Todos",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 5, 20, 2, 49, 3, 386, DateTimeKind.Local).AddTicks(3061), new DateTime(2024, 5, 10, 2, 49, 3, 386, DateTimeKind.Local).AddTicks(3060) });
        }
    }
}
