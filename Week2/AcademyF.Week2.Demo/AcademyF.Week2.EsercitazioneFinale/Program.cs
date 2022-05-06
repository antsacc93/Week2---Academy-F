using AcademyF.Week2.EsercitazioneFinale;
using AcademyF.Week2.EsercitazioneFinale.Entities;
using System;
using System.Collections.Generic;

IEnumerable<Expense> spese = Expense.GetExpenses("spese");

//SENZA EVENTO
//HandleFile handler = new HandleFile();
//Console.WriteLine("Premi q per stampare i dati su file");
//while (Console.Read() != 'q') ;
//handler.HandleNewFile(spese);


//CON EVENTO
Publisher publisher = new Publisher();
HandleFile handler = new HandleFile();
handler.Subscribe(publisher);
Console.WriteLine("Premi q per lanciare l'evento di scrittura del file");
while (Console.Read() != 'q') ;

publisher.Publish(spese);