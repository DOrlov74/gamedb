using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public abstract class BaseRepository
    {
        protected GameContext Context { get; set; }
        public BaseRepository(GameContext context)
        {
            Context = context;
        }
    }
}
