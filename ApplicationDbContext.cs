using Biographic.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace Biographic
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Country> Countries { get; set; } = default!;
        public DbSet<Profession> Professions { get; set; } = default!;
        public DbSet<Person> People { get; set; } = default!;
        public DbSet<PeopleCatalog> PeopleCatalogs { get; set; } = default!;
        public DbSet<UserCatalogs> UsersCatalogs { get; set; } = default!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Country>().HasData(
                new Country { Id = 1, Name = "Австралия" },
                new Country { Id = 2, Name = "Австрия" },
                new Country { Id = 3, Name = "Англия" },
                new Country { Id = 4, Name = "Аржентина" },
                new Country { Id = 5, Name = "Белгия" },
                new Country { Id = 6, Name = "Бразилия" },
                new Country { Id = 7, Name = "България" },
                new Country { Id = 8, Name = "Германия" },
                new Country { Id = 9, Name = "Гърция" },
                new Country { Id = 10, Name = "Дания" },
                new Country { Id = 11, Name = "Египет" },
                new Country { Id = 12, Name = "Испания" },
                new Country { Id = 13, Name = "Италия" },
                new Country { Id = 14, Name = "Индия" },
                new Country { Id = 15, Name = "Иран" },
                new Country { Id = 16, Name = "Ирландия" },
                new Country { Id = 17, Name = "Исландия" },
                new Country { Id = 18, Name = "Канада" },
                new Country { Id = 19, Name = "Китай" },
                new Country { Id = 20, Name = "Мексико" },
                new Country { Id = 21, Name = "Нидерландия" },
                new Country { Id = 22, Name = "Норвегия" },
                new Country { Id = 23, Name = "Полша" },
                new Country { Id = 24, Name = "Португалия" },
                new Country { Id = 25, Name = "Русия" },
                new Country { Id = 26, Name = "Румъния" },
                new Country { Id = 27, Name = "Саудитска Арабия" },
                new Country { Id = 28, Name = "САЩ" },
                new Country { Id = 29, Name = "Сърбия" },
                new Country { Id = 30, Name = "Турция" },
                new Country { Id = 31, Name = "Украйна" },
                new Country { Id = 32, Name = "Унгария" },
                new Country { Id = 33, Name = "Финландия" },
                new Country { Id = 34, Name = "Франция" },
                new Country { Id = 35, Name = "Чехия" },
                new Country { Id = 36, Name = "Чили" },
                new Country { Id = 37, Name = "Швейцария" },
                new Country { Id = 38, Name = "Швеция" },
                new Country { Id = 39, Name = "Южна Африка" },
                new Country { Id = 40, Name = "Япония" },
                new Country { Id = 41, Name = "Ямайка" }
            );

            modelBuilder.Entity<Profession>().HasData(
                new Profession { Id = 1, Name = "Авиатор" },
                new Profession { Id = 2, Name = "Актьор" },
                new Profession { Id = 3, Name = "Архитект" },
                new Profession { Id = 4, Name = "Астронавт" },
                new Profession { Id = 5, Name = "Астроном" },
                new Profession { Id = 6, Name = "Биолог" },
                new Profession { Id = 7, Name = "Военачалник" },
                new Profession { Id = 8, Name = "Готвач" },
                new Profession { Id = 9, Name = "Диригент" },
                new Profession { Id = 10, Name = "Дизайнер" },
                new Profession { Id = 11, Name = "Дипломат" },
                new Profession { Id = 12, Name = "Драматург" },
                new Profession { Id = 13, Name = "Журналист" },
                new Profession { Id = 14, Name = "Изобретател" },
                new Profession { Id = 15, Name = "Инженер" },
                new Profession { Id = 16, Name = "Композитор" },
                new Profession { Id = 17, Name = "Математик" },
                new Profession { Id = 18, Name = "Монарх" },
                new Profession { Id = 19, Name = "Музикант" },
                new Profession { Id = 20, Name = "Писател" },
                new Profession { Id = 21, Name = "Политик" },
                new Profession { Id = 22, Name = "Поет" },
                new Profession { Id = 23, Name = "Преводач" },
                new Profession { Id = 24, Name = "Преподавател" },
                new Profession { Id = 25, Name = "Програмист" },
                new Profession { Id = 26, Name = "Психолог" },
                new Profession { Id = 27, Name = "Режисьор" },
                new Profession { Id = 28, Name = "Скулптор" },
                new Profession { Id = 29, Name = "Спортист" },
                new Profession { Id = 30, Name = "Теоретик" },
                new Profession { Id = 31, Name = "Учен" },
                new Profession { Id = 32, Name = "Фармацевт" },
                new Profession { Id = 33, Name = "Физик" },
                new Profession { Id = 34, Name = "Философ" },
                new Profession { Id = 35, Name = "Фотограф" },
                new Profession { Id = 36, Name = "Химик" },
                new Profession { Id = 37, Name = "Художник" },
                new Profession { Id = 38, Name = "Шахматист" },
                new Profession { Id = 39, Name = "Експлоратор" },
                new Profession { Id = 40, Name = "Икономист" }
            );

            modelBuilder.Entity<Person>().HasData(
                new Person
                {
                    Id = 1,
                    Name = "Алберт Айнщайн",
                    ProfileImage = "person1.jpg",
                    CountryId = 37,
                    ProfessionId = 33,
                    Biography = "Теоретичен физик, известен с разработването на теорията на относителността. Носител на Нобелова награда за физика през 1921 година.",
                    StartDate = new DateTime(1879, 3, 14),
                    IsDead = true,
                    EndDate = new DateTime(1955, 4, 18)
                },
                new Person
                {
                    Id = 2,
                    Name = "Леонардо да Винчи",
                    ProfileImage = "person2.jpg",
                    CountryId = 13,
                    ProfessionId = 37,
                    Biography = "Италиански ренесансов художник, изобретател и учен. Автор на Мона Лиза и Тайната вечеря.",
                    StartDate = new DateTime(1452, 4, 15),
                    IsDead = true,
                    EndDate = new DateTime(1519, 5, 2)
                },
                new Person
                {
                    Id = 3,
                    Name = "Мария Кюри",
                    ProfileImage = "person3.jpg",
                    CountryId = 24,
                    ProfessionId = 36,
                    Biography = "Пионер в радиологията, носител на две Нобелови награди - за физика и химия.",
                    StartDate = new DateTime(1867, 11, 7),
                    IsDead = true,
                    EndDate = new DateTime(1934, 7, 4)
                },
                new Person
                {
                    Id = 4,
                    Name = "Усейн Болт",
                    ProfileImage = "person4.jpg",
                    CountryId = 41,
                    ProfessionId = 29,
                    Biography = "Ямайски състезател по лека атлетика, световен рекордьор в бягането на 100 и 200 метра.",
                    StartDate = new DateTime(1986, 8, 21),
                    IsDead = false,
                    EndDate = null
                },
                new Person
                {
                    Id = 5,
                    Name = "Фьодор Достоевски",
                    ProfileImage = "person5.jpg",
                    CountryId = 25,
                    ProfessionId = 20,
                    Biography = "Руски писател, автор на 'Престъпление и наказание' и 'Братя Карамазови'.",
                    StartDate = new DateTime(1821, 11, 11),
                    IsDead = true,
                    EndDate = new DateTime(1881, 2, 9)
                },
                new Person
                {
                    Id = 6,
                    Name = "Нелсън Мандела",
                    ProfileImage = "person6.jpg",
                    CountryId = 39,
                    ProfessionId = 21,
                    Biography = "Южноафрикански политик и борец срещу апартейда, президент на ЮАР (1994-1999).",
                    StartDate = new DateTime(1918, 7, 18),
                    IsDead = true,
                    EndDate = new DateTime(2013, 12, 5)
                },
                new Person
                {
                    Id = 7,
                    Name = "Волфганг Амадеус Моцарт",
                    ProfileImage = "person7.jpg",
                    CountryId = 2,
                    ProfessionId = 16,
                    Biography = "Австрийски композитор, един от най-влиятелните в класическата музика.",
                    StartDate = new DateTime(1756, 1, 27),
                    IsDead = true,
                    EndDate = new DateTime(1791, 12, 5)
                },
                new Person
                {
                    Id = 8,
                    Name = "Микеланджело Буонароти",
                    ProfileImage = "person8.jpg",
                    CountryId = 13,
                    ProfessionId = 28,
                    Biography = "Италиански скулптор, художник и архитект от епохата на Ренесанса.",
                    StartDate = new DateTime(1475, 3, 6),
                    IsDead = true,
                    EndDate = new DateTime(1564, 2, 18)
                },
                new Person
                {
                    Id = 9,
                    Name = "Махатма Ганди",
                    ProfileImage = "person9.jpg",
                    CountryId = 14,
                    ProfessionId = 21,
                    Biography = "Индийски политик и духовен лидер, водач на движението за независимост на Индия.",
                    StartDate = new DateTime(1869, 10, 2),
                    IsDead = true,
                    EndDate = new DateTime(1948, 1, 30)
                },
                new Person
                {
                    Id = 10,
                    Name = "Клеопатра",
                    ProfileImage = "person10.jpg",
                    CountryId = 11,
                    ProfessionId = 18,
                    Biography = "Последна царица на Древен Египет, известна с интелигентността и политическите си умения.",
                    StartDate = new DateTime(30, 1, 1),
                    IsDead = true,
                    EndDate = new DateTime(69, 8, 12)
                },
                new Person
                {
                    Id = 11,
                    Name = "Пабло Пикасо",
                    ProfileImage = "person11.jpg",
                    CountryId = 12,
                    ProfessionId = 37,
                    Biography = "Испански художник, създател на кубизма, един от най-влиятелните художници на 20 век.",
                    StartDate = new DateTime(1881, 10, 25),
                    IsDead = true,
                    EndDate = new DateTime(1973, 4, 8)
                },
                new Person
                {
                    Id = 12,
                    Name = "Чингиз Хан",
                    ProfileImage = "person12.jpg",
                    CountryId = 28,
                    ProfessionId = 7,
                    Biography = "Основател на Монголската империя, един от най-успешните военачалници в историята.",
                    StartDate = new DateTime(1162, 1, 1),
                    IsDead = true,
                    EndDate = new DateTime(1227, 8, 18)
                },
                new Person
                {
                    Id = 13,
                    Name = "Мария Тереза",
                    ProfileImage = "person13.jpg",
                    CountryId = 2,
                    ProfessionId = 18,
                    Biography = "Владетелка на Хабсбургската монархия, една от най-влиятелните жени в европейската история.",
                    StartDate = new DateTime(1717, 5, 13),
                    IsDead = true,
                    EndDate = new DateTime(1780, 11, 29)
                },
                new Person
                {
                    Id = 14,
                    Name = "Стив Джобс",
                    ProfileImage = "person14.jpg",
                    CountryId = 28,
                    ProfessionId = 25,
                    Biography = "Съосновател на Apple Inc., пионер в компютърната индустрия.",
                    StartDate = new DateTime(1955, 2, 24),
                    IsDead = true,
                    EndDate = new DateTime(2011, 10, 5)
                },
                new Person
                {
                    Id = 15,
                    Name = "Йоханес Кеплер",
                    ProfileImage = "person15.jpg",
                    CountryId = 8,
                    ProfessionId = 5,
                    Biography = "Немски астроном, известен с формулирането на законите за движение на планетите.",
                    StartDate = new DateTime(1571, 12, 27),
                    IsDead = true,
                    EndDate = new DateTime(1630, 11, 15)
                },
                new Person
                {
                    Id = 16,
                    Name = "Коко Шанел",
                    ProfileImage = "person16.jpg",
                    CountryId = 34,
                    ProfessionId = 10,
                    Biography = "Френска модна дизайнерка, основателка на модната къща Chanel.",
                    StartDate = new DateTime(1883, 8, 19),
                    IsDead = true,
                    EndDate = new DateTime(1971, 1, 10)
                },
                new Person
                {
                    Id = 17,
                    Name = "Лудвиг ван Бетховен",
                    ProfileImage = "person17.jpg",
                    CountryId = 5,
                    ProfessionId = 16,
                    Biography = "Немски композитор, един от най-великите в историята на класическата музика.",
                    StartDate = new DateTime(1770, 12, 17),
                    IsDead = true,
                    EndDate = new DateTime(1827, 3, 26)
                },
                new Person
                {
                    Id = 18,
                    Name = "Галилео Галилей",
                    ProfileImage = "person18.jpg",
                    CountryId = 13,
                    ProfessionId = 31,
                    Biography = "Италиански астроном и физик, наричан 'бащата на модерната наука'.",
                    StartDate = new DateTime(1564, 2, 15),
                    IsDead = true,
                    EndDate = new DateTime(1642, 1, 8)
                },
                new Person
                {
                    Id = 19,
                    Name = "Ан Франк",
                    ProfileImage = "person19.jpg",
                    CountryId = 21,
                    ProfessionId = 20,
                    Biography = "Еврейско момиче, автор на известния дневник от времето на Холокоста.",
                    StartDate = new DateTime(1929, 6, 12),
                    IsDead = true,
                    EndDate = new DateTime(1945, 3, 1)
                },
                new Person
                {
                    Id = 20,
                    Name = "Чарлз Дарвин",
                    ProfileImage = "person20.jpg",
                    CountryId = 7,
                    ProfessionId = 6,
                    Biography = "Английски натуралист, автор на теорията за еволюцията чрез естествен отбор.",
                    StartDate = new DateTime(1809, 2, 12),
                    IsDead = true,
                    EndDate = new DateTime(1882, 4, 19)
                }
            );
        }
    }
}
