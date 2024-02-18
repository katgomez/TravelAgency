namespace ApplicationServices.Models.Fares
{
    using System;
    using System.Collections.Generic;

    public class FareResultDto
    {
        public int NumberResults { get; set; }
        public List<FareDto> Fares { get; set; }

        public FareResultDto()
        {
            Fares = new List<FareDto>();

            foreach (FareType fareType in Enum.GetValues(typeof(FareType)))
            {
                FareDto dto = new FareDto
                {
                    Name = fareType.ToString(),
                    Description = fareType.GetDescription()
                };
                Fares.Add(dto);
            }
            NumberResults = Enum.GetValues(typeof(FareType)).Length;
        }
    }

}
