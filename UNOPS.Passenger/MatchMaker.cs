using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UNOPS.Passenger
{
    public class MatchMaker
    {
        public static int FindFeedback(Passenger passenger, Seat seat)
        {   
            if (passenger.MembershipType == MemberType.gold)
            {
                if (passenger.SeatPreferedType == seat.SeatType)
                {
                    return 3;
                }
                else
                {
                    return 1;
                }
            }
            else if (passenger.MembershipType == MemberType.silver)
            {
                if (passenger.SeatPreferedType == seat.SeatType)
                {
                    return 2;
                }
                else
                {
                    return 1;
                }
            }
            else if (passenger.MembershipType == MemberType.none)
            {
                if (passenger.SeatPreferedType == seat.SeatType)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        public static int findPenalty(Passenger passenger)
        {
            if (passenger.MembershipType == MemberType.gold)
            {
                return -5;
            }
            else if (passenger.MembershipType == MemberType.silver ||
                passenger.MembershipType == MemberType.none)
            {
                return -3;
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        public static Seat GetBestSeat(Passenger passenger, List<Seat> seats)
        {            
            Seat seat = null;
            
            if (seats.FirstOrDefault(p => p.IsSeated == false && p.SeatType == passenger.SeatPreferedType) != null)
            {
                seat = seats.FirstOrDefault(p => p.IsSeated == false && p.SeatType == passenger.SeatPreferedType);
            }
            else if(seats.FirstOrDefault(p => p.IsSeated == false) != null)
            {
                seat = seats.FirstOrDefault(p => p.IsSeated == false);
            }

            seats.FirstOrDefault(p => p.RowId == seat.RowId && p.Alphabet == seat.Alphabet).IsSeated = true;

            return seat;
        }
    }
}
