namespace HotelManagementSystem.Common
{
    public static class EntityValidationMessages
    {
        public static class Reservation
        {
            public const string CheckInDateRequiredMessage = "Check in date is required in format dd/MM/yyyy";
            public const string CheckOutDateRequiredMessage = "Check out date is required in format dd/MM/yyyy";
        }

        public static class Room
        {
            public const string RoomNumberRequiredMessage = "Room number is required.";
            public const string DescriptionRequiredMessage = "Description is required.";
            public const string ImageUrlRequiredMessage = "Image link is required.";
            public const string PricePerNightRequiredMessage = "Nightly price is required.";
            public const string MaxCapacityRequiredMessage = "Room capacity is required.";
        }
    }
}
