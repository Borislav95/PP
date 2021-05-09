using System;
using System.Collections.Generic;
using System.Text;

namespace GalaxyCatalog.Samples
{
    public interface List
    {
        int GetActiveInstances();

        string GetInnerList(string x);

    }
}
