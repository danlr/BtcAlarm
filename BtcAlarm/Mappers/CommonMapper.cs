namespace BtcAlarm.Mappers
{
    using System;

    using AutoMapper;

    using BtcAlarm.Model;
    using BtcAlarm.Models.ViewModels;

    public class CommonMapper : IMapper
    {
        static CommonMapper()
        {
            Mapper.CreateMap<User, UserView>();
            Mapper.CreateMap<UserView, User>();
        }

        public object Map(object source, Type sourceType, Type destinationType)
        {
            return Mapper.Map(source, sourceType, destinationType);
        }
    }
}