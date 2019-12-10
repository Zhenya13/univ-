using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    public interface IStorageController
    {
        List<User> ReadData();
        void WriteData(List<User> users);
    }
}
