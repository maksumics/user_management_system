using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserRepoApp.Data;
using UserRepoApp.Models;

namespace UserRepoApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UsersController(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<UserModel>> GetUsers(int pageNumber = 1, int pageSize = 10)
        {
            var users = await _userRepository.GetUsers(pageNumber-1, pageSize);
            return Ok(new { pageNumber = pageNumber, 
                pageSize = pageSize, 
                count = users.Count(), 
                users = _mapper.Map<IList<UserModel>>(users) });
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<UserModel>> GetUser(int id)
        {
            var user = await _userRepository.GetUser(id);
            if (user == null)
                    return NotFound(new ErrorModel() { Message = "User not found", StatusCode = 404});
            return Ok(_mapper.Map<UserModel>(user));
        }

        [HttpPost]
        public async Task<IActionResult> PostUsers(CreateUserModel model)
        {
            if (model == null)
                return BadRequest(new ErrorModel() { Message = "Wrong rrequest data!", StatusCode = 400 });
            var createdUser = await _userRepository.AddUser(_mapper.Map<User>(model));
            if (createdUser != null)
                return RedirectToAction("GetUser", new { id = createdUser.Id });
            else
                return Conflict(new ErrorModel() { Message = "User alredy exist!", StatusCode = 409 });
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<UserModel>> UpdateUser(int id, EditUserModel model)
        {
            var user = await _userRepository.GetUser(id);
            user = _mapper.Map<User>(model);
            user.Id = id;
            user = await _userRepository.UpdateUser(user);
            if (user != null)
                return Ok(_mapper.Map<UserModel>(user));
            else
                return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _userRepository.GetUser(id);
            if (user == null)
                return NotFound(new ErrorModel() { Message = "User not found!", StatusCode = 404 });
            _userRepository.DeleteUser(id);
            return Ok(new ErrorModel() { Message = "User succesfully removed!", StatusCode = 200 });
        }
    }
}