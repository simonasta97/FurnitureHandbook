namespace FurnitureHandbook.Common
{
    public static class GlobalConstants
    {
        public const string SystemName = "FurnitureHandbook";

        public const string AdministratorRoleName = "Administrator";

        public const string Message = "Message";

        public const int MinNameLength = 3;
        public const int MaxNameLength = 30;

        public const int MinDescriptionLength = 10;
        public const int MaxDescriptionLength = 500;

        public class Project
        {
            public const int MinTitleLength = 5;
            public const int MaxTitleLength = 30;

            public const string StartBeforeEndDate = "Началната дата на проекта трябва да бъде преди крайната дата!";
            public const string ClientNotExist = "Клиента не съществува!";
            public const string ProjectAdded = "Проекта е създаден успешно!";
            public const string ProjectNotFound = "Проекта не може да бъде намерен.";
        }

        public class Furniture
        {
            public const int MinColorLength = 3;
            public const int MaxColorLength = 15;

            public const string FurnitureNotFound = "Мебелта не съществува!";
            public const string FurnitureAdded = "Успешно добавихте нова мебел към вашия проект!";
        }

        public class Client
        {
            public const int MaxFullNameLength = 50;

            public const int MinPhoneNumberLength = 10;
            public const int MaxPhoneNumberLength = 25;

            public const int MinAddressLength = 10;
            public const int MaxAddressLength = 200;

            public const string ClientAlreadyExist = "Клиента вече съществува!";
            public const string ClientAdded = "Клиента e добавен успешно!";
        }

        public class Document
        {
            public const int MinNameLength = 3;
            public const int MaxNameLength = 100;
            public const int MinSizeLength = 1;
            public const int MaxSizeLength = int.MaxValue;
            public const string DocumentAlreadyExist = "Вече съществува такъв документ!";
            public const string DocumentNotFound = "Документа не е намерен!";
            public const string DocumentAdded = "Документа е добавен успешно!";
        }

        public class Edgeband
        {
            public const string EdgebandAlreadyExist = "Канта вече съществува!";
        }

        public class Texture
        {
            public const string TextureAlreadyExist = "Материала вече същестува!";
        }
    }
}
