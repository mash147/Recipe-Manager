using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe_Manager_2
{
    // Class to represent an ingredient
    class Ingredient
    {
        public string Name { get; }
        public double Quantity { get; }
        public string Unit { get; }

        public Ingredient(string name, double quantity, string unit)
        {
            Name = name;
            Quantity = quantity;
            Unit = unit;
        }
    }

    // Class to represent a recipe
    class Recipe
    {
        private List<Ingredient> Ingredients { get; } = new List<Ingredient>(); // List to store ingredients
        private List<string> Steps { get; } = new List<string>(); // List to store steps

        // Method to add an ingredient to the recipe
        public void AddIngredient(Ingredient ingredient)
        {
            Ingredients.Add(ingredient);
            Console.WriteLine("Ingredient added successfully.");
        }

        // Method to add a step to the recipe
        public void AddStep(string step)
        {
            Steps.Add(step);
            Console.WriteLine("Step added successfully.");
        }

        // Method to display the recipe details
        public void DisplayRecipe()
        {
            Console.WriteLine("\nRecipe Details:");
            Console.WriteLine("Ingredients:");
            foreach (var ingredient in Ingredients)
            {
                Console.WriteLine($"- {ingredient.Quantity} {ingredient.Unit} {ingredient.Name}");
            }

            Console.WriteLine("\nSteps:");
            for (int i = 0; i < Steps.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {Steps[i]}");
            }
        }

        // Method to reset the recipe by clearing the ingredient and step lists
        public void ResetRecipe()
        {
            Ingredients.Clear();
            Steps.Clear();
        }
    }


    class Program
    {
        static void Main()
        {
            // Create a new recipe instance
            Recipe recipe = new Recipe();
            bool running = true;

            while (running)
            {
                // Display menu options
                Console.WriteLine("\nMenu:");
                Console.WriteLine("1. Add Ingredient");
                Console.WriteLine("2. Add Step");
                Console.WriteLine("3. Display Recipe");
                Console.WriteLine("4. Reset Recipe");
                Console.WriteLine("5. Exit");
                Console.Write("Choose an option: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        // Ask user how many ingredients they want to add
                        Console.Write("Enter the number of ingredients: ");
                        int ingredientCount = int.Parse(Console.ReadLine());

                        for (int i = 0; i < ingredientCount; i++)
                        {
                            Console.WriteLine($"Enter details for ingredient {i + 1}:");
                            Console.Write("Enter ingredient name: ");
                            string name = Console.ReadLine();
                            Console.Write("Enter quantity: ");
                            double quantity = double.Parse(Console.ReadLine());
                            Console.Write("Enter unit: ");
                            string unit = Console.ReadLine();

                            // Add ingredient to recipe
                            recipe.AddIngredient(new Ingredient(name, quantity, unit));
                        }
                            break;

                    case "2":
                        // Ask user how many steps they want to add
                        Console.Write("Enter the number of steps: ");
                        int stepCount = int.Parse(Console.ReadLine());

                        for (int i = 0; i < stepCount; i++)
                        {
                            // Get step description from user
                            Console.WriteLine($"Enter description for step {i + 1}: ");
                            recipe.AddStep(Console.ReadLine());
                        }
                        break;

                    case "3":
                        // Display the recipe details
                        recipe.DisplayRecipe();
                        break;

                    case "4":
                        // Reset the recipe by clearing ingredients and steps
                        recipe.ResetRecipe();
                        Console.WriteLine("Recipe has been reset.");
                        break;

                    case "5":
                        // Exit the program
                        running = false;
                        Console.WriteLine("Exiting...");
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please select a valid option.");
                        break;
                }
            }
        }
    }
}

