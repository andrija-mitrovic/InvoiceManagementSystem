using AutoMapper;
using InvoiceManagementSystem.Application.DTOs;
using InvoiceManagementSystem.Application.Helpers;
using InvoiceManagementSystem.Domain.Entities;
using NUnit.Framework;
using System;
using System.Runtime.Serialization;

namespace InvoiceManagementSystem.Application.UnitTests.Helpers
{
    public class MappingTests
    {
        private IConfigurationProvider _config;
        private IMapper _mapper;

        [SetUp]
        public void Setup()
        {
            _config = new MapperConfiguration(x =>
            {
                x.AddProfile<MappingProfiles>();
            });

            _mapper = _config.CreateMapper();
        }

        [Test]
        public void ShouldHaveValidConfiguration()
        {
            _config.AssertConfigurationIsValid();
        }

        [Test]
        [TestCase(typeof(Invoice), typeof(InvoiceDto))]
        [TestCase(typeof(InvoiceItem), typeof(InvoiceItemDto))]
        public void ShouldSupportMappingFromSourceToDestination(Type source, Type destination)
        {
            var instance = GetInstanceOf(source);

            _mapper.Map(instance, source, destination);
        }

        private object GetInstanceOf(Type type)
        {
            if (type.GetConstructor(Type.EmptyTypes) != null)
                return Activator.CreateInstance(type);

            // Type without parameterless constructor
            return FormatterServices.GetUninitializedObject(type);
        }
    }
}
