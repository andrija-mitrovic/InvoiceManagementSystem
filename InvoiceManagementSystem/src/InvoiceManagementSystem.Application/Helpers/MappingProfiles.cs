using AutoMapper;
using InvoiceManagementSystem.Application.DTOs;
using InvoiceManagementSystem.Domain.Entities;

namespace InvoiceManagementSystem.Application.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Invoice, InvoiceDto>();
            CreateMap<InvoiceDto, Invoice>();

            CreateMap<InvoiceItem, InvoiceItemDto>();
            CreateMap<InvoiceItemDto, InvoiceItem>();

            CreateMap<CompanyInfo, CompanyInfo>();
        }
    }
}
