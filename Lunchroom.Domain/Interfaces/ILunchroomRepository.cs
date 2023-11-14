using Lunchroom.Domain.Entities;

namespace Lunchroom.Domain.Interfaces;

public interface ILunchroomRepository
{
    Task CreateMeal(Meal lunchroom);
    Task<IEnumerable<Meal>> GetAllMeals();
    Task<Meal?> GetMealByName(string name);

    Task<Meal> GetMealByEncodedName(string encodedName);

    //TODO: remove if not used
    //Task<Meal> Edit(Meal lunchroom, string encodedName);
    Task Commit();
}