﻿using Common.Application;
using StuAttendanceAPI.Domain.UserAggregate;
using System;
using System.Linq;

namespace StuAttendanceAPI.Application.AttendanceRecord.Delete
{
    public class DeleteAttendanceCommand : IBaseCommand
    {
        public Guid AttendanceId { get; set; }
        public Guid SessionId { get; set; }
        public Guid StudentId { get; set; }
        public UserInfo? CommandSender { get; set; }


    }
}
