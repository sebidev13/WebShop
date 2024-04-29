using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebShopServiceWebsline.DTO;
using WebShopServiceWebsline.Interfaces;
using WebShopServiceWebsline.Models;
using WebShopServiceWebsline.Repository;

namespace WebShopServiceWebsline.Controllers;


    [Route("api/[controller]")]
    [ApiController]
    public class UserController: Controller
    {
        private readonly IUserRepository _userRepository; 
        private readonly IMapper _mapper;
        
        public UserController(IUserRepository userRepository, IMapper mapper) 
        {
            _userRepository = userRepository; 
            _mapper = mapper;
        }
        
        [HttpGet("Id/{userId}")]
        [ProducesResponseType(200, Type = typeof(User))]
        [ProducesResponseType(400)]
        public IActionResult GetUserById(int userId)
        {
            if (_userRepository.UserExists(userId) == false)
                return NotFound();

            var user = _mapper.Map<UserDTO>(_userRepository.GetUser(userId));    

            if(ModelState.IsValid == false)
                return BadRequest(ModelState);  

            return Ok(user);
        }
        
        [HttpGet("Name/{userName}")]
        [ProducesResponseType(200, Type = typeof(User))]
        [ProducesResponseType(400)]
        public IActionResult GetUserByName(string userName)
        {
            var user = _mapper.Map<UserDTO>(_userRepository.GetUser(userName));    

            if (user == null)
                return NotFound();
            
            if(ModelState.IsValid == false)
                return BadRequest(ModelState);  

            return Ok(user);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateUser([FromBody] UserDTO userCreate)
        {
            if (userCreate == null)
                return BadRequest(ModelState);

            var users = _userRepository.GetUsers()
                .Where(u => u.Username.Trim().ToUpper() == userCreate.Username.TrimEnd().ToUpper())
                .FirstOrDefault();

            if (users != null)
            {
                ModelState.AddModelError("", "User already exists");
                return StatusCode(422, ModelState);
            }

            if (ModelState.IsValid == false)
                return BadRequest(ModelState);

            var userMap = _mapper.Map<User>(userCreate);

            if (_userRepository.CreateUser(userMap) == false)
            {
                ModelState.AddModelError("", "Something went wrong while saving the user");
                return StatusCode(500, ModelState);
            }

            return Ok("User Successfully created");
        }
        
        [HttpPut()] //"{userId}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult UpdateUser([FromQuery] int userId, [FromBody] UserDTO updateUser)
        {
            if (updateUser == null)
                return BadRequest(ModelState);

            if(userId != updateUser.UserId)
                return BadRequest("The updated User must have the same id as the original user");    

            if(_userRepository.UserExists(userId) == false)
                return NotFound();

            if (ModelState.IsValid == false)
                return BadRequest(ModelState);

            var userMap = _mapper.Map<User>(updateUser);

            if (_userRepository.UpdateUser(userMap) == false)
            {
                ModelState.AddModelError("", "Something went wrong while updating");
                return StatusCode(500, ModelState);
            }

            return Ok(); 
        }
        
        [HttpDelete()]  //"{userId}")]
        [ProducesResponseType(200)] 
        [ProducesResponseType(204)] 
        [ProducesResponseType(400)] 
        [ProducesResponseType(404)] 
        public IActionResult DeleteUser([FromQuery] int userId, [FromBody] UserDTO deleteUser)
        {
            if (deleteUser == null)
                return BadRequest(ModelState);

            if(userId != deleteUser.UserId)
                return BadRequest();    

            if(_userRepository.UserExists(userId) == false)
                return NotFound();

            if (ModelState.IsValid == false)
                return BadRequest(ModelState);

            var userMap = _mapper.Map<User>(deleteUser);

            if (_userRepository.DeleteUser(userMap) == false)
            {
                ModelState.AddModelError("", "Something went wrong while deleting");
                return StatusCode(500, ModelState);
            }
            return Ok(); 
        }
    }