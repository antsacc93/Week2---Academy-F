using AcademyF.Week2.EsercitazioneDesignPattern.Entities;
using System;

namespace AcademyF.Week2.EsercitazioneDesignPattern.Factory
{
    public class FactoryCompany
    {
        public ICompany CreateCompany(int numeroDipendenti)
        {
            ICompany company = null;
            if (numeroDipendenti > 0 && numeroDipendenti < 20)
                return new SmallCompany();
            else if (numeroDipendenti > 20 && numeroDipendenti < 100)
                return new MediumCompany();
            return company;
        }
    }
}