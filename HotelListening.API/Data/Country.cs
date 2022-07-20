﻿namespace HotelListening.API.Data
{
    public class Country
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public string? ShortName { get; set; }

        public virtual IList<Hotel>? Hotels { get; set; }

    }
}