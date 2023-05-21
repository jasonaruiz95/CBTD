﻿using CBTD.Models;
using CBTD.Models.Interfaces;

namespace CBTD.DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext;  //dependency injection of Data Source

        public UnitOfWork(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        
        //ADD ADDITIONAL MODELS HERE
        private IGenericRepository<Category> _Category;
        private IGenericRepository<Manufacturer> _Manufacturer;

        public IGenericRepository<Category> Category
        {
            get
            {

                if (_Category == null)
                {
                    _Category = new GenericRepository<Category>(_dbContext);
                }

                return _Category;
            }
        }


        public IGenericRepository<Manufacturer> Manufacturer
        {
            get
            {

                if (_Manufacturer == null)
                {
                    _Manufacturer = new GenericRepository<Manufacturer>(_dbContext);
                }

                return _Manufacturer;
            }
        }
        //ADD ADDITIONAL METHODS FOR EACH MODEL (similar to Category) HERE

        public int Commit()
        {
            return _dbContext.SaveChanges();
        }

        public async Task<int> CommitAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }

        //additional method added for garbage disposal

        public void Dispose()
        {
            _dbContext.Dispose();
        }

    }
}