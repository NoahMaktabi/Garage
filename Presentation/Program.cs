using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Application;
using Domain;
using Domain.Vehicles;
using Newtonsoft.Json;
using Persistence;
using Presentation.Helpers;
using Presentation.Interfaces;

namespace Presentation
{
    public  class Program
    {
        private static async Task Main(string[] args)
        {
            await MenuRunner.Run();
            
            // Search test
            //var results = manager.FindParkedVehicles("volv");
        }
    }
}
