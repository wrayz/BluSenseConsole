using System;
using BluSenseConsole.DataAccess;
using BluSenseConsole.Models;
using Microsoft.Extensions.Configuration;

namespace BluSenseConsole.BusinessLogic
{
    public class BluBoxBussinessLogic
    {
        private BluboxDataAccess _dataAccess;

        public BluBoxBussinessLogic(IConfiguration _configuration)
        {
            _dataAccess = new BluboxDataAccess(_configuration);
        }

        public void Save(string fileName, RepFile item)
        {
            var blubox = new Blubox
            {
                Id = _dataAccess.GetId(new Blubox { Model = item.Model, SN = item.SN }),
                Model = item.Model,
                SN = item.SN,
                SwVersion = item.SWVersion,
                UseStatus = fileName.Contains("RUO") ? "RUO" : "CE",
                UpdateTime = DateTime.Now
            };

            if (blubox.Id == null)
                _dataAccess.Insert(blubox);
            else
                _dataAccess.Update(blubox);
        }
    }
}
