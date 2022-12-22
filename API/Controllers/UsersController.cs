using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using API.Data;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
   [Authorize]
    public class UsersController : BaseApiController
    {
        private readonly IUserRepository _userRepositroy;
        private readonly IMapper _mapper;
        public UsersController(IUserRepository userRepository, IMapper mapper)
        { 
            _mapper = mapper;
            _userRepositroy = userRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MemberDto>>> GetUsers()
        {
            var users = await _userRepositroy.GetMembersAsync();

            return Ok(users);
        }
         
        [HttpGet("{username}")]
        public async Task<ActionResult<MemberDto>> GetUser(string username)
        {
            var user = await _userRepositroy.GetMemberAsync(username);

            return  user;
        }
        [HttpPut]
        public async Task<ActionResult>UpdateUser(MemberUpdateDto memberUpdateDto)
        {
            var username = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var user = await _userRepositroy.GetUserByUsernameAsync(username);

            _mapper.Map(memberUpdateDto,user);

            _userRepositroy.Update(user);
            
            if(await _userRepositroy.SaveAllAsync()) return NoContent();
            return BadRequest("Failed to update user");
        }
    }
}