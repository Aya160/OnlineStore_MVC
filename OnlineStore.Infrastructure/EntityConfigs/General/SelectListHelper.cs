using OnlineStore.Core.Entities.Shipping;
using OnlineStore.Core.Entities.StoreEntity;
using OnlineStore.Core.Entities.Users;
using OnlineStore.Infrastructure.Repository.Shipping;
using OnlineStore.Infrastructure.Repository.StoreEntity;
using OnlineStore.Infrastructure.Repository.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace OnlineStore.Infrastructure.EntityConfigs.General
{
    public class SelectListHelper
    {
        private readonly ShippingCompaniesRepo<ShippingCompanies> shippingCompaniesRepo;
        private readonly AddressRepo<Address> addressRepo;
        private readonly AdministratorRepo<Administrator> administratorRepo;
        private readonly StoreRepo<Store> storeRepo;
        private readonly VendorRepo<Vendor> vendorRepo;
		private readonly OrderRepo<Order> orderRepo;

		public SelectListHelper(ShippingCompaniesRepo<ShippingCompanies> shippingCompaniesRepo , AddressRepo<Address> addressRepo,
            AdministratorRepo<Administrator> administratorRepo , StoreRepo<Store> storeRepo,VendorRepo<Vendor> vendorRepo ,
            OrderRepo<Order> orderRepo) 
        {
            this.shippingCompaniesRepo = shippingCompaniesRepo;
            this.addressRepo = addressRepo;
            this.administratorRepo = administratorRepo;
            this.storeRepo = storeRepo;
            this.vendorRepo = vendorRepo;
			this.orderRepo = orderRepo;
		}
        public async Task<SelectList> GetCompaniesListAsync()
        {
            var companiesList = await shippingCompaniesRepo.GetAllAsync();
            return new SelectList(companiesList, "Id", "CompanyName");
        }
        public async Task<SelectList> GetAddressListAsync()
        {
            var addressList = await addressRepo.GetAllAsync();
            return new SelectList(addressList, "Id", "StreetAdderss");
        }
        public async Task<SelectList> GetAdministratorListAsync()
        {
            var administratorList = await administratorRepo.GetAllAsync();
            return new SelectList(administratorList, "Id", "SSN");
        }
        public async Task<SelectList> GetStoresListAsync()
        {
            var storeList = await storeRepo.GetAllAsync();
            return new SelectList(storeList, "Id", "Name");
        }
        public async Task<SelectList> GetVendorsListAsync()
        {
            var vendorList = await vendorRepo.GetAllAsync();
            return new SelectList(vendorList, "Id", "Name");
        }

		public async Task<SelectList> GetOrdersListAsync()
		{
			var orderList = await orderRepo.GetAllAsync();
			return new SelectList(orderList, "Id", "Name");
		}
	}
}
