using RobotBuilderService.ServiceInterface.Context;
using RobotBuilderService.ServiceInterface.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotBuilderService.ServiceInterface.Repository
{
    public class RobotRepository
    {
        private RobotBuilderContext _dbContext;

        public RobotRepository()
        {
            this._dbContext = new RobotBuilderContext();
        }

        public List<RobotPart> GetRobotParts()
        {
            try
            {
                return this._dbContext.Robot.ToList();
            }
            catch(Exception ex)
            {
                // Log the exception.
                return null;
            }
        }

        public List<RobotPart> GetRobotPart(int id, string type)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(type) && id > 0)
                {
                    return this._dbContext.Robot.Where(x => x.Id == id && x.Type.Equals(type)).ToList();
                }

                return null;
            }
            catch (Exception ex)
            {
                // Log the exception.
                return null;
            }
        }
    }
}
