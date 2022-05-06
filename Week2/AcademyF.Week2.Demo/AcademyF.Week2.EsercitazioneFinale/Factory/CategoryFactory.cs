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
                case "Travel":
                    category = new Travel();
                    break;
                case "Food":
                    category = new Food();
                    break;
                case "Accomodation":
                    category = new Accomodation();
                    break;
                case "Other":
                    category = new Other();
                    break;
                default:
                    break;
            }

            return category;
        }
    }
}
