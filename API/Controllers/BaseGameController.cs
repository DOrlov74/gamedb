using AutoMapper;
using Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseGameController : ControllerBase 
    {
        protected readonly IGameRepository _repo;
        protected readonly IMapper _mapper;
        public BaseGameController(IGameRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
    }
}
