namespace WebApplication3.Models
{
    using System;
    using System.Collections.Generic;
    public class EmployeeT
    {
        public int Id { get; set; }
        public string EmployeeName { get; set; }
        public string Surname { get; set; }
        public string Position { get; set; }
        public string Office { get; set; }
        public int Salary { get; set; }
    }
    public class CustomerT
    {
        public int CId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerSurname { get; set; }
        public string CustomerPhone { get; set; }
    }
    public class OrderT
    {
        public int OrderId { get; set; }
        public int TotalAmount { get; set; }
        public int CustId { get; set; }
        public string CustName { get; set; }
        public string CustSurname { get; set; }
    }
    public class ProductT
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
    }
}