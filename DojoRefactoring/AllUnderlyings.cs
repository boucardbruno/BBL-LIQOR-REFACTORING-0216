using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace DojoRefactoring
{
    public class AllUnderlyings
    {
        // Introduce Instance Delegator
        public virtual IEnumerable<string> GetProducts()
        {
            return GetAll();
        }
        public static IEnumerable<string> GetAll()
        {
            Thread.Sleep(5000); //Les accès à la base de données sont super lents     
            return new[] { "Cacao", "Sucre", "Petrole", "Carcasses de porc", "Or", "Cuivre" }.Where(p => p.StartsWith("C"));
        }
    }
}
