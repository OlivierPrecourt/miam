using Miam.DataLayer;
using Miam.DataLayer.EntityFramework;
using Miam.Domain.Entities;

namespace Miam.Web.Automation.AcceptanceTestApi
{
    public class UserAcceptanceTestsApi
    {
        private static EfDatabaseHelper _dataBaseHelper;
        private IEntityRepository<ApplicationUser> _userRepository;

        public UserAcceptanceTestsApi()
        {
            _userRepository = new EfEntityRepository<ApplicationUser>();
        }
        public void createUser(ApplicationUser applicationUserAdmin)
        {
            _userRepository.Add(applicationUserAdmin);
        }

        public void ClearDataBaseForAcceptanceTests()
        {
            _dataBaseHelper = new EfDatabaseHelper();
            _dataBaseHelper.MigrateDatabaseToLatestVersion();
            _dataBaseHelper.ClearAllTables();
        }
    }
}