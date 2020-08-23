using System;

namespace AdultMult.Models
{
    public class Mult
    {
        public int Id { get; set; }

        public string RussianCaption { get; set; }

        public string Series { get; set; }

        public DateTime UpdateDate { get; set; }

        public bool IsUpdated { get; set; }
    }
}
