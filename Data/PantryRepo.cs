using System.Collections.Generic;
using System.Linq;
using pantry_service.DTOs;
using pantry_service.Models;

namespace pantry_service.Data
{
    public class PantryRepo : IPantryRepo
    {

        private readonly AppDbContext _context;
        public PantryRepo(AppDbContext context)
        {
            _context = context;
        }
        
        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _context.Users.ToList();
        }

        public void CreateUser(User user)
        {
            _context.Users.Add(user);
        }

        public bool UserExists(string auth0Id)
        {
            return _context.Users.Any(p => p.Auth0Id == auth0Id);
        }

        public bool ExternalUserExists(int externalUserId)
        {
            return _context.Users.Any(p => p.ExternalId == externalUserId);
        }

        public User GetUserByExternalId(int externalUserId)
        {
            return _context.Users.FirstOrDefault(i => i.ExternalId == externalUserId);
        }

        public User GetUserByAuth0Id(string auth0Id)
        {
            return _context.Users.FirstOrDefault(i => i.Auth0Id == auth0Id);
        }

        public IEnumerable<Ingredient> getAllIngredients(int userId)
        {
            return _context.Ingredients
                .Where(i => i.UserId == userId)
                .ToList();
        }

        public Ingredient getIngredient(int userId, int ingredientId)
        {
            return _context.Ingredients.FirstOrDefault(i => i.UserId == userId && i.Id == ingredientId);
        }

        public void CreateIngredient(Ingredient ingredient)
        {
            _context.Ingredients.Add(ingredient);
        }
    }
}