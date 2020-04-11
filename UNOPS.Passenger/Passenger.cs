using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UNOPS.Passenger
{
    public enum MemberType { none,silver,gold}
    public enum SeatType { window,aisle,middle}
    public class Passenger
    {
        public string Id { set; get; }
        public MemberType MembershipType { set; get; }
        public SeatType SeatPreferedType { set; get; }
        public Seat AcquiredSeat { set; get; }
        public bool HasCarryOn { set; get; }
    }
}
