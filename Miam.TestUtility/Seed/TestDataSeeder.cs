﻿using System;
using System.Collections.Generic;
using Miam.DataLayer;
using Miam.DataLayer.EntityFramework;
using Miam.Domain.Entities;

namespace Miam.TestUtility.Seed
{
    public class TestDataSeeder
    {
        private MiamDbContext _dbContext;
      
        private Writer _writer1;
        private Writer _writer2;

        public TestDataSeeder()
        {
            _dbContext = new MiamDbContext();  
        }

        public void ClearTables()
        {
            var database = new EfApplicationDatabase(new MiamDbContext());
            database.ClearAllTables();
        }
        public void SeedTables()
        {
            AddWriters();
            AddRestaurant1WithReviews();
            AddRestaurant2WithReview();
            AddAdmin();

            _dbContext.SaveChanges();
        }

        private void AddWriters()
        {
            _writer1 = TestData.Writer1;
            _writer2 = TestData.Writer2;
            _dbContext.Writers.Add(_writer1);
            _dbContext.Writers.Add(_writer2);
        }

        private void AddRestaurant1WithReviews()
        {
            var restaurant1 = TestData.Restaurant1;
            _dbContext.Restaurants.Add(restaurant1);

            var firstReview = TestData.Review1;
            firstReview.Restaurant = restaurant1;
            firstReview.Writer = _writer1;
            _dbContext.Reviews.Add(firstReview);

            var secondReview = TestData.Review2;
            secondReview.Restaurant = restaurant1;
            secondReview.Writer = _writer2;
            _dbContext.Reviews.Add(secondReview);
        }

        private void AddRestaurant2WithReview()
        {
            var restaurant2 = TestData.Restaurant2;
            _dbContext.Restaurants.Add(restaurant2);

            var review = TestData.Review2;
            review.Restaurant = restaurant2;
            review.Writer = _writer2;
            _dbContext.Reviews.Add(review);
        }

        private void AddAdmin()
        {
            var admin = TestData.MiamUserAdmin;
            _dbContext.MiamUsers.Add(admin);
        }
    }
}