﻿using Oneonones.Domain.Enums;

namespace Oneonones.Domain.Entities
{
    public class OneononeEntity
    {
        public string Id { get; set; }
        public EmployeeEntity Leader { get; set; }
        public EmployeeEntity Led { get; set; }
        public FrequencyEnum Frequency { get; set; }
    }
}