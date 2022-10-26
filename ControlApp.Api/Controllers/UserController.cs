﻿using ControlApp.Application.User.Queries.GetAllUser;
using ControlApp.Application.User.Queries.GetUserByCode;
using Microsoft.AspNetCore.Mvc;


namespace ControlApp.Api.Controllers
{
    [ApiController]
    [Route("api/v1/user")]
    public class UserController : ControllerBase
    {
        private readonly IGetAllUserQuery _getAllUserQuery;
        private readonly IGetUserByCodeQuery _getUserByCodeQuery;

        public UserController(IGetAllUserQuery getAllUserQuery, IGetUserByCodeQuery getUserByCodeQuery)
        {
            _getAllUserQuery = getAllUserQuery;
            _getUserByCodeQuery = getUserByCodeQuery;
        }

        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            try
            {
                var list = _getAllUserQuery.Execute();

                if (list == null)
                    return StatusCode(StatusCodes.Status204NoContent);

                return StatusCode(StatusCodes.Status200OK, list);

            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
        
        [HttpGet("getByCode/{code}")]
        public IActionResult GetByCode(string code)
        {
            try
            {
                if(string.IsNullOrEmpty(code))
                    return StatusCode(StatusCodes.Status400BadRequest);

                var user = _getUserByCodeQuery.Execute(code);

                if (user == null)
                    return StatusCode(StatusCodes.Status204NoContent);

                return StatusCode(StatusCodes.Status200OK, user);

            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
    }
}
