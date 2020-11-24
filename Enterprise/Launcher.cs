using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        double salary = 100;
        int percent = 60;
        salary = salary + ((double)(percent) / 100) * (salary);
        salary = salary + (percent / 100) * (salary);
        salary += (salary * percent) / 100;

        Console.WriteLine(salary);
    }
}
