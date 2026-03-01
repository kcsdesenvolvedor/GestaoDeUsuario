using AutoMapper;
using GestaoUsuario.API.Models;
using GestaoUsuario.Application.Repositories;
using GestaoUsuario.Domain.Entities;
using GestaoUsuario.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace GestaoUsuario.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _userService = userService;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _userService.GetAllAsync();
            return Ok(_mapper.Map<List<UserResponse>>(users));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var user = await _userService.GetByIdAsync(id);

            if (user == null)
                return NotFound();

            return Ok(_mapper.Map<UserResponse>(user));
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] UserRequest userRequest, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<User>(userRequest);
            await _userService.CreateAsync(user);
            await _unitOfWork.CommitAsync(cancellationToken);
            return Ok(_mapper.Map<UserResponse>(user));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(Guid id, [FromBody] UserRequest userRequest, CancellationToken cancellationToken)
        {
            var user = await _userService.GetByIdAsync(id);
            if (user == null)
                return NotFound(new { message = "Usuário não encontrado!" });

            _mapper.Map(userRequest, user);
            await _userService.UpdateAsync(user);
            await _unitOfWork.CommitAsync(cancellationToken);
            return Ok(_mapper.Map<UserResponse>(user));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            var user = await _userService.GetByIdAsync(id);
            if (user == null)
                return NotFound(new { message = "Usuário não encontrado!" });

            await _userService.DeleteAsync(id);
            await _unitOfWork.CommitAsync(cancellationToken);
            return Ok(new { message = "Usuário deletado" });
        }

    }
}
