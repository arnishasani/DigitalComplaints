﻿using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Interfaces
{
    public interface IStaff : IRepository<AspNetUsers>
    {
        IEnumerable<AspNetUsers> GetAllList();
        bool DeleteUser(AspNetUsers model);
        bool UpdateUser(AspNetUsers model);
    }
}
