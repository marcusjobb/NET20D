# Nästan grafisk meny för consolen

## Klasser som är viktiga för menyn
Här är en lista på klasser som används i menysystemet
En del behöver snyggas upp, en del behöver göras om... men det är en kul projekt i alla fall.

Input och output skapades innan boxarna kom till, så de ska bort
GameObjects är bara för spelet, så det är rätt oviktigt

### Box
Box är en ruta, när man instansierar den så anger man x,y, höjd och bredd för den.
Varje box ska helst ha ett unikt namn

Den har egenskapen **Choosable** som bestämmer om klassen Display ska kunna välja den för menyvisning.

**Print** egenskapen lägger in text inne i textrutan, anger man en key kommer den textraden att kunna användas som meny.

**Visible** Boxar kan döljas med den här bool variabeln

**ShowBox** ritar upp boxen (eller refreshar om något ändrats)

**MoveUp** flyttar menyns markör upp

**MoveDown** flyttar menyns markör ner

### Lines
All text i boxarna sparas i lines.
Varje Line kan ha sin egen färg (ej implementerad än)
Varje line har också text och keyword ifall det behövs för menyn
Texten kan centreras

GetString returnerar en sträng med kanter och mellanslag som passar in i menyn, om Width för linjen matchar boxens bredd.

### Display
Denna är huvuddelen i menysystemet
Den har en Lista med boxes och den har enkla funktioner för att hitta boxar enligt deras namn, eller hitta den box som är aktiv just nu.

**Info** tar emot en text eller en array med strängar som skickas in till den boxen man angett, den rensar all text i boxen innan den skickar in den nya texten

**InfoAdd** fyller på boxen utan att rensa tidigare text

**NextBox** letar upp nästa tillgängliga box i listan (behöver skrivas om!) och sätter den som aktiv.

**NewBox** Statisk metod som skapar en ny box

**GetBox** Hämtar en specifik box enligt namn

**ShowBoxes** ritar ut alla boxar

**ActiveBox** Hämtar den aktiva boxen

# Demokod
```csharp
// Instansiera display
Stats.Display = new Display();

// Skapa boxar
Stats.Display.Boxes.Add(Display.NewBox(0, 0, 79, 21, "InfoBox"));
Stats.Display.Boxes.Add(Display.NewBox(85, 0, 30, 5, "Left1"));
Stats.Display.Boxes.Add(Display.NewBox(85, 7, 30, 10, "Left2"));
Stats.Display.Boxes.Add(Display.NewBox(0, 23, 115, 3, "BottomMenu"));
Stats.Display.Boxes.Add(Display.NewBox(12, 5, 57, 10, "Popup"));

// Sätt standardvärden för boxar
Stats.Display.GetBox("InfoBox").NotChoosable = true;
Stats.Display.GetBox("Popup").Visible = false;
Stats.Display.GetBox("BottomMenu").NotChoosable = true;
Stats.Display.GetBox("Left1").IsActive = true;

Stats.Display.ShowBoxes();

var key = ConsoleKey.D1; // meninglöst värden för att key inte gick att sätta till null

// Enkel menysystem
Box box = null ;
do
{
	box = Stats.Display.ActiveBox();
	key = GetKey();
	if (key == ConsoleKey.UpArrow) box.MoveUp();
	if (key == ConsoleKey.DownArrow) box.MoveDown();
	if (key == ConsoleKey.Tab) Stats.Display.NextBox();
} while (key != ConsoleKey.Enter && key != ConsoleKey.Escape);
```
och GetKey metoden
```csharp
public static ConsoleKey GetKey(ConsoleKey[] allowed = null)
{
    // Sätter defaultvärde för vilka tangenter som är acceptable som svar
	if (allowed == allowed || allowed.Length == 0)
    {
        allowed = new ConsoleKey[]{
        	ConsoleKey.UpArrow,  // Pil upp
			ConsoleKey.DownArrow, // Pil ner
			ConsoleKey.Enter, // Enter
            ConsoleKey.Escape, // Escape
			ConsoleKey.Spacebar, // Space
			ConsoleKey.Tab  // Tab
		};
    }

	// Evig loop
    while (true)
    {
		// Har det tryckts någon tangent?
        if (Console.KeyAvailable)
        {
            var k = Console.ReadKey(true).Key;
            // Om tangenten är godkänd, returnera värdet
			if (Array.IndexOf(allowed, k) >= 0) return k;
        }
    }
}
```