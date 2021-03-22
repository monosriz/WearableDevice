using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WearableDevice.Model.Model;

namespace WearableDevice.Repository.Context
{
   public class WearableDeviceDBContext : DbContext
    {

        public WearableDeviceDBContext(DbContextOptions options)
          : base(options)
        {
        }

        public DbSet<Activation> Activations { get; set; }

    }
}
