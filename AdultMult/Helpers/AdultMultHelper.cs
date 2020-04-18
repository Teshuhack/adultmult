using AdultMult.Models;
using System.Collections.Generic;
using System.Text;

namespace AdultMult.Helpers
{
    public static class AdultMultHelper
    {
        public static string PrintMultsCollection(List<Mult> mults)
        {
            StringBuilder stringBuilder = new StringBuilder();

            foreach (var mult in mults)
            {
                stringBuilder.AppendLine(mult.RussianCaption);
                stringBuilder.AppendLine(mult.Series);
                stringBuilder.AppendLine();
            }

            return stringBuilder.ToString();
        }
    }
}
