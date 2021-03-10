﻿using ElevaCase.Domain.Entities;
using ElevaCase.Domain.Interfaces;
using ElevaCase.Infra.Data.Context;
using System.Collections.Generic;
using System.Linq;

namespace ElevaCase.Infra.Data.Repositories
{
    public class ClassRepository : IClassRepository
    {
        private readonly ElevaCaseDbContext dbContext;

        public ClassRepository(ElevaCaseDbContext dbContext) => 
            this.dbContext = dbContext;

        public IQueryable<@Class> GetAll(int schoolId) => 
            dbContext.Classes.Where(p => p.School.Id == schoolId);

        public void Add(@Class @class)
        {
            dbContext.Classes.Add(@class);
            dbContext.SaveChanges();
        }
    }
}