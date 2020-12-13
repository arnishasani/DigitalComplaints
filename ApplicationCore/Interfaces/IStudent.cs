﻿using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Interfaces
{
    public interface IStudent : IRepository<AspNetUsers>
    {
        IEnumerable<AspNetUsers> GetAllStudentList();
        bool DeleteStudent(AspNetUsers model);

        bool UpdateStudent(AspNetUsers model);
    }
}
