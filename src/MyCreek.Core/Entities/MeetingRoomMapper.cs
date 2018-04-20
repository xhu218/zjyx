using DapperExtensions.Mapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyCreek.Entities
{
    public class MeetingRoomMapper : ClassMapper<MeetingRoom>
    {
        public MeetingRoomMapper()
        {
            Table("MeetingRoomMapper");
            AutoMap();
        }
    }
}
