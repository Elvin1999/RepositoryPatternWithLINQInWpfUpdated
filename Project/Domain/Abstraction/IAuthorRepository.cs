﻿using Project.DataAccess.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Domain.Abstraction
{
   public interface IAuthorRepository:IRepository<Author>
    {
    }
}
