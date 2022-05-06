//senza evento

using AcademyF.Week2.EsercitazioneFinale.Entities;

IEnumerable<Expense> spese = Expense.LoadExpenseFromFile("spese");

IEnumerable<Refund> refunds = Refund.GestioneRimborsi(spese);

Refund.SalvaRimborsoSuFile("spese_elaborate", refunds);