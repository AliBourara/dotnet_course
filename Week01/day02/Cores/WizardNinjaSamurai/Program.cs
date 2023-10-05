

Wizard Bechir = new Wizard("Jorge",10,20);
Human Aziz = new Human("Aziz",10,10,10,15);
Samourai Ali = new Samourai("Ali",10,10,10);
Ninja Fatma= new Ninja("Fatma",10,10,10);


// System.Console.WriteLine(Ali.Dexterity);
// System.Console.WriteLine(Bechir.Intelligence);
// System.Console.WriteLine(Bechir.Dexterity);

// System.Console.WriteLine($" Health Before {Ali.Health} Ya rasoul elleh");
// Fatma.Attack(Ali);
// System.Console.WriteLine($"{Ali.Health} Yezzitchi mel bleda");

System.Console.WriteLine($"Before{Ali.Health}");
Fatma.Attack(Ali);
System.Console.WriteLine($"After Attak{Ali.Health}");
Ali.Meditate();
System.Console.WriteLine($"After{Ali.Health}");




// System.Console.WriteLine(Bechir.Health);
// System.Console.WriteLine(Aziz.Health);
// Bechir.Attack(Aziz);
// System.Console.WriteLine(Aziz.Health);
// System.Console.WriteLine(Bechir.Health);
// Bechir.Heal(Aziz);

// System.Console.WriteLine($" Final Aziz : {Aziz.Health}");





