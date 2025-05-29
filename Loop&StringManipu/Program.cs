using System;

class Program
{
    static void Main(string[] args)
    {
        bool loop = true;

        while (loop)
        {
            Console.Clear();
            Console.WriteLine("\n--- Meny ---");
            Console.WriteLine("0. Avsluta");
            Console.WriteLine("1. Ungdom || Pensionär");
            Console.WriteLine("2. Gruppbokning");
            Console.WriteLine("3. Upprepa text 10 gånger");
            Console.WriteLine("4. Tredje ordet i mening");
            Console.Write("Välj ett alternativ: ");

            // Validerar menyval
            bool validInput = int.TryParse(Console.ReadLine(), out int input); // Input för menyval, omvandlar till heltal.
            if (!validInput)
            {
                Console.WriteLine("Fel: Ange ett giltigt heltal.");
                continue;
            }

            switch (input)
            {
                case 0:
                    Console.WriteLine("Avslutar program");
                    loop = false;
                    break;

                case 1:
                    Console.Write("Din ålder: ");
                    bool validAge = int.TryParse(Console.ReadLine(), out int ageInt);
                    if (!validAge)
                    {
                        Console.WriteLine("Fel: Ange en giltig ålder.");
                        break;
                    }

                    // Priskategorier
                    if (ageInt < 20)
                    {
                        Console.WriteLine("Ungdomspris: 80 kr");
                    }
                    else
                    {
                        if (ageInt > 64)
                        {
                            Console.WriteLine("Pensionärspris: 90 kr");
                        }
                        else
                        {
                            Console.WriteLine("Standardpris: 120 kr");
                        }
                    }
                    Console.WriteLine("Tryck på valfri knapp för att fortsätta");
                    Console.ReadKey();
                    break;

                case 2:
                    Console.Write("Hur många personer? ");
                    bool validPeople = int.TryParse(Console.ReadLine(), out int people); // Input för antal personer    
                    if (!validPeople || people <= 0) // Kontrollerar om input är ett giltigt heltal och större än 0. !ValidPeople kontrollerar om det inte är giltigt.
                    {
                        Console.WriteLine("Fel: Ange ett giltigt antal personer.");
                        Console.WriteLine("Tryck på valfri knapp för att fortsätta");
                        Console.ReadKey();
                        break;
                    }

                    int totalPrice = 0;

                    for (int i = 1; i <= people; i++)
                    {
                        Console.Write($"Ålder för person {i}: ");
                        bool validGroupAge = int.TryParse(Console.ReadLine(), out int agePeople);
                        if (!validGroupAge)
                        {
                            Console.WriteLine("Fel: Ogiltig ålder. Försöker igen från början.");
                            totalPrice = 0; // Återställ vid fel
                            break;
                        }

                        if (agePeople < 20)
                        {
                            totalPrice += 80;
                        }
                        else if (agePeople > 64)
                        {
                            totalPrice += 90;
                        }
                        else
                        {
                            totalPrice += 120;
                        }
                    }
                    if (totalPrice > 0) // Skriv endast ut om alla inputs var korrekta
                    {
                        Console.WriteLine($"Totalpris för {people} personer: {totalPrice} kr");
                        Console.WriteLine($"\nMängden människor: {people}");
                    }
                    Console.WriteLine("Tryck på valfri knapp för att fortsätta");
                    Console.ReadKey();
                    break;

                case 3:
                    Console.Write("Skriv text: ");
                    string userInput = Console.ReadLine();

                    Console.WriteLine("Text 10x: ");
                    for (int i = 1; i < 11; i++) // Loop 10 gånger
                    {
                        Console.Write($"{i}.{userInput} "); // Printar texten med numrering
                    }
                    Console.WriteLine(); // Ny rad efter hela loopen
                    Console.WriteLine("Tryck på valfri knapp för att fortsätta");
                    Console.ReadKey();
                    break;

                case 4:
                    Console.Write("Skriv en mening med minst 3 ord: ");
                    var sentence = Console.ReadLine();

                    string[] words = sentence.Split(' '); // Splittar meningen i ord.

                    if (words.Length >= 3)
                    {
                        Console.WriteLine($"Tredje ordet är: {words[2]}"); // Skriver ut det tredje ordet i meningen, index 2 eftersom index börjar på 0.
                    }
                    else
                    {
                        Console.WriteLine("Meningen innehåller inte 3 ord, försök igen.");
                    }
                    Console.WriteLine("Tryck på valfri knapp för att fortsätta");
                    Console.ReadKey();
                    break;

                default:
                    Console.WriteLine("Invalid input");
                    Console.WriteLine("Tryck på valfri knapp för att fortsätta");
                    Console.ReadKey();
                    break;
            }
        }
    }
}
