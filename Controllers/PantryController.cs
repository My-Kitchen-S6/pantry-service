using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using pantry_service.Data;
using pantry_service.DTOs;
using pantry_service.Models;

namespace pantry_service.Controllers
{
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
        public ActionResult<IEnumerable<ReadIngredient>> GetIngredients(int userId)
        {
            var userItems = _repository.getAllIngredients(userId);

            return Ok(_mapper.Map<IEnumerable<ReadIngredient>>(userItems));
        }
        
        [HttpGet("pantry/{userId}/{ingredientId}", Name = "GetAllIngredients")]
        public ActionResult<IEnumerable<ReadIngredient>> GetIngredient(int userId, int ingredientId)
        {
            var userItem = _repository.getIngredient(userId ,ingredientId);

            return Ok(_mapper.Map<ReadIngredient>(userItem));
        }
        
        [HttpPost("ingredient/create", Name = "CreateIngredient")]
        public ActionResult<ReadIngredient> CreateIngredient(CreateIngredient createIngredient)
        {
            var userItem = _mapper.Map<Ingredient>(createIngredient);
            
            _repository.CreateIngredient(userItem);

            var readIngredient = _mapper.Map<ReadIngredient>(userItem);

            return CreatedAtRoute(nameof(GetIngredient), new {ingredientId = userItem.Id}, readIngredient);

        } 
        
        [HttpPost("nutrition/create", Name = "CreateNutrition")]
        public ActionResult<ReadNutritionalValue> CreateNutrition()
        {
            
        } 
    }
}