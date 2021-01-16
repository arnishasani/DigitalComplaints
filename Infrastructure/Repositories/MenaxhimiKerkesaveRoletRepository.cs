using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repositories
{
    public class MenaxhimiKerkesaveRoletRepository : Repository<MenaxhimiKerkesaveRolet>, IMenaxhimiKerkesaveRole
    {
        protected readonly ApplicationDBContext _digitalComplaintsDB;

        public MenaxhimiKerkesaveRoletRepository(ApplicationDBContext digitalComplaintsDB) : base(digitalComplaintsDB)
        {
            _digitalComplaintsDB = digitalComplaintsDB;
        }
    }
}
