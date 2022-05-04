using AcademyF.Week2.EsercitazioneMessagistica;
using AcademyF.Week2.EsercitazioneMessagistica.Publishers;

IPublisher email = new PublisherEmail("Gmail", "Email");

Subscriber utente = new Subscriber("Smartphone di Antonia");

utente.Subscribe(email);

email.Publish("abc@gmail.com");