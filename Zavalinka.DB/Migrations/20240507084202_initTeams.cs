using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Zavalinka.DB.Migrations
{
    /// <inheritdoc />
    public partial class initTeams : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($@"
INSERT INTO ""Team"" values
    ('61b022a0-2d78-4ea0-94a6-d45db26de0f4','Енотики','Я енотик полоскун','/img/raccon.jpg','[]','2012-04-21 23:25:43.000000 +00:00'),
('22be37a3-8db6-4c49-bf88-dce7c99f46f7','Лисички','Рыжие бесстыжие','/img/fox.jpg','[]','2024-04-21 23:25:43.000000 +00:00'),
('772d53c7-bf55-4ef4-9df3-1bcaf9ab8fcc','Капибары','КА-ПИ-БАРА','/img/capibara.png','[]','2024-04-21 23:25:43.000000 +00:00'),
('b7a65b93-f618-4c74-99c2-1555cb6c0495','Белки','Белки, которые сидят на крыше','/img/belochka.jpg','[]','2024-04-21 23:25:43.000000 +00:00'),
('453ccd9c-afc6-4edb-8db2-1276a655567c','Чихуашки','Собачки маленького размера','/img/chihua.jpg','[]','2024-04-21 23:25:43.000000 +00:00'),
('117f3cf9-7d1c-404d-837c-77c78ac87d4e','Бобры','БОбер КУРВА','/img/beaver.png','[]','2024-04-21 23:25:43.000000 +00:00')
");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
