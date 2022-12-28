using AutoMapper;
using ComputerRepair.BusinessLogic.Dto;
using ComputerRepair.BusinessLogic.Interfaces;
using ComputerRepair.DataAccess.Interfaces;
using ComputerRepair.DataAccess.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ComputerRepair.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IAuthenticateService _authenticateService;
        private readonly IUserService _userService;
        //private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserController(IAuthenticateService authenticateService, IUserService userService
                               /*IUserRepository userRepository*/, IMapper mapper)
        {
            _authenticateService = authenticateService;
            _userService = userService;
           // _userRepository = userRepository;
            _mapper = mapper;
        }

        //
        [HttpGet("{Email}")]
        public ActionResult<UserReadDto> Get(string Email)
        {
            var user = _userService.GetUserByEmailAsync(Email);
            // Destination --> Source
            var userReadDto = _mapper.Map<UserReadDto>(user);
            return Ok(userReadDto);
        }
        //
        [HttpPost]
        public void Add(User user)
        {
            _userService.AddAsync(user);
        }
        //
        //
        [HttpPost]
        public ActionResult<UserReadDto> Post(UserReadDto users)
        {
            //Map CreatedDto to User
            var CreatedUser = _mapper.Map<User>(users);

            //Create User
            var createdUserService = _userService.AddAsync(CreatedUser);

            //Map user to Read Dto
            var userReadDto = _mapper.Map<UserReadDto>(createdUserService);

            return Ok(CreatedUser);
        }

        //-----

        [AllowAnonymous]
        [HttpPost("authenticate")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        // need ton replace usersdata by authenticate 
        public IActionResult Aunthenticate(string email, string password)
        {
            var token = _authenticateService.Authenticate(email, password);
            if (token == null)
            {
                return Unauthorized();
            }

            return Ok(token);
        }
        //----

        [HttpPut]
        public ActionResult<UserCreateDto> Update(UserCreateDto user)
        {
            var usertoUpdateDto = _mapper.Map<User>(user);

            var _user = _userService.UpdateAsync(usertoUpdateDto);

            var userCreateDto = _mapper.Map<UserCreateDto>(_user);

            return Ok(_user);
        }



        [HttpDelete]
        public void Delete(User user)
        {
            _userService.DeleteAsync(user);
        }

        //----

         


    }
}
