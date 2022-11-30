using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using pantry_service.Data;
using pantry_service.DTOs;
using pantry_service.Models;

namespace pantry_service.Controllers
{
    public class UsersController : ControllerBase
    {
        private readonly IPantryRepo _repository;
        private readonly IMapper _mapper;

        public UsersController(IPantryRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("users/all", Name = "GetAllUsers")]
        public ActionResult<IEnumerable<ReadUser>> GetUsers()
        {
            var userItems = _repository.GetAllUsers();

            return Ok(_mapper.Map<IEnumerable<ReadUser>>(userItems));
        }


    }
}