List<Plant> plants = new List<Plant>()
{
    new Plant { Species = "Mushroom", AskingPrice = 999.99m, LightNeeds = 4, City = "Nashville", ZIP = 37214, Sold = false },
    new Plant { Species = "Basil", AskingPrice = 19.99m, LightNeeds = 2, City = "Not Nashville", ZIP = 37216, Sold = false},
    new Plant { Species = "Thyme", AskingPrice = 799.99m, LightNeeds = 1, City = "Almost Nashville", ZIP = 37215, Sold = false},
    new Plant { Species = "Rosemary", AskingPrice = 49.99m, LightNeeds = 5, City = "Nashville", ZIP = 37214, Sold = false},
    new Plant { Species = "Carrot", AskingPrice = 14.99m, LightNeeds = 3, City = "Nashville", ZIP = 37214, Sold = true}
};

void DisplayMenu()
{
  Console.WriteLine("1. Display All Plants");
  Console.WriteLine("2. Post a plant to be adopted");
  Console.WriteLine("3. Adopt a Plant");
  Console.WriteLine("4. Delist a Plant");
  Console.WriteLine("5. Quit App");
}

void DisplayPlants()
{
  Console.WriteLine("List of plants");
  for(int i = 0; i < plants.Count; i++)
  {
    var plant = plants[i];
    Console.WriteLine($"[{i + 1}] {plant.Species} Which costs ${plant.AskingPrice}");
  }
}
string greeting = @"Lets look at some plants Here's your options bitch:";

void DelistPlant()
{
  DisplayPlants();

  Console.WriteLine("Pick plant to delete");

  string input = Console.ReadLine();
  if (int.TryParse(input, out int index))
  {
     if (index >= 1 && index <= plants.Count)
    {
      plants.RemoveAt(index - 1);
      Console.WriteLine("Plant removed");
    }
    else
    {
      Console.WriteLine("Wrong pick again");
    }
  }
  else
  {
      Console.WriteLine("Wrong pick again");
  }
 
}

void AddPlant()
{
  Console.WriteLine("Enter Plant Species Name:");
  string NewSpecies = Console.ReadLine();

  Console.WriteLine("Enter the city where your plant is from:");
  string NewCity = Console.ReadLine();

  Console.WriteLine("Enter the Zip Code of your plant");
  string zip = Console.ReadLine();
  if(int.TryParse(zip, out int newZIP))
  {
    Console.WriteLine("Enter Plant Price:");
    string PlantPrice = Console.ReadLine();
    if (decimal.TryParse(PlantPrice, out decimal NewPrice))
    {
      Console.WriteLine("Please enter on a scale of (1-5) how much light the plant needs 1 being little 5 being a lot: ");
      string lightRequirement = Console.ReadLine();
      if (int.TryParse(lightRequirement, out int lightNeeded) && lightNeeded >= 1 && lightNeeded <= 5)
      {
          var plant = new Plant {Species = NewSpecies, AskingPrice = NewPrice, City = NewCity, ZIP = newZIP, LightNeeds = lightNeeded, Sold = false};
          plants.Add(plant);
          Console.WriteLine("Added your Plant");
      }
      else 
      {
        Console.WriteLine("Try adding your plant again");
      }
    }
    else
    {
      Console.WriteLine("Try adding your plant again");
    }
  }
  else
  {
    Console.WriteLine("Try adding your plant again");
  }
}

void AvailablePlants()
{
  Console.WriteLine("These are the plants available:");
  for (int i = 0; i < plants.Count; i++)
    {
        if (!plants[i].Sold)
        {
            Console.WriteLine($"{i + 1}. {plants[i].Species}, Price: ${plants[i].AskingPrice}, Location: {plants[i].City}, {plants[i].ZIP}, Light Requirement: {plants[i].LightNeeds}/5");
        }
    }
   Console.Write("Enter the index of the plant you want to purchase: ");
   string PlantChoice = Console.ReadLine();
    if (int.TryParse(PlantChoice, out int selectedIndex) && selectedIndex >= 1 && selectedIndex <= plants.Count)
    {
        // Mark the selected plant as sold (set Sold to true)
        plants[selectedIndex - 1].Sold = true;
        Console.WriteLine($"You have purchased the {plants[selectedIndex - 1].Species} plant. Thank you for your purchase!");
    }
    else
    {
        Console.WriteLine("Invalid input. Please enter a valid index.");
    }
}

void MainProgram()
{
  Console.WriteLine(greeting);
  int choice;
  do
  {
    DisplayMenu();
    Console.WriteLine("Enter your choice (1-5)");
    string input = Console.ReadLine();
    
    if (int.TryParse(input, out choice))
    {
      switch (choice)
      {
        case 1:
              DisplayPlants();
            break;
        case 2:
            AddPlant();
            break;
        case 3:
            AvailablePlants();
            break;
        case 4:
            DelistPlant();
            break;
        case 5:
            Console.WriteLine("Exiting App...");
            return;
        default:
          Console.WriteLine("Wrong pick again.");
          break;
      }
    }
    else 
    {
      Console.WriteLine("wrong pick again");
    }
  }
  while (choice != 5);
}
MainProgram();
