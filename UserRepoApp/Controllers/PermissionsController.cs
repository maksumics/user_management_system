using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserRepoApp.Data;
using UserRepoApp.Models;

namespace UserRepoApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionsController : ControllerBase
    {
        private readonly IPermissionRepository _permissionRepository;
        private readonly IMapper _mapper;
        public PermissionsController(IPermissionRepository permissionRepository, IMapper mapper)
        {
            _permissionRepository = permissionRepository;
            _mapper = mapper;
        }

        [HttpGet("{userId:int}")]
        public async Task<IActionResult> GetPermissionsForUser(int userId)
        {
            var permissions = await _permissionRepository.GetPermissionsForUser(userId);
            return Ok(new { userId = userId, permissions = _mapper.Map<List<PermissionModel>>(permissions) });
        }

        [HttpPost]
        public async Task<IActionResult> PostPermission(PermissionModel model)
        {
            var permission = _mapper.Map<Permission>(model);
            var created = await _permissionRepository.CreatePermission(permission);
            if (created != null)
                return Ok(_mapper.Map<PermissionModel>(created));
            else
                return BadRequest(new ErrorModel() { Message = "Permission cannot be created", StatusCode = 400 });
        }

        [HttpGet("api/[controller]/assign", Name = "AssignPermission")]
        public async Task<ActionResult<List<PermissionModel>>> AssignPermission(int userId, int permissionId)
        {
            if(userId <= 0 || permissionId <= 0)
                return BadRequest(new ErrorModel() { Message = "Wrong parameters", StatusCode = 400 });
            var result = await _permissionRepository.AssignPermission(userId, permissionId);
            if (result != null)
                return Ok(new { userId = userId, permissions = _mapper.Map<List<PermissionModel>>(result) });
            else
                return Conflict(new ErrorModel() { Message = "Cannot assing permission", StatusCode = 409 });
        }

        [HttpGet("api/[controller]/remove", Name = "RemovePermission")]
        public async Task<ActionResult<List<PermissionModel>>> RemovePermission(int userId, int permissionId)
        {
            if (userId <= 0 || permissionId <= 0)
                return BadRequest(new ErrorModel() { Message = "Wrong parameters", StatusCode = 400 });
            var result = await _permissionRepository.RemovePermission(userId, permissionId);
            if (result != null)
                return Ok(new { userId = userId, permissions = _mapper.Map<List<PermissionModel>>(result) });
            else
                return Conflict(new ErrorModel() { Message = "Cannot remove permission for user", StatusCode = 409 });
        }
    }
}
