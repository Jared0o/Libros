using AutoMapper;
using Core.Dtos.Publisher;
using Core.Entities;
using Core.Entities.Identity;
using Core.Interfaces;
using Core.Interfaces.Services;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class PublisherService : IPublisherService
    {
        private readonly IPublisherRepository _publisherRepository;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;

        public PublisherService(IPublisherRepository publisherRepository, IMapper mapper, UserManager<User> userManager)
        {
            _publisherRepository = publisherRepository;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<PublisherResponseDto> CreateAsync(CreatePublisherRequest request, string userEmail)
        {
            //TODO VALIDATOR
            var user = await _userManager.FindByEmailAsync(userEmail);

            var publisher = _mapper.Map<Publisher>(request);

            publisher.CreatedBy = user;
            publisher.Created = DateTime.Now;

            publisher = await _publisherRepository.Create(publisher);

            var response = _mapper.Map<PublisherResponseDto>(publisher);

            return response;
        }

        public async Task DeleteAsync(int id, string userEmail)
        {
            //TODO logi do pliku
            //var user = await _userManager.FindByEmailAsync(userEmail);
            await _publisherRepository.Delete(id);
        }

        public async Task<PublisherResponseDto> GetPublisherAsync(int id)
        {
            var publisher = await _publisherRepository.GetItem(id);

            var response = _mapper.Map<PublisherResponseDto>(publisher);

            return response;
        }

        public async Task<IReadOnlyList<PublisherResponseDto>> GetPublishersAsync()
        {
            var publishers = await _publisherRepository.GetItems();

            var response = _mapper.Map<IReadOnlyList<PublisherResponseDto>>(publishers);

            return response;
        }

        public async Task<PublisherResponseDto> UpdateAsync(UpdatePublisherRequest request, string userEmail)
        {
            //TODO Validatory

            var user = await _userManager.FindByEmailAsync(userEmail);

            var publisher = _mapper.Map<Publisher>(request);

            publisher.Updated = DateTime.Now;
            publisher.UpdatedBy = user;

            publisher = await _publisherRepository.Update(publisher);

            var response = _mapper.Map<PublisherResponseDto>(publisher);

            return response;

        }

        public async Task<IReadOnlyList<PublisherResponseDto>> GetPublishersByName(string name)
        {
            var publishers = await _publisherRepository.GetPublishersByName(name);

            var response = _mapper.Map<IReadOnlyList<PublisherResponseDto>>(publishers);

            return response;
        }
    }
}
