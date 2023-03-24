using _02_Forms.Contexts;
using _02_Forms.Models;
using _02_Forms.Models.Entities;
using _02_Forms.Models.Forms;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq.Expressions;

namespace _02_Forms.Services;

public class CustomerService
{
    private readonly DataContext _context;

    public CustomerService(DataContext context)
    {
        _context = context;
    }


    public async Task<bool> CreateAsync(CustomerRegistratonForm form)
    {
        try
        {
            var customerEntity = new CustomerEntity
            {
                FirstName = form.FirstName,
                LastName = form.LastName,
                Email = form.Email
            };

            customerEntity.CreateSecurePassword(form.Password);

            _context.Add(customerEntity);
            await _context.SaveChangesAsync();
            return true;
        } 
        catch (Exception ex) 
        { 
            Debug.WriteLine(ex.Message); 
            return false; 
        }
    }

    public async Task<IEnumerable<Customer>> GetAllAsync()
    {
        var customers = new List<Customer>();
        var list = await _context.Customers.ToListAsync();
        
        foreach(var customer in list)
        {
            customers.Add(new Customer
            {
                Id = customer.Id,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Email = customer.Email
            });
        }

        return customers;
    }
    
    public async Task<Customer> GetAsync(Expression<Func<CustomerEntity, bool>> predicate)
    {
        var customer = await _context.Customers.FirstOrDefaultAsync(predicate);
       
        if (customer != null) 
        {
            return new Customer
            {
                Id = customer.Id,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Email = customer.Email
            };
        }

        return null!;

    }  
}
