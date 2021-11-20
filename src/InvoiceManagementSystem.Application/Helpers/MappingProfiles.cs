using AutoMapper;
using InvoiceManagementSystem.Application.DTOs;
using InvoiceManagementSystem.Application.Features.CompanyInfo.Command;
using InvoiceManagementSystem.Application.Features.Invoices.Command;
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

            CreateMap<CreateCompanyInfoCommand, CompanyInfo>();

            CreateMap<EditInvoiceItemCommand, InvoiceItem>()
                .ForMember(x => x.InvoiceId, y => y.MapFrom(z => z.InvoiceId))
                .ForMember(x => x.Id, y => y.MapFrom(z => z.InvoiceItemId));
        }
    }
}
