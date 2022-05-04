//Publishers

using AcademyF.Week2.Demo.Eventi.Pub_Sub;

Publisher youtube = new Publisher("youtube.com");
Publisher instagram = new Publisher("Instagram");

//Subscribers
Subscriber sub1 = new Subscriber("Antonia");
Subscriber sub2 = new Subscriber("Renata");
Subscriber sub3 = new Subscriber("Mirko");

//Mi iscrivo alla notifica dell'evento pubblicato da uno o più subscriber
sub1.Subscribe(youtube);
sub2.Subscribe(youtube);

sub3.Subscribe(instagram);
sub1.Subscribe(instagram);

youtube.Publish(); //metodo che scatena l'evento

Console.WriteLine("------------");

instagram.Publish();

sub1.UnSubscribe(youtube);

Console.WriteLine("----------");

youtube.Publish();
