using AutoMapper;
using Business.Services;
using Entity.DTOS;
using Entity.Tables;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserServices _userServices;
        IMapper _mapper;


        public UserController(UserServices userServices, IMapper mapper)
        {
            _userServices = userServices;
            _mapper = mapper;
        }


        [HttpPost]
        public async Task<IActionResult> Post(UserAddDto users)
        {

            await _userServices.Add(_mapper.Map<Users>(users));

            return NoContent();
        }

        [HttpGet]
        public async Task<List<Users>> Get()
        {



            return await _userServices.GetUsers();
        }


        [HttpPut]
        public async Task<IActionResult> Put(UserUpdateDto users)
        {

            await _userServices.Update(_mapper.Map<Users>(users));

            return NoContent();
        }


        [HttpDelete]
        public async Task<IActionResult> Delete(UserUpdateDto users)
        {

            await _userServices.Delete(_mapper.Map<Users>(users));

            return NoContent();
        }
    }
}
