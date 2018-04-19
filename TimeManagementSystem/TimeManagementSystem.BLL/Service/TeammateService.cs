using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeManagementSystem.BLL.DTO;
using TimeManagementSystem.BLL.Interfaces;
using TimeManagementSystem.DAL.Entities;
using TimeManagementSystem.DAL.Interfaces;

namespace TimeManagementSystem.BLL.Service
{
    class TeammateService : ITeammateService
    {
        IUnitOfWork _unitOfWork;
        public TeammateService(IUnitOfWork _unitOfWork)
        {
            this._unitOfWork = _unitOfWork;
        }
        public void Delete(TeammateDTO teammateDTO)
        {
            var mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TeammateDTO, Teammate>();
            }).CreateMapper();
            _unitOfWork.Teammates.Delete(mapper.Map<TeammateDTO,Teammate>(teammateDTO));
        }

        public void Edit(TeammateDTO teammate)
        {
            var mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TeammateDTO, Teammate>();
            }).CreateMapper();
            _unitOfWork.Teammates.Update(mapper.Map<TeammateDTO,Teammate>(teammate));
        }
    }
}
