using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooBazaar_DTO;
using ZooBazaar_DTO.DTOs;

namespace ZooBazaar_DomainModels.Models
{
    public class TimeBlock
    {
        private int _id;
        private TimeOnly _startTime;
        private TimeOnly _endTime;

      public TimeBlock(TimeBlockDTO timeBlockDTO)
      {
            this._id = timeBlockDTO.TimeblockID;
            this._startTime = TimeOnly.FromTimeSpan(timeBlockDTO.StartingTime);
            this._endTime = TimeOnly.FromTimeSpan(timeBlockDTO.EndingTime);

      }
        public override string ToString()
        {
            return _startTime.ToString() + "  " + _endTime.ToString();
        }


    }
}
