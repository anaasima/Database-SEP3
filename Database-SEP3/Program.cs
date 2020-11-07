using System;
using System.Threading.Tasks;
using Database_SEP3.Persistence.Model;
using Database_SEP3.Persistence.Repositories;

namespace Database_SEP3
{
    class Program
    {
        static void Main(string[] args)
        {
            ComponentRepo c1 = new ComponentRepo();
            //c1.createComponent();
            c1.readComponent();
        }
    }
}