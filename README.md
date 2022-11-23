# Furniture Handbook App

Наръчник за мебели - FURNITURE HANDBOOK. Неговата цел е да улесни работата на всеки мебелист в проектирането и производството на корпусна мебел.
За мебелната индустрия е изключително важен процеса по изготвянето на най-добрите проекти за клиентите, тяхното безупречно изпълнение и съхваняването на информацията за произведените мебели.

Furniture Handbook е система, разработена изцяло според потребностите на всеки производител на мебели. В приложението се стараем да подпомогнем бизнеса, като предоставяме достъп до мебелната документация-селекция от документи според категорията на произвежданите мебели. 
Основната функционалност е изготвянето на проекти,следене на изпълнението им,съхваняването на информацията за тях, за клиента,за мебелите и всички съпътвстващи ги елементи, необходими за производството.
Така ще се намали използването на записки по тетрадки и хвърчащи листа, които се замърсяват и губят лесно по време на работа.

*Проектът е отворен за развитие и нови идеи.

# Използвани технологии при реализиране на проекта
- Проекта използва ASP.NET Core Template с автори: Nikolay Kostov,
Vladislav Kramfilov и Stoyan Shopov.
- ASP.NET Core 6 – за сървърната част.
- EntityFramework Core 6 – Object Relational Mapper (ORM), който служи за
извличането на данните от базата.
- AutoMapper – за лесно превръщане на един обект от базата към view модел.
- BuildBundlerMinifier – служи да направи файловете по-малки с цел пестене
трафик.
- Style Cop – помага за писането на по-чист и консистентен код.
- HTML, CSS, JavaScript, jQuery, Bootstrap4 и Font Awesome.

# Описание и работа с приложението
- Начална страница(Наръчник за мебели): `/`

- Проекти- Информация за всички проекти: `/Projects/All` (Проектите могат да бъдат филтрирани според статуса им - Активни, Изпълнени или Отказани); Създаване на нов проект: `/Projects/Create` ; Детайли на проекта: `/Projects/ById/:id` ; Промяна на данните по проекта: `/Projects/Edit/:id` ; Изтриване на проекта: `/Projects/Delete/:id`
Всеки изготвен проект съдържа колекция от мебели.
- Мебели- Добавяне на мебел към проекта: `/Furnitures/Create?projectId=:id` Детайли за мебелта: `/Furnitures/ById/15` ; Изтриване на проекта: `/Furnitures/Delete/:id`

- Клиенти- Списък с всички клиенти на фирмата  `/Clients/All` ; Добавяне на нов клиент: `/Clients/Create`

-Мебелна документация- Според категорията на произвежданите мебели потребителя избира каква документация му е необходима: `/Categories/All` ; Показване на всички налични документи(стандарти, примерни проекти, чертежи) за избраната категория: `/Categories/ById/:id`

# Screenshots

### Начална страница
<kbd>![image](https://user-images.githubusercontent.com/103176056/203571417-5b3fe578-6226-4227-9d5a-482ad5b9750f.png)</kbd>
<kbd>![image](https://user-images.githubusercontent.com/103176056/203573419-cde17ed4-827a-4e06-ac97-deef7a06cab2.png)</kbd>


### Проекти

<kbd>![image](https://user-images.githubusercontent.com/103176056/203565045-22574c18-41b7-4d37-8171-337f5c9ddcad.png)</kbd>
<kbd>![image](https://user-images.githubusercontent.com/103176056/203566846-2eeec175-18a2-4395-bb9c-1c2bb14e080e.png)</kbd>
<kbd>![image](https://user-images.githubusercontent.com/103176056/203566489-f32f13d4-ffc1-4f5d-8f75-37b659db8571.png)</kbd>
<kbd>![image](https://user-images.githubusercontent.com/103176056/203567887-5a485f4f-882a-4ebe-8e4f-fea77d77aae7.png)</kbd>
<kbd>![image](https://user-images.githubusercontent.com/103176056/203568060-37918cf8-0747-41ee-96e1-b582ff66722d.png)</kbd>
<kbd>![image](https://user-images.githubusercontent.com/103176056/203568487-b371cdaa-c651-4137-aa9a-2c2e5688707e.png)</kbd>
<kbd>![image](https://user-images.githubusercontent.com/103176056/203568248-5c534957-cfe6-4988-8151-0738a471c217.png)</kbd>

### Мебели
<kbd>![image](https://user-images.githubusercontent.com/103176056/203569317-84f1d7de-9941-48c9-be98-a97d3cb67da0.png)</kbd>
<kbd>![image](https://user-images.githubusercontent.com/103176056/203573837-1bb723c3-deab-4b3d-a7e8-072d87ede151.png)</kbd>
<kbd>![image](https://user-images.githubusercontent.com/103176056/203569008-10168280-3edb-4a6b-89b0-14a0879936c7.png)</kbd>

### Клиенти
<kbd>![image](https://user-images.githubusercontent.com/103176056/203569629-3a42962c-5f8e-456e-8fef-0db7f9eadd24.png)</kbd>
<kbd>![image](https://user-images.githubusercontent.com/103176056/203569831-6dcef9c4-0a17-449f-b22d-ce8b1a8ac9b7.png)</kbd>

### Мебелна документация
<kbd>![image](https://user-images.githubusercontent.com/103176056/203570134-31629ae5-8592-4418-a4fe-30caed9209ae.png)</kbd>
<kbd>![image](https://user-images.githubusercontent.com/103176056/203570397-cb266ec6-4a70-4551-97f4-8d43e8289227.png)</kbd>
<kbd>![image](https://user-images.githubusercontent.com/103176056/203570666-93ebb926-6983-42a2-bf4a-05f8b713936c.png)</kbd>
<kbd>![image](https://user-images.githubusercontent.com/103176056/203570925-ea3fc33c-04e8-405e-b5b6-2ef466c6025c.png)</kbd>


Към момента програмата се изпитва в реална среда от семейния бизнес: Производство на мебели- МЕБЕЛИ МИЛЧЕВИ. 

