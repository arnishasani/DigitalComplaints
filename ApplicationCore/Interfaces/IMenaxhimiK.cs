﻿using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Interfaces
{
    public interface IMenaxhimiK : IRepository<TblMenaxhimiKerkesave>
    {
        IEnumerable<TblMenaxhimiKerkesave> GetAllList();
        int GetMax();
        bool DeleteMenaxhim(TblMenaxhimiKerkesave model);

        bool UpdateMenaxhim(TblMenaxhimiKerkesave model);
    }
}
