using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyF.Week2.Demo.Linq
{
    public static class QueryLinq
    {
        #region
        static List<Valutazione> valutazioni = new List<Valutazione>()
        {
            new Valutazione
            {
                NomeStudente = "Mirko",
                DataValutazione = new DateTime(2022, 5, 5),
                Materia = Materia.Italiano,
                Voto = 7
            },
            new Valutazione
            {
                NomeStudente = "Giorgio",
                DataValutazione = new DateTime(2022, 4, 29),
                Materia = Materia.Storia,
                Voto = 8
            },
            new Valutazione
            {
                NomeStudente = "Mirko",
                DataValutazione = new DateTime(2022, 4, 23),
                Materia = Materia.Matematica,
                Voto = 5
            },
            new Valutazione
            {
                NomeStudente = "Antonia",
                DataValutazione = new DateTime(2022, 5, 2),
                Materia = Materia.Geografia,
                Voto = 10
            },
            new Valutazione
            {
                NomeStudente = "Luigi",
                DataValutazione = new DateTime(2022, 4, 27),
                Materia = Materia.Italiano,
                Voto = 4
            },
            new Valutazione
            {
                NomeStudente = "Antonia",
                DataValutazione = new DateTime(2022, 5, 5),
                Materia = Materia.Italiano,
                Voto = 4
            }

        };
        #endregion

        public static void EsecuzioneQuery()
        {
            Console.WriteLine("======== LINQ APPLICATO AGLI OGGETTI ====");

            //TUTTE LE VALUTAZIONI DI MIRKO

            //SENZA LINQ
            List<Valutazione> valutazioneNoLinq = new List<Valutazione>();
            foreach(Valutazione valutazione in valutazioni)
            {
                if(valutazione.NomeStudente == "Mirko")
                {
                    valutazioneNoLinq.Add(valutazione);
                    Console.WriteLine(valutazione);
                }
            }

            //CON LINQ
            // - con query expression
            IEnumerable<Valutazione> valutazioniMirkoLinqQuery =
                from v in valutazioni
                where v.NomeStudente == "Mirko"
                select v;

            StampaLista<Valutazione>(valutazioniMirkoLinqQuery);

            // - con metodi Linq e delegati
            IEnumerable<Valutazione> valutazioniMirkoLinqDelegate = valutazioni.Where(ValutazioniMirko);
            StampaLista<Valutazione>(valutazioniMirkoLinqDelegate);

            // - con Lambda Expression
            IEnumerable<Valutazione> valutazioniMirkoLinqLE = valutazioni.Where(v => v.NomeStudente == "Mirko");
            StampaLista<Valutazione>(valutazioniMirkoLinqLE);

            Console.Clear();

            //Selezioniamo tutte le valutazioni di italiano ordinate per data e per nome studente
            // - con query expression
            IEnumerable<Valutazione> votiItalianoQExp =
                from vot in valutazioni
                where vot.Materia == Materia.Italiano
                orderby vot.DataValutazione, vot.NomeStudente descending
                select vot;

            // - con lambda expression
            IEnumerable<Valutazione> votiItalianoLExp = valutazioni
                                                .Where(valutaz => valutaz.Materia == Materia.Italiano)
                                                .OrderBy(val => val.DataValutazione)
                                                .ThenByDescending(valut => valut.NomeStudente);

            StampaLista<Valutazione>(votiItalianoQExp);
            StampaLista<Valutazione>(votiItalianoLExp);
            Console.Clear();

            //Selezionare nomi e voti degli studenti che hanno una valutazione insufficiente
            // - con query expression
            var votiInsufficientiQExp = 
                from voto in valutazioni
                where voto.Voto < 6
                select new { NomeStudente = voto.NomeStudente, Voto = voto.Voto, Data = voto.DataValutazione }; 

            //In SQL sarebbe
            //SELECT v.Nome as NomeStudente, v.Voto as Voto , v.DataValutazione as Data
            //FROM Valutazione v
            //WHERE v.Voto < 6

            foreach(var item in votiInsufficientiQExp)
            {
                Console.WriteLine($"{item.NomeStudente} - {item.Data.ToShortDateString()} - {item.Voto}");
            }

            // - con lambda expression
            var votiInsufficientiLExp = valutazioni.Where(v => v.Voto < 6)
                                                    .Select(v => new
                                                    {
                                                        NomeStudente = v.NomeStudente,
                                                        Voto = v.Voto,
                                                        Data = v.DataValutazione
                                                    });

            foreach (var item in votiInsufficientiLExp)
            {
                Console.WriteLine($"{item.NomeStudente} - {item.Data.ToShortDateString()} - {item.Voto}");
            }

            Console.Clear();

            //Recuperare per ciasuno studente la sua media e visualizzarla
            // - con query expression
            var mediaVotiPerStudenteQExp =
                from voto in valutazioni
                group voto by voto.NomeStudente into grp
                select new
                {
                    NomeStudente = grp.Key, //chiave di raggruppamento
                    MediaVoti = grp.Average(v => v.Voto)
                };

            var mediaVotiPerStudenteLExp = valutazioni.GroupBy(v => v.NomeStudente,
                (key, grp) => new
                {
                    NomeStudente = key,
                    MediaStudente = grp.Average(v => v.Voto)
                });

            foreach (var item in mediaVotiPerStudenteQExp)
            {
                Console.WriteLine($"Nome studente: {item.NomeStudente} - Media {item.MediaVoti}");
            }

            foreach (var item in mediaVotiPerStudenteLExp)
            {
                Console.WriteLine($"Nome studente: {item.NomeStudente} - Media {item.MediaStudente}");
            }
        }

        public static bool ValutazioniMirko(Valutazione v)
        {
            return v.NomeStudente == "Mirko";
        }

        public static void StampaLista<T>(IEnumerable<T> lista) //where T : class
        {
            foreach (var item in lista)
            {
                Console.WriteLine(item);
            }
        }

    }
}
