using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UNOPS.Passenger
{
    public enum Alphabet { a,b,c,d,e,f}
    public class Seat
    {
        public int RowId { set; get; }
        public Alphabet Alphabet { set; get; }
        public SeatType SeatType { set; get; }
        public bool IsSeated { set; get; } 
    }
}
