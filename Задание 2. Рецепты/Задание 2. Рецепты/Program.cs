public class Autor
{
    public string Username;
    public DateTime DateOfCreation = DateTime.UtcNow;
    public List<Recipe> Recipes;
    public double AverageRating;
   public Autor(string username, DateTime dateOfCreation,  List<Recipe> recipes, double averageRating)
   {
      Username = username;
      DateOfCreation = dateOfCreation;
      Recipes = recipes;
      AverageRating = averageRating;
   }
}

public class Recipe
{
   public string Title;
   public string Description;
   public List<Ingredients> Ingredients;
   public string TheCookingAlgorithm;
   public Autor Username;
   public Category Category;
   public double Rating;

   public Recipe(string title, string description, List<Ingredients> ingredients, string theCookingAlgorithm,
      Autor username, Category category, double rating)
   {
      Title = title;
      Description = description;
      Ingredients = ingredients;
      TheCookingAlgorithm = theCookingAlgorithm;
      Username = username;
      Category = category;
      Rating = rating;
   }
}
public enum Category
{
   Суп,
   Второе,
   Закуски
}
public class Ingredients
{
   public string Name;
   public int Amount;
   public string Unit;

   public Ingredients(string name, int amount, string unit)
   {
      Name = name;
      Amount = amount;
      Unit = unit;
   }
}
