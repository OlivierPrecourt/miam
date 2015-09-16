using FluentAssertions;
using Miam.AcceptanceTests.Admin;
using Miam.AcceptanceTests.Automation.PageObjects;
using Miam.AcceptanceTests.Automation.Seleno;
using Miam.Domain.Entities;
using Miam.TestUtility.Seed;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestStack.BDDfy;

namespace Miam.AcceptanceTests.Authentification
{
    [TestClass]
    [Story(
        Title = "Un administrateur peut s'authentifier",
        AsA = "En tant qu'administrateur",
        IWant = "Je veux  m'authentifier",
        SoThat = "Afin d'avoir accès au système")]
    public class AdminAuthentificationTests : BaseAcceptanceTests
    {
        private MiamUser _userAdmin;

        [TestMethod]
        public void un_admin_avec_courriel_et_mot_de_passe_valide()
        {
            this.Given(x => un_administrateur_existant_non_authentifé())
                .When(x => l_administrateur_entre_son_courriel_et_mot_de_passe_valide())
                .Then(x => l_administrateur_devrait_être_authentifié())
                .BDDfy();
        }

      


        private void un_administrateur_existant_non_authentifé()
        {
            _userAdmin = TestData.MiamUserAdmin;
            TestHelperApi.Users.Add(_userAdmin);
        }
        private void l_administrateur_entre_son_courriel_et_mot_de_passe_valide()
        {
            Host.Instance.NavigateToInitialPage<HomePage>()
                .NavigationMenu
                .ClickLogin()
                .LoginAs(_userAdmin.Email, _userAdmin.Password);
        }

        private void l_administrateur_devrait_être_authentifié()
        {
            var loggedInUserName = Host.Instance.NavigateToInitialPage<HomePage>()
                .LoginPanel
                .LoggedInUserName;

            loggedInUserName.ShouldBeEquivalentTo(_userAdmin.Email);
            
        }
    }
}