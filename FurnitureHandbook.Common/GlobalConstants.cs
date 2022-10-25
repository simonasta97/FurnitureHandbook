namespace FurnitureHandbook.Common
{
    public static class GlobalConstants
    {
        public const string SystemName = "FurnitureHandbook";

        public const string AdministratorRoleName = "Administrator";

        public const int MinNameLength = 3;
        public const int MaxNameLength = 30;

        public const int MinDescriptionLength = 10;
        public const int MaxDescriptionLength = 500;

        public class Project
        {
            public const int MinTitleLength = 5;
            public const int MaxTitleLength = 30;
        }

        public class Furniture
        {
            public const int MinColorLength = 3;
            public const int MaxColorLength = 15;

            public const int MaxNoteLength = 300;
        }

        public class Client
        {
            public const int MaxFullNameLength = 50;

            public const int MinPhoneNumberLength = 10;
            public const int MaxPhoneNumberLength = 25;

            public const int MinAddressLength = 10;
            public const int MaxAddressLength = 200;
        }
    }
}
