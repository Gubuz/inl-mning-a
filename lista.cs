// Skapar två tomma listor: en för varunamn och en för priser
List<string> names = new List<string>();
List<int> prices = new List<int>();

// Programmet fortsätter att köras tills loopen avbryts
while (true)
{
    // Visar alla varor och räknar ut totalsumman
    VisaLista(names, prices);

    Console.WriteLine();
    Console.Write(
        "Skriv ett varunamn för att lägga till, eller ett nummer för att ta bort: "
    );

    // Läser det som användaren skriver
    string? input = Console.ReadLine();
    Console.WriteLine();

    // Avslutar loopen om programmet inte får någon inmatning
    if (input == null)
    {
        break;
    }

    // Kontrollerar om användaren skrev ett nummer
    if (int.TryParse(input, out int nummer))
    {
        // Minus ett behövs eftersom listans första index är 0
        int index = nummer - 1;

        // Kontrollerar att det finns en vara med det valda numret
        if (index >= 0 && index < names.Count)
        {
            Console.WriteLine($"Tog bort {names[index]}.");

            // Tar bort både varans namn och dess pris
            names.RemoveAt(index);
            prices.RemoveAt(index);
        }
        else
        {
            Console.WriteLine("Det finns ingen vara med det numret.");
        }
    }
    else
    {
        // Om inmatningen inte är ett kommando används den som varunamn
        string namn = input;

        Console.Write($"Pris för {namn}: ");
        string? prisInput = Console.ReadLine();

        // Lägger bara till varan om priset är ett heltal
        if (int.TryParse(prisInput, out int pris))
        {
            names.Add(namn);
            prices.Add(pris);
        }
        else
        {
            Console.WriteLine(
                "Priset måste vara ett heltal. Varan lades inte till."
            );
        }
    }
}

// Visar alla varor i listan tillsammans med deras pris och den totala summan
static void VisaLista(List<string> names, List<int> prices)
{
    if (names.Count == 0)
    {
        Console.WriteLine("Listan är tom.");
        return;
    }

    int total = 0;

    for (int i = 0; i < names.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {names[i]} - {prices[i]} kr");
        total += prices[i];
    }

    Console.WriteLine($"Totalt: {total} kr");
}
