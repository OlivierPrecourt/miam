﻿using System;
using System.Data.SqlClient;
using System.Web.Mvc;
using Miam.DataLayer;
using Miam.Domain;
using Miam.TestUtility.Database;


namespace Miam.Web.Controllers
{
    public partial class CIController : Controller
    {
        private IDatabaseHelper _dbInit;

        public CIController(IDatabaseHelper dbInit)
        {
            _dbInit = dbInit;
        }

        public virtual ActionResult Index()
        {
            try
            {
                DeleteDb();
                SeedDb();
            }
             catch (Exception ex)
            {
                return Content(ex.Message);
            }
            return Content("Le contenu de la BD a été remplie avec les données de tests </Br> <a href=\"\\\">E.T téléphone maison</a> ");
        }

        public virtual ActionResult ClearDB()
        {
            try
            {
                DeleteDb();
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
            return Content("Le contenu de la BD a été effacée.</Br> <a href=\"\\\">E.T téléphone maison</a> ");
        }

        private void DeleteDb()
        {
                SqlConnection.ClearAllPools();
                _dbInit.DeleteAll();
        }

        private void SeedDb()
        {
            var testData = new DataBaseTestHelper();
            testData.SeedTables();
        }
    }
}
