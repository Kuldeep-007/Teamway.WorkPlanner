using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teamway.WorkPlanner.Data.Migrations;

namespace Teamway.WorkPlanner.Data
{
    public class DbContextBase
    {
        protected tw_work_planner_devContext _dbContext = null;

        public DbContextBase()
        {
            _dbContext = new tw_work_planner_devContext();
        }

        public void SaveRepository()
        {
            try
            {
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
    }
}
