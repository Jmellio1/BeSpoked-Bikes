using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BeSpoked_Bikes.Data;
using BeSpoked_Bikes.Models;

namespace BeSpoked_Bikes.Data
{
    public class CustomerController : ICustomerController
    {
        private readonly ApplicationDbContext _context;


        public  CustomerController(ApplicationDbContext context) { _context = context; }

        public async Task<int> Create(Customer customer)
        {

            _context.Add(customer);
            return await _context.SaveChangesAsync();
        }
        public async Task<List<Customer>> List()
        {
            return await _context.Customer.ToListAsync();
        }
    }
    public interface ICustomerController
    {
        Task<int> Create(Customer customer);
        Task<List<Customer>> List();
    }
}
