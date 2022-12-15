using System.Collections.Generic;
using pantry_service.DTOs;
using pantry_service.Models;

namespace pantry_service.Data
{
    public interface IPantryRepo
    {
        bool SaveChanges();

        //Users
        IEnumerable<User> GetAllUsers();
        void CreateUser(User user);
        bool UserExists(string auth0Id);
        bool ExternalUserExists(int externalUserId);

        User GetUserByExternalId(int externalUserId);
        
        User GetUserByAuth0Id(string auth0Id);
        
        User GetUserById(int id);
        
        //Pantry
        IEnumerable<Ingredient> getAllIngredients(int userId);
        Ingredient getIngredient(int userId, int IngredientId);

        void CreateIngredient(Ingredient ingredient);

        void CreateNutritionalValue(NutritionalValue nutritionalValue);

        NutritionalValue GetNutritionalValue(int nutritionalValueId);
        
        
    }
}