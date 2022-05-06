using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyF.Week2.EsercitazioneFinale.Factory
{
    public class CategoryFactory
    {
        public ICategory GetCategory(string value)
        {
            ICategory category = null;
            switch (value)
            {
                case "Viaggio":
                    category = new Travel();
                    break;
                case "Vitto":
                    category = new Food();
                    break;
                case "Alloggio":
                    category = new Accomodation();
                    break;
                case "Altro":
                    category = new Other();
                    break;
                default:
                    break;
            }
            return category;
        }

    }
}
