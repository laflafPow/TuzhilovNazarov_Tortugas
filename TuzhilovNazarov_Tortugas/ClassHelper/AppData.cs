﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuzhilovNazarov_Tortugas.ClassHelper
{
    class AppData
    {
        public static EF.Entities Context { get; } = new EF.Entities();
    }
}
