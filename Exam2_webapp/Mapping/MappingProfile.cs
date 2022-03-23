using AutoMapper;
using View;
using Model;

namespace Exam2_webapp.Mapping
{
    internal sealed class MappingProfile : Profile
    {
        public MappingProfile()
        {
            this.AllowNullCollections = true;

            this.CreateMap <View.Resistors.Resistor, Model.Resistors.Resistor>(MemberList.None).ReverseMap();
            this.CreateMap<View.Resistors.ResistorCreateInfo, Model.Resistors.ResistorCreateInfo>(MemberList.None).ReverseMap();
            this.CreateMap<View.Resistors.ResistorSearchInfo, Model.Resistors.ResistorSearchInfo>(MemberList.None).ReverseMap();
            this.CreateMap<View.Resistors.ResistorUpdateInfo, Model.Resistors.ResistorUpdateInfo>(MemberList.None).ReverseMap();
        }
    }
}
