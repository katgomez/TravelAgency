namespace ApplicationServices.Models.Fares
{
    using System;

    public enum FareType
    {
        ECONOMY,
        FIRST_CLASS,
        BUSINESS
    }

    public static class FareTypeExtensions
    {
        public static string GetDescription(this FareType fareType)
        {
            return fareType switch
            {
                FareType.ECONOMY => "The most basic fare option available",
                FareType.FIRST_CLASS => "The most luxurious and exclusive option available",
                FareType.BUSINESS => "Offers larger and more comfortable seats, with more legroom and recline options",
                _ => throw new ArgumentException("Invalid fare type"),
            };
        }

        public static double PriceWithFare(this FareType fareType, double price)
        {
            return fareType switch
            {
                FareType.ECONOMY => Math.Round((price + (price * 0.5)), 2),
                FareType.FIRST_CLASS => Math.Round((price + (price * 0.10)), 2),
                FareType.BUSINESS => Math.Round((price + (price * 0.20)), 2),
                _ => throw new ArgumentException("Invalid fare type"),
            };
        }
    }

}
