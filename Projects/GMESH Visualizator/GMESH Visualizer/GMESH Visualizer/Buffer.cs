using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GMESH_Visualizer
{
    public class Buffer
    {
        static Buffer instance = null;
        static private Buffer()
        { }
        static Buffer getInstance()
        {
            if (instance == null)
                instance = new Buffer();
            return instance;
        } 
    }
}
