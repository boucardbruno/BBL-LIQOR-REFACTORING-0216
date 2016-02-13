using System.Collections.Generic;

namespace DojoRefactoring
{
    public class Perimeter
    {
        public static IEnumerable<string> GetPerimeter(AllUnderlyings allUnderlyings)
        {
            return allUnderlyings.GetProducts();
        }
        public static IEnumerable<string> GetPerimeter()
        {
            return AllUnderlyings.GetAll();
        }        
    }
}
