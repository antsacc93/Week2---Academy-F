using AcademyF.Week2.EsercitazioneDesignPattern.Entities;

namespace AcademyF.Week2.EsercitazioneDesignPattern.Chain
{
    public interface IHandler
    {
        double HandleRequest(Employee employee);
        void SetNext(IHandler absenceHandler);
    }
}