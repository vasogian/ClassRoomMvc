using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ClassRoomMvc.Models;

namespace ClassRoomMvc.Data
{
    public class ClassRoomMvcContext : DbContext
    {
        public ClassRoomMvcContext (DbContextOptions<ClassRoomMvcContext> options)
            : base(options)
        {
        }

        public DbSet<ClassRoomMvc.Models.Assignment> Assignment { get; set; } = default!;

        public DbSet<ClassRoomMvc.Models.Student>? Student { get; set; }

        public DbSet<ClassRoomMvc.Models.Teacher>? Teacher { get; set; }

        public DbSet<ClassRoomMvc.Models.ClassRoom>? ClassRoom { get; set; }
    }
}
