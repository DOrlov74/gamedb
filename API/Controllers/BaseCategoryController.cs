using AutoMapper;
using Data;
using Microsoft.AspNetCore.Mvc;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseCategoryController : ControllerBase
    {    
        protected readonly IRepository<Category> _repo;
        protected readonly IMapper _mapper;
        public BaseCategoryController(IRepository<Category> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
    }
}
