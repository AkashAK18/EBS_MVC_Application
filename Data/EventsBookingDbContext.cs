using System;
using System.Collections.Generic;
using EventBookingSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace EventBookingSystem.Data;

public partial class EventsBookingDbContext : DbContext
{
    public EventsBookingDbContext(DbContextOptions<EventsBookingDbContext> options)
        : base(options)
    {
        
    }

    public DbSet<Booking> Bookings { get; set; }

    public DbSet<Event> Events { get; set; }

    public DbSet<User> Users { get; set; }
}
