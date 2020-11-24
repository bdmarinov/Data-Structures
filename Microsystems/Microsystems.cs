using System;
using System.Collections.Generic;
using System.Linq;

public class Microsystems : IMicrosystem
{
    Dictionary<int, Computer> computersById;
    int count;

    public Microsystems()
    {
        computersById = new Dictionary<int, Computer>();
        count = 0;
    }
    public bool Contains(int number)
    {
        return computersById.ContainsKey(number);
    }

    public int Count()
    {
        return count;
    }

    public void CreateComputer(Computer computer)
    {
        if(computersById.ContainsKey(computer.Number))
        {
            throw new ArgumentException();
        }
        computersById.Add(computer.Number, computer);
        count++;
    }

    public IEnumerable<Computer> GetAllFromBrand(Brand brand)
    {
        return computersById.Values.Where(x => x.Brand == brand).OrderByDescending(x => x.Price);
    }

    public IEnumerable<Computer> GetAllWithColor(string color)
    {
        return computersById.Values.Where(x => x.Color == color).OrderByDescending(x => x.Price);
    }

    public IEnumerable<Computer> GetAllWithScreenSize(double screenSize)
    {
        return computersById.Values.Where(x => x.ScreenSize == screenSize).OrderByDescending(x => x.Number);
    }

    public Computer GetComputer(int number)
    {
        if(!computersById.ContainsKey(number))
        {
            throw new ArgumentException();
        }
        return computersById[number];
    }

    public IEnumerable<Computer> GetInRangePrice(double minPrice, double maxPrice)
    {
        return computersById.Values.Where(x => (x.Price >= minPrice && x.Price <= maxPrice)).OrderByDescending(x => x.Price);
    }

    public void Remove(int number)
    {
        if(!computersById.ContainsKey(number))
        {
            throw new ArgumentException();
        }
        computersById.Remove(number);
        count--;
    }

    public void RemoveWithBrand(Brand brand)
    {
        List<int> numbers = computersById.Values.Where(x => x.Brand == brand).Select(x => x.Number).ToList();
        
        if(numbers.Count == 0)
        {
            throw new ArgumentException();
        }

        for(int i = 0; i < numbers.Count; i++)
        {
            computersById.Remove(numbers[i]);
            count--;
        }
    }

    public void UpgradeRam(int ram, int number)
    {
        if(!computersById.ContainsKey(number))
        {
            throw new ArgumentException();
        }
        if(ram > computersById[number].RAM)
        {
            computersById[number].RAM = ram;
        }
    }
}
