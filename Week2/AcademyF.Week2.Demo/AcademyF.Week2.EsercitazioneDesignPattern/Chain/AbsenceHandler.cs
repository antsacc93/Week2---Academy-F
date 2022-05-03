using AcademyF.Week2.EsercitazioneDesignPattern.Entities;

namespace AcademyF.Week2.EsercitazioneDesignPattern.Chain
{
    public class AbsenceHandler : IHandler
    {
        public int Y { get; }
        public int Z { get; }
        public IHandler NextHandler { get; private set; }

        public AbsenceHandler(int y, int z)
        {
            Y = y;
            Z = z;
        }

        public double HandleRequest(Employee employee)
        {
            if(employee.Age < Y && employee.AbsenceRate < Z)
                return 180;
            return NextHandler.HandleRequest(employee);
        }

        public void SetNext(IHandler absenceHandler)
        {
            NextHandler = absenceHandler;
        }
    }
}