﻿using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repositories;
using Repositories.common;

namespace Persistence.Repositories
{
    public class ContactPostRepository : AsyncRepository<ContactPost>, IContactPostRepository
    {
        public ContactPostRepository(DbContext db) : base(db) { }

    }
}
