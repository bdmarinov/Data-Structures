using System;
using System.Collections.Generic;
using System.Linq;

public class Agency : IAgency
{
    Dictionary<string, Invoice> invoicesByName;
    List<string> numbersToClear;
    int count;
    
    public Agency()
    {
        invoicesByName = new Dictionary<string, Invoice>();
        numbersToClear = new List<string>();
        count = 0;
    }
    public bool Contains(string number)
    {
        return invoicesByName.ContainsKey(number);
    }

    public int Count()
    {
        return count;
    }

    public void Create(Invoice invoice)
    {
        if(invoicesByName.ContainsKey(invoice.SerialNumber))
        {
            throw new ArgumentException();
        }
        invoicesByName.Add(invoice.SerialNumber, invoice);
        count++;
    }

    public void ExtendDeadline(DateTime dueDate, int days)
    {
        List<Invoice> invoices = invoicesByName.Values.Where(x => x.DueDate == dueDate).ToList();
        if(invoices.Count == 0)
        {
            throw new ArgumentException();
        }
        for(int i = 0; i < invoices.Count; i++)
        {
            invoices[i].DueDate = invoices[i].DueDate.AddDays(days);
        }
    }

    public IEnumerable<Invoice> GetAllByCompany(string company)
    {
        return invoicesByName.Values.Where(x => x.CompanyName == company).OrderByDescending(x => x.SerialNumber);
    }

    public IEnumerable<Invoice> GetAllFromDepartment(Department department)
    {
        return invoicesByName.Values.Where(x => x.Department == department).OrderByDescending(x => x.Subtotal).ThenBy(x => x.IssueDate);
    }

    public IEnumerable<Invoice> GetAllInvoiceInPeriod(DateTime start, DateTime end)
    {
        return invoicesByName.Values.Where(x => (x.IssueDate >= start && x.IssueDate <= end)).OrderBy(x => x.DueDate).OrderBy(x => x.IssueDate);
    }

    public void PayInvoice(DateTime due)
    {
        List<Invoice> invoices = invoicesByName.Values.Where(x => x.DueDate == due).ToList();
        if(invoices.Count == 0)
        {
            throw new ArgumentException();
        }
        for(int i = 0; i< invoices.Count; i++)
        {
            invoices[i].Subtotal = 0;
            numbersToClear.Add(invoices[i].SerialNumber);
        }
    }

    public IEnumerable<Invoice> SearchBySerialNumber(string serialNumber)
    {
        List<Invoice> invoices = invoicesByName.Values.Where(x => x.SerialNumber.Contains(serialNumber)).ToList();
        if(invoices.Count == 0)
        {
            throw new ArgumentException();
        }
        
        return invoices.OrderByDescending(x => x.SerialNumber);
    }

    public void ThrowInvoice(string number)
    {
        if(!invoicesByName.ContainsKey(number))
        {
            throw new ArgumentException();
        }
        invoicesByName.Remove(number);
        count--;
    }

    public IEnumerable<Invoice> ThrowInvoiceInPeriod(DateTime start, DateTime end)
    {
        List<Invoice> invoices = invoicesByName.Values.Where(x => (x.DueDate > start && x.DueDate < end)).ToList();
        if(invoices.Count == 0)
        {
            throw new ArgumentException();
        }
        for(int i = 0; i < invoices.Count; i++)
        {
            invoicesByName.Remove(invoices[i].SerialNumber);
            count--;
        }
        return invoicesByName.Values;
    }

    public void ThrowPayed()
    {
        for(int i = 0; i < numbersToClear.Count; i++)
        {
            invoicesByName.Remove(numbersToClear[i]);
            count--;
        }
        numbersToClear.Clear();
    }
}
