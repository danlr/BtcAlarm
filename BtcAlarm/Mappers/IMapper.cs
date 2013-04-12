﻿using System;

namespace BtcAlarm.Mappers
{
    public interface IMapper
    {
        object Map(object source, Type sourceType, Type destinationType);
    }
}
