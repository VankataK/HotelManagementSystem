namespace HotelManagementSystem.Common
{
    public static class EntityValidationConstants
    {
        public static class Room
        {
            public const int RoomNumberMinLength = 2;
            public const int RoomNumberMaxLength = 100;
            public const int DescriptionMinLength = 20;
            public const int DescriptionMaxLength = 500;
            public const int ImageUrlMinLength = 8;
            public const int ImageUrlMaxLength = 2083;
            public const string PricePerNightMinValue = "0";
            public const string PricePerNightMaxValue = "10000";
            public const int MaxOccupancyMinValue = 1;
            public const int MaxOccupancyMaxValue = 10;
        }

        public static class Category 
        {
            public const int NameMinLength = 2;
            public const int NameMaxLength = 100;
        }

        public static class Reservation
        {
            public const string TotalPriceMinValue = "0";
            public const string TotalPriceMaxValue = "150000";
            public const string ReservationDateFormat = "yyyy-MM-dd";
        }

        public static class Receptionist
        {
            public const int PhoneNumberMinLength = 6;
            public const int PhoneNumberMaxLength = 15;
        }

        public static class User
        {
            public const int FirstNameMinLength = 1;
            public const int FirstNameMaxLength = 100;
            public const int LastNameMinLength = 1;
            public const int LastNameMaxLength = 100;
        }
    }
}
