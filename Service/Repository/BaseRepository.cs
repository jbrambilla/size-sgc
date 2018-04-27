using Domain.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Repository
{
    public class BaseRepository
    {
        protected BackendContext Context { get; set; }

        public BaseRepository(BackendContext context)
        {
            Context = context;
        }
    }
}
