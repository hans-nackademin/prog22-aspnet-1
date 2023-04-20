using WebApi.Helpers.Repositories;
using WebApi.Models.Dtos;
using WebApi.Models.Entities;

namespace WebApi.Helpers.Services
{
    public class AddressManager
    {
        private readonly AddressRepository _addressRepo;
        private readonly UserAddressRepository _userAddressRepo;

        public AddressManager(AddressRepository addressRepo, UserAddressRepository userAddressRepo)
        {
            _addressRepo = addressRepo;
            _userAddressRepo = userAddressRepo;
        }

        public async Task<Address> GetOrCreateAsync(AddressSchema model)
        {
            var addressEntity = await _addressRepo.GetAsync(x =>
                x.AddressLine_1 == model.AddressLine_1 &&
                x.AddressLine_2 == model.AddressLine_2 &&
                x.PostalCode == model.PostalCode &&
                x.City == model.City
            );

            addressEntity ??= await _addressRepo.AddAsync(model);            
            return addressEntity;
        }

        public async Task AddUserAddressAsync(UserAddressEntity userAddressEntity)
        {
            await _userAddressRepo.AddAsync(userAddressEntity);
        }
    }
}
