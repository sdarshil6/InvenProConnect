using InvenProConnect.DAOs.Interfaces;
using InvenProConnect.Models;

namespace InvenProConnect.DAOs.Implementations
{
    public class DaoWrapper : IDaoWrapper
    {
        private InventoryManagementSystemContext _context;
        private IUserDao _userDao;
        public DaoWrapper(InventoryManagementSystemContext context) {
            _context = context;
        }
        
        public IUserDao UserDao
        {
            get
            {
                if (_userDao == null)
                {
                    _userDao = new UserDao(_context);
                }
                return _userDao;
            }
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
