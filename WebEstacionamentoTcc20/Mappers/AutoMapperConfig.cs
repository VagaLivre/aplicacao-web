using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebEstacionamentoTcc20.Models;
using static WebEstacionamentoTcc20.Models.Empresa;
using static WebEstacionamentoTcc20.Models.Usuario;

namespace WebEstacionamentoTcc20.Mappers
{
    public class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<DominToViewModelMappingProfile>();

                x.AddProfile<ViewModelToDominMappingProfile>();
            });
        }
    }

    public class DominToViewModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "DominToViewModelMappingProfile"; }
        }
        protected override void Configure()
        {
            Mapper.CreateMap<Empresa, EmpresaCreateViewModel>();
            Mapper.CreateMap<Empresa, EmpresaEditViewModel>();
            Mapper.CreateMap<Empresa, EmpresaDisplayViewModel>();
            Mapper.CreateMap<Empresa, EmpresaDeleteViewModel>();


            Mapper.CreateMap<Usuario, UsuarioCreateViewModel>();
            Mapper.CreateMap<Usuario, UsuarioEditViewModel>();
            Mapper.CreateMap<Usuario, UsuarioDisplayViewModel>();
            Mapper.CreateMap<Usuario, UsuarioDeleteViewModel>();



        }
    }
    public class ViewModelToDominMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "ViewModelToDominMappingProfile"; }
        }
        protected override void Configure()
        {
            Mapper.CreateMap<EmpresaCreateViewModel, Empresa>();
            Mapper.CreateMap<EmpresaEditViewModel, Empresa>();
            Mapper.CreateMap<EmpresaDisplayViewModel, Empresa>();
            Mapper.CreateMap<EmpresaDeleteViewModel, Empresa>();

            Mapper.CreateMap<UsuarioCreateViewModel, Usuario>();
            Mapper.CreateMap<UsuarioEditViewModel, Usuario>();
            Mapper.CreateMap<UsuarioDisplayViewModel, Usuario>();
            Mapper.CreateMap<UsuarioDeleteViewModel, Usuario>();




        }
    }
}
