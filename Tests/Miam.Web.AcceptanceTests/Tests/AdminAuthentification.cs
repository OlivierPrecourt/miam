﻿using Miam.TestUtility.Database;
using Miam.Web.Automation.AcceptanceTestApi;
using Miam.Web.Automation.PageObjects;
using Miam.Web.Automation.Seleno;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestStack.BDDfy;

namespace Miam.Web.AcceptanceTests
{
    [TestClass]
    [Story(
        Title = "Un administrateur peut s'authentifier",
        AsA = "En tant qu'administrateur",
        IWant = "Je veux  m'authentifier",
        SoThat = "Afin d'avoir accès au système")]
    public class AdminAuthentification
    {
        //private ApplicationUser _userAdmin;
        private UserAcceptanceTestsApi _userAcceptanceTestApi;
        private DatabaseHelperAcceptanceTestApi _databaseHelperAcceptanceTestApi;
        private HomePage _homePage;

        [TestInitialize]
        public void initialize()
        {
            _userAcceptanceTestApi = new UserAcceptanceTestsApi();
            _databaseHelperAcceptanceTestApi = new DatabaseHelperAcceptanceTestApi();
            _databaseHelperAcceptanceTestApi.ClearDataBaseTables();

            _homePage = Host.Instance.NavigateToInitialPage<HomePage>();
        }

        [TestCleanup]
        public void cleanup()
        {
            _homePage.LogOut();
        }

        [TestMethod]
        public void s_authentifier_avec_courriel_et_mot_de_passe_valide()
        {
            this.Given(x => un_administrateur_existant_non_authentifé())
                .When(x => l_administrateur_entre_son_courriel_et_mot_de_passe_valide())
                .Then(x => l_administrateur_devrait_être_authentifié())
                .BDDfy();
        }

        [TestMethod]
        public void s_authentifier_avec_courriel_invalide()
        {
            this.Given(x => un_administrateur_existant_non_authentifé())
                .When(x => l_administrateur_entre_un_mot_de_passe_invalide())
                .Then(x => l_administrateur_ne_devrait_pas_être_authentifié())
                .BDDfy();
        }

        private void un_administrateur_existant_non_authentifé()
        {
            _userAcceptanceTestApi.createUser(TestData.ApplicationUserAdmin);
        }
        private void l_administrateur_entre_son_courriel_et_mot_de_passe_valide()
        {
            var homePage = Host.Instance.NavigateToInitialPage<HomePage>();
            var loginPage = homePage.GoToLoginPage();
            loginPage.SelenoLoginAs(TestData.ApplicationUserAdmin.Email, TestData.ApplicationUserAdmin.Password);
        }
        private void l_administrateur_entre_un_mot_de_passe_invalide()
        {
            var loginPage = _homePage.GoToLoginPage();
            loginPage.SelenoLoginAs(TestData.ApplicationUserAdmin.Email, "invalid_password");
        }

        private void l_administrateur_ne_devrait_pas_être_authentifié()
        {
            var homePage = Host.Instance.NavigateToInitialPage<HomePage>();
            var islogged = homePage.SelenoIsLogged(TestData.ApplicationUserAdmin.Email);

            Assert.IsFalse(islogged);
        }

        private void l_administrateur_devrait_être_authentifié()
        {
            var homePage = Host.Instance.NavigateToInitialPage<HomePage>();
            var islogged = homePage.SelenoIsLogged(TestData.ApplicationUserAdmin.Email);

            Assert.IsTrue(islogged);
        }
    }
}