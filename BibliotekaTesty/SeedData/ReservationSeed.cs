using Biblioteka.Models;
using System;
using System.Collections.Generic;

namespace BibliotekaTesty.SeedData
{
    public static class ReservationSeed
    {
        public static List<Reservation> reservations = new List<Reservation>
        {
            new Reservation{ ReservationId = 111, ReservationDate = DateTime.Now, User = UserSeed.users[0]},
            new Reservation{ ReservationId = 222, ReservationDate = DateTime.Now, User = new User{ Id ="123", FristName ="user1" } },
        };
    }
}
