﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Owin;

namespace s00143451webapp
{
    public class StartUp
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }
}


