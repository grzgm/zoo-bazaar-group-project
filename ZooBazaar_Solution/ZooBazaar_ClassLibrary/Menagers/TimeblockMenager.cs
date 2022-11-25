using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooBazaar_ClassLibrary.Interfaces;
using ZooBazaar_DomainModels.Models;
using ZooBazaar_DTO.DTOs;
using ZooBazaar_Repositories.Interfaces;

namespace ZooBazaar_ClassLibrary.Menagers
{
    public class TimeblockMenager : ITimeBlockMenager
    {
        private readonly ITimeBlockRepository _timeBlockRepository;

        public TimeblockMenager(ITimeBlockRepository timeBlockRepository)
        {
            _timeBlockRepository = timeBlockRepository;
        }

        public List<TimeBlock> GetAll()
        {
            List<TimeBlock> timeBlocks = new List<TimeBlock>();
            foreach(TimeBlockDTO dto in _timeBlockRepository.GetAll())
            {
                timeBlocks.Add(new TimeBlock(dto));
            }
            return timeBlocks;
        }

        public List<TimeBlockDTO> GetAllDTO()
        {
            return _timeBlockRepository.GetAll().ToList();
        }
    }
}
