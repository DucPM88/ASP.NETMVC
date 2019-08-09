using ASPNETMVC.Dtos;
using ASPNETMVC.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ASPNETMVC.Controllers.Api
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }
        /// <summary>
        /// Lấy danh sách customer
        /// </summary>
        /// <returns></returns>
        /// GET /api/customers
        [HttpGet]
        public IEnumerable<CustomerDto> GetCustomers()
        {
            return _context.Customers.Include(c => c.MembershipType )
                .ToList()
                .Select(Mapper.Map<Customer, CustomerDto>);
        }

        /// <summary>
        /// Gets the customer.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="HttpResponseException"></exception>
        /// /api/customers/{id}
        public IHttpActionResult GetCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
                //throw new HttpResponseException(HttpStatusCode.NotFound);
                return NotFound();
            return Ok (Mapper.Map<Customer, CustomerDto>(customer));

        }
        /// <summary>
        /// Creates the customer.
        /// </summary>
        /// <param name="customerDto">The customer.</param>
        /// <returns></returns>
        /// <exception cref="HttpResponseException"></exception>
        /// /api/customers
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                //throw new HttpResponseException(HttpStatusCode.BadRequest);
                return BadRequest();


            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);
            _context.Customers.Add(customer);
            _context.SaveChanges();

            customerDto.Id = customer.Id;
            //return customerDto;
            return Created(new Uri(Request.RequestUri + "/" + customer.Id), customerDto);
        }
        /// <summary>
        /// Updates the customer.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="customerDto">The customer.</param>
        /// <exception cref="HttpResponseException">
        /// </exception>
        /// /api/customers/{id}
        [HttpPut]

        public void UpdateCustomer(int id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(customerDto, customerInDb);

            _context.SaveChanges();

        }

        /// <summary>
        /// Xóa một customer
        /// </summary>
        /// <param name="id"></param>
        //DELETE /api/customer/{id}
        [HttpDelete]
        public void DeleteCustomer(int id)
        {
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            _context.Customers.Remove(customerInDb);
            _context.SaveChanges();
        }
    }
}
