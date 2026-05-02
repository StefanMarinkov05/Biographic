using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Biographic.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Nickname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Professions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsersCatalogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersCatalogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsersCatalogs_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ProfileImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    ProfessionId = table.Column<int>(type: "int", nullable: false),
                    Biography = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDead = table.Column<bool>(type: "bit", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.Id);
                    table.ForeignKey(
                        name: "FK_People_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_People_Professions_ProfessionId",
                        column: x => x.ProfessionId,
                        principalTable: "Professions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PeopleCatalogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    UserCatalogsId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PeopleCatalogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PeopleCatalogs_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PeopleCatalogs_UsersCatalogs_UserCatalogsId",
                        column: x => x.UserCatalogsId,
                        principalTable: "UsersCatalogs",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PeopleCatalogPerson",
                columns: table => new
                {
                    PeopleCatalogsId = table.Column<int>(type: "int", nullable: false),
                    PeopleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PeopleCatalogPerson", x => new { x.PeopleCatalogsId, x.PeopleId });
                    table.ForeignKey(
                        name: "FK_PeopleCatalogPerson_PeopleCatalogs_PeopleCatalogsId",
                        column: x => x.PeopleCatalogsId,
                        principalTable: "PeopleCatalogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PeopleCatalogPerson_People_PeopleId",
                        column: x => x.PeopleId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Австралия" },
                    { 2, "Австрия" },
                    { 3, "Англия" },
                    { 4, "Аржентина" },
                    { 5, "Белгия" },
                    { 6, "Бразилия" },
                    { 7, "България" },
                    { 8, "Германия" },
                    { 9, "Гърция" },
                    { 10, "Дания" },
                    { 11, "Египет" },
                    { 12, "Испания" },
                    { 13, "Италия" },
                    { 14, "Индия" },
                    { 15, "Иран" },
                    { 16, "Ирландия" },
                    { 17, "Исландия" },
                    { 18, "Канада" },
                    { 19, "Китай" },
                    { 20, "Мексико" },
                    { 21, "Нидерландия" },
                    { 22, "Норвегия" },
                    { 23, "Полша" },
                    { 24, "Португалия" },
                    { 25, "Русия" },
                    { 26, "Румъния" },
                    { 27, "Саудитска Арабия" },
                    { 28, "САЩ" },
                    { 29, "Сърбия" },
                    { 30, "Турция" },
                    { 31, "Украйна" },
                    { 32, "Унгария" },
                    { 33, "Финландия" },
                    { 34, "Франция" },
                    { 35, "Чехия" },
                    { 36, "Чили" },
                    { 37, "Швейцария" },
                    { 38, "Швеция" },
                    { 39, "Южна Африка" },
                    { 40, "Япония" },
                    { 41, "Ямайка" }
                });

            migrationBuilder.InsertData(
                table: "Professions",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Авиатор" },
                    { 2, "Актьор" },
                    { 3, "Архитект" },
                    { 4, "Астронавт" },
                    { 5, "Астроном" },
                    { 6, "Биолог" },
                    { 7, "Военачалник" },
                    { 8, "Готвач" },
                    { 9, "Диригент" },
                    { 10, "Дизайнер" },
                    { 11, "Дипломат" },
                    { 12, "Драматург" },
                    { 13, "Журналист" },
                    { 14, "Изобретател" },
                    { 15, "Инженер" },
                    { 16, "Композитор" },
                    { 17, "Математик" },
                    { 18, "Монарх" },
                    { 19, "Музикант" },
                    { 20, "Писател" },
                    { 21, "Политик" },
                    { 22, "Поет" },
                    { 23, "Преводач" },
                    { 24, "Преподавател" },
                    { 25, "Програмист" },
                    { 26, "Психолог" },
                    { 27, "Режисьор" },
                    { 28, "Скулптор" },
                    { 29, "Спортист" },
                    { 30, "Теоретик" },
                    { 31, "Учен" },
                    { 32, "Фармацевт" },
                    { 33, "Физик" },
                    { 34, "Философ" },
                    { 35, "Фотограф" },
                    { 36, "Химик" },
                    { 37, "Художник" },
                    { 38, "Шахматист" },
                    { 39, "Експлоратор" },
                    { 40, "Икономист" }
                });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "Id", "Biography", "CountryId", "EndDate", "IsDead", "Name", "ProfessionId", "ProfileImage", "StartDate" },
                values: new object[,]
                {
                    { 1, "Теоретичен физик, известен с разработването на теорията на относителността. Носител на Нобелова награда за физика през 1921 година.", 37, new DateTime(1955, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Алберт Айнщайн", 33, "person1.jpg", new DateTime(1879, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "Италиански ренесансов художник, изобретател и учен. Автор на Мона Лиза и Тайната вечеря.", 13, new DateTime(1519, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Леонардо да Винчи", 37, "person2.jpg", new DateTime(1452, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "Пионер в радиологията, носител на две Нобелови награди - за физика и химия.", 24, new DateTime(1934, 7, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Мария Кюри", 36, "person3.jpg", new DateTime(1867, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, "Ямайски състезател по лека атлетика, световен рекордьор в бягането на 100 и 200 метра.", 41, null, false, "Усейн Болт", 29, "person4.jpg", new DateTime(1986, 8, 21, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, "Руски писател, автор на 'Престъпление и наказание' и 'Братя Карамазови'.", 25, new DateTime(1881, 2, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Фьодор Достоевски", 20, "person5.jpg", new DateTime(1821, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, "Южноафрикански политик и борец срещу апартейда, президент на ЮАР (1994-1999).", 39, new DateTime(2013, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Нелсън Мандела", 21, "person6.jpg", new DateTime(1918, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, "Австрийски композитор, един от най-влиятелните в класическата музика.", 2, new DateTime(1791, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Волфганг Амадеус Моцарт", 16, "person7.jpg", new DateTime(1756, 1, 27, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, "Италиански скулптор, художник и архитект от епохата на Ренесанса.", 13, new DateTime(1564, 2, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Микеланджело Буонароти", 28, "person8.jpg", new DateTime(1475, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, "Индийски политик и духовен лидер, водач на движението за независимост на Индия.", 14, new DateTime(1948, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Махатма Ганди", 21, "person9.jpg", new DateTime(1869, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, "Последна царица на Древен Египет, известна с интелигентността и политическите си умения.", 11, new DateTime(69, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Клеопатра", 18, "person10.jpg", new DateTime(30, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11, "Испански художник, създател на кубизма, един от най-влиятелните художници на 20 век.", 12, new DateTime(1973, 4, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Пабло Пикасо", 37, "person11.jpg", new DateTime(1881, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 12, "Основател на Монголската империя, един от най-успешните военачалници в историята.", 28, new DateTime(1227, 8, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Чингиз Хан", 7, "person12.jpg", new DateTime(1162, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 13, "Владетелка на Хабсбургската монархия, една от най-влиятелните жени в европейската история.", 2, new DateTime(1780, 11, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Мария Тереза", 18, "person13.jpg", new DateTime(1717, 5, 13, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 14, "Съосновател на Apple Inc., пионер в компютърната индустрия.", 28, new DateTime(2011, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Стив Джобс", 25, "person14.jpg", new DateTime(1955, 2, 24, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 15, "Немски астроном, известен с формулирането на законите за движение на планетите.", 8, new DateTime(1630, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Йоханес Кеплер", 5, "person15.jpg", new DateTime(1571, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 16, "Френска модна дизайнерка, основателка на модната къща Chanel.", 34, new DateTime(1971, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Коко Шанел", 10, "person16.jpg", new DateTime(1883, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 17, "Немски композитор, един от най-великите в историята на класическата музика.", 5, new DateTime(1827, 3, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Лудвиг ван Бетховен", 16, "person17.jpg", new DateTime(1770, 12, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 18, "Италиански астроном и физик, наричан 'бащата на модерната наука'.", 13, new DateTime(1642, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Галилео Галилей", 31, "person18.jpg", new DateTime(1564, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 19, "Еврейско момиче, автор на известния дневник от времето на Холокоста.", 21, new DateTime(1945, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Ан Франк", 20, "person19.jpg", new DateTime(1929, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 20, "Английски натуралист, автор на теорията за еволюцията чрез естествен отбор.", 7, new DateTime(1882, 4, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Чарлз Дарвин", 6, "person20.jpg", new DateTime(1809, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_People_CountryId",
                table: "People",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_People_ProfessionId",
                table: "People",
                column: "ProfessionId");

            migrationBuilder.CreateIndex(
                name: "IX_PeopleCatalogPerson_PeopleId",
                table: "PeopleCatalogPerson",
                column: "PeopleId");

            migrationBuilder.CreateIndex(
                name: "IX_PeopleCatalogs_UserCatalogsId",
                table: "PeopleCatalogs",
                column: "UserCatalogsId");

            migrationBuilder.CreateIndex(
                name: "IX_PeopleCatalogs_UserId",
                table: "PeopleCatalogs",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersCatalogs_UserId",
                table: "UsersCatalogs",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "PeopleCatalogPerson");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "PeopleCatalogs");

            migrationBuilder.DropTable(
                name: "People");

            migrationBuilder.DropTable(
                name: "UsersCatalogs");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "Professions");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
