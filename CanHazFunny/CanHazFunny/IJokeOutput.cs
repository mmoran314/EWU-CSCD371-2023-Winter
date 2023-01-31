using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CanHazFunny;

public interface IJokeOutput
{
    public void WriteJoke(string joke);
    
}
