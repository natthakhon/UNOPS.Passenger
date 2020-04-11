using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UNOPS.Passenger
{
    public class Timer
    {
        public static int PassengerTime(Passenger passenger)
        {
            if (passenger.HasCarryOn)
            {
                return 90;
            }
            else if (!passenger.HasCarryOn)
            {
                return 70;
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        public static int CrewTime(IList<Passenger> passengers)
        {
            int result = 0;
            List<int> ints = new List<int>();
            var grouping = passengers.Where(p => p.AcquiredSeat != null)
                .GroupBy(p => p.AcquiredSeat.RowId);

            foreach (var g in grouping)
            {
                if(g.FirstOrDefault(p => p.AcquiredSeat.Alphabet == Alphabet.a ||
                                    p.AcquiredSeat.Alphabet == Alphabet.b ||
                                    p.AcquiredSeat.Alphabet == Alphabet.c) != null)
                {
                    result++;
                }
                if (g.FirstOrDefault(p => p.AcquiredSeat.Alphabet == Alphabet.d ||
                                     p.AcquiredSeat.Alphabet == Alphabet.e ||
                                     p.AcquiredSeat.Alphabet == Alphabet.f) != null)
                {
                    result++;
                }
            }

            return result *5;
        }
    }
}
