using AutoMapper;
using KidEducation.Core.Model;
using KidEducation.Core.ViewModel;
using KidEducation.Utilities.Sercurity;
using System;
using System.Globalization;


namespace KidEducation.Services.Automapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Posts, PostViewModel>()
                .ForMember(des => des.Id, src => src.MapFrom(s => EncryptDecrypt.Encrypt(s.Id.ToString())))
                .ForMember(des => des.CreateDate, src => src.MapFrom(s => s.CreateDate.HasValue ? s.CreateDate.Value.ToString("dd/MM/yyyy") : ""))
                .ForMember(des => des.UpdateDate, src => src.MapFrom(s => s.UpdateDate.HasValue ? s.UpdateDate.Value.ToString("dd/MM/yyyy") : ""))
            .ReverseMap()
                .ForMember(des => des.Id, src => src.MapFrom(s => string.IsNullOrEmpty(s.Id) ? 0 : int.Parse(EncryptDecrypt.Decrypt(s.Id))))
                .ForMember(des => des.CreateDate, src => src.MapFrom(s => DateTime.ParseExact(s.CreateDate, "dd/MM/yyyy", CultureInfo.InvariantCulture)))
                .ForMember(des => des.UpdateDate, src => src.MapFrom(s => DateTime.ParseExact(s.UpdateDate, "dd/MM/yyyy", CultureInfo.InvariantCulture)));
            CreateMap<Posts, ListPostViewModel>()
                .ForMember(des => des.Id, src => src.MapFrom(s => EncryptDecrypt.Encrypt(s.Id.ToString())))
                .ForMember(des => des.UpdateDate, src => src.MapFrom(s => s.UpdateDate.HasValue ? s.UpdateDate.Value.ToString("dd/MM/yyyy") : ""));
            CreateMap<Posts, PostCardViewModel>();
            CreateMap<Posts, PostDetailViewModel>();
            CreateMap<Posts, RelatedPostsViewModel>();


            CreateMap<Account, AccountViewModel>()
                .ForMember(des => des.Id, src => src.MapFrom(s => EncryptDecrypt.Encrypt(s.Id.ToString())))
               .ReverseMap()
               .ForMember(des => des.Id, src => src.MapFrom(s => string.IsNullOrEmpty(s.Id) ? 0 : int.Parse(EncryptDecrypt.Decrypt(s.Id))));
            CreateMap<TableShowConfig, TableConfigJQuery>();

            CreateMap<PopUp, PopupViewModel>()
                .ForMember(des => des.Id, src => src.MapFrom(s => EncryptDecrypt.Encrypt(s.Id.ToString())))
                .ForMember(des => des.StartTime, src => src.MapFrom(s => s.StartTime.HasValue ? s.StartTime.Value.ToString("dd/MM/yyyy") : ""))
                .ForMember(des => des.EndTime, src => src.MapFrom(s => s.EndTime.HasValue ? s.EndTime.Value.ToString("dd/MM/yyyy") : ""))
            .ReverseMap()
                .ForMember(des => des.Id, src => src.MapFrom(s => string.IsNullOrEmpty(s.Id) ? 0 : int.Parse(EncryptDecrypt.Decrypt(s.Id))))
                .ForMember(des => des.StartTime, src => src.MapFrom(s => DateTime.ParseExact(s.StartTime, "dd/MM/yyyy", CultureInfo.InvariantCulture)))
                .ForMember(des => des.EndTime, src => src.MapFrom(s => DateTime.ParseExact(s.EndTime, "dd/MM/yyyy", CultureInfo.InvariantCulture)));

            CreateMap<Contact, ContactViewModel>()
                .ForMember(des => des.Id, src => src.MapFrom(s => EncryptDecrypt.Encrypt(s.Id.ToString())))
                .ForMember(des => des.CreatedDate, src => src.MapFrom(s => s.CreatedDate.HasValue ? s.CreatedDate.Value.ToString("dd/MM/yyyy HH:mm:ss") : ""))
                .ForMember(des => des.Status, src => src.MapFrom(s => s.Status == 2 ? "<span class=\"text-success\">Đã xử lý</p>":"<span class=\"text-danger\">Chưa xử lý</p>"))
                .ReverseMap()
                .ForMember(des => des.Id, src => src.MapFrom(s => string.IsNullOrEmpty(s.Id) ? 0 : int.Parse(EncryptDecrypt.Decrypt(s.Id))))
                .ForMember(des => des.CreatedDate, src => src.MapFrom(s => DateTime.Now));
        }
    }
}
