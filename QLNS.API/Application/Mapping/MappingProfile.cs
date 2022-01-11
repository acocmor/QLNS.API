using AutoMapper;
using QLNS.API.Application.DTOs.ChucVu;
using QLNS.API.Application.DTOs.HopDongLaoDong;
using QLNS.API.Application.DTOs.NhanVien;
using QLNS.API.Application.DTOs.PhongBan;
using QLNS.API.Application.DTOs.QueQuan;
using QLNS.API.Application.DTOs.User;
using QLNS.Domain.Entities;

namespace QLNS.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //User Map
            CreateMap<User, GetUserDTO>().ReverseMap();
            CreateMap<CreateUserDTO, User>();
            CreateMap<UpdateUserDTO, User>();

            //NhanVien Map
            CreateMap<NhanVien, GetNhanVienDTO>().ReverseMap();
            CreateMap<CreateNhanVienDTO, NhanVien>();
            CreateMap<UpdateNhanVienDTO, NhanVien>();

            //QueQuan Map
            CreateMap<QueQuan, GetQueQuanDTO>().ReverseMap();
            CreateMap<CreateQueQuanDTO, QueQuan>();
            CreateMap<UpdateQueQuanDTO, QueQuan>();
            
            //ChucVU Map
            CreateMap<ChucVu, GetChucVuDTO>().ReverseMap();
            CreateMap<CreateChucVuDTO, ChucVu>();
            CreateMap<UpdateChucVuDTO, ChucVu>();
            
            //PhongBan Map
            CreateMap<PhongBan, GetPhongBanDTO>().ReverseMap();
            CreateMap<CreatePhongBanDTO, PhongBan>();
            CreateMap<UpdatePhongBanDTO, PhongBan>();
            
            //PhongBan Map
            CreateMap<HopDongLaoDong, GetHDLDDTO>().ReverseMap();
            CreateMap<CreateHDLDDTO, HopDongLaoDong>();
            CreateMap<UpdateHDLDDTO, HopDongLaoDong>();
        }
    }
}
