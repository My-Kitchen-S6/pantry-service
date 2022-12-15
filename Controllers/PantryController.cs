using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using pantry_service.Data;
using pantry_service.DTOs;
using pantry_service.Models;

namespace pantry_service.Controllers
{
    
    [ApiController]
    public class PantryController : ControllerBase
    {
        private readonly IPantryRepo _repository;
        private readonly IMapper _mapper;
        public PantryController(IPantryRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        
        [HttpGet("pantry/all/{userId}", Name = "GetAllIngredients")] 
        public ActionResult<IEnumerable<ReadIngredient>> GetAllIngredients(int userId)
        {
            var ingredientItems = _repository.getAllIngredients(userId);
            var readIngredientItems = _mapper.Map<IEnumerable<ReadIngredient>>(ingredientItems);
            
            foreach (var ingredient in readIngredientItems)
            {
                ingredient.NutritionalValue =
                    _mapper.Map<ReadNutritionalValue>(_repository.GetNutritionalValue(ingredient.Id));
            }

            return Ok(readIngredientItems);
        }
        
        [HttpGet("pantry/{userId}/{ingredientId}", Name = "GetIngredient")]
        public ActionResult<ReadIngredient> GetIngredient(int userId, int ingredientId)
        {
            var userItem = _repository.getIngredient(userId ,ingredientId);
            var nutritionalValue = _repository.GetNutritionalValue(ingredientId);

            var readIngredient = _mapper.Map<ReadIngredient>(userItem);
            readIngredient.NutritionalValue = _mapper.Map<ReadNutritionalValue>(nutritionalValue);

            return Ok(readIngredient);
        }
        
        [HttpPost("pantry/ingredient/create", Name = "CreateIngredient")]
        public ActionResult<ReadIngredient> CreateIngredient(CreateIngredient createIngredient)
        {
            var userItem = _mapper.Map<Ingredient>(createIngredient);
            
            _repository.CreateIngredient(userItem);

            var readIngredient = _mapper.Map<ReadIngredient>(userItem);
            _repository.SaveChanges();

            return Ok(readIngredient);
        } 
        
        [HttpPost("pantry/nutrition/create", Name = "CreateNutrition")]
        public ActionResult<ReadNutritionalValue> CreateNutrition(CreateNutritionalValue createNutritionalValue)
        {
            var userItem = _mapper.Map<NutritionalValue>(createNutritionalValue);
            
            _repository.CreateNutritionalValue(userItem);

            var readNutritionalValue = _mapper.Map<ReadNutritionalValue>(userItem);
            _repository.SaveChanges();
            
            return Ok(readNutritionalValue);
        } 
        
        [HttpGet("pantry/nutrition/{ingredientId}", Name = "GetNutritionalValue")]
        public ActionResult<IEnumerable<ReadNutritionalValue>> GetNutritionalValue(int ingredientId)
        {
            var userItem = _repository.GetNutritionalValue(ingredientId);

            return Ok(_mapper.Map<ReadNutritionalValue>(userItem));
        }
    }
}