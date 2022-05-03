using AcademyF.Week2.EsercitazioneDesignPattern.Entities;

namespace AcademyF.Week2.EsercitazioneDesignPattern.Chain
{
    public class ProductivityHandler : IHandler
    {
        public int Y { get; }
        public int W { get;  }
        public IHandler NextHandler { get; private set; }

        public ProductivityHandler(int y, int w)
        {
            Y = y;
            W = w;
        }

        public double HandleRequest(Employee employee)
        {
            if (employee.Age < Y && employee.ProductivityRate > W)
                return 300.0;
            else
                return 0;
        }

        public void SetNext(IHandler absenceHandler)
        {
            NextHandler = absenceHandler;
        }
    }
}