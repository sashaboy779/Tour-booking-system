﻿using DAL.EF;
using DAL.Entity;
using DAL.Repository.Interface;

namespace DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        public IRepository<Resort> Resorts { get; private set; }
        public IRepository<Tour> Tours { get; private set; }
        public IRepository<TourVariant> TourVariants { get; private set; }

        private readonly ApplicationDbContext dbContext;

        public UnitOfWork(ApplicationDbContext context, IRepository<Resort> resorts, 
                      IRepository<Tour> tours, IRepository<TourVariant> tourVariants)
        {
            dbContext = context;
            Resorts = resorts;
            Tours = tours;
            TourVariants = tourVariants;
        }

        public void Save()
        {
            dbContext.SaveChanges();
        }

        public void Dispose()
        {
            dbContext.Dispose();
        }
    }
}
