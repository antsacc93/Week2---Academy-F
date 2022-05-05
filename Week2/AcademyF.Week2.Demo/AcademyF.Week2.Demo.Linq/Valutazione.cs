﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyF.Week2.Demo.Linq
{
    public enum Materia
    {
        Italiano,
        Storia,
        Geografia,
        Matematica
    }
    public class Valutazione
    {
        public string NomeStudente { get; set; }

        public DateTime DataValutazione { get; set; }

        public Materia Materia { get; set; }

        public int Voto { get; set; }

        //public override string ToString()
        //{
        //    return $"{NomeStudente} - {DataValutazione.ToLongDateString()} - {Materia} - Voto: {Voto}";
        //}

        public override string ToString() => $"{NomeStudente} - {DataValutazione.ToLongDateString()} - {Materia} - Voto: {Voto}";
        
    }
}
