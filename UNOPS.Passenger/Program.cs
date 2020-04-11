using System;
using System.Collections.Generic;
using System.Linq;

namespace UNOPS.Passenger
{
    /*
    ===================================PLEASE DO READ THIS=================================
    I am not totally certain what the problem is exactly.
    This is based on what I understand the problem statement
    1. we have number of passengers on hands
    2. we also have number of seats on hand (6 seats per one row)
    3. Each passenger has his/her Membership and the prefered seat
    4. Each seat has its position (middle, window or aisle)
    5. the feedback point is calulated on the matching between the passenger's prefered seat and seat he/she later acquired
    6. the caluation is stated in the problem, the Gold passenger will score higher feedback point if he/she get the desired seat
    7. penalty will be enforced if any passenger left behind(also depend on what membership type he/she is)
     * */
    class Program
    {
        static List<Passenger> passengers = new List<Passenger>();
        static List<Seat> seats = new List<Seat>();
        static int NO_OR_ROW = 20;
        static int NO_OF_PASSENGERS = 100;
        static void Main(string[] args)
        {
            Console.WriteLine("No of Passengers " + NO_OF_PASSENGERS.ToString());
            Console.WriteLine("No of Seats " + (NO_OR_ROW * 6).ToString());

            // create passengers and seats
            CreatePassengers(NO_OF_PASSENGERS);
            CreateSeats(NO_OR_ROW);
            
            int feedback = 0;
            int time2Board = 0;
            
            foreach (Passenger passenger in passengers)
            {
                // find time to board for each passenger
                time2Board = time2Board + Timer.PassengerTime(passenger);

                // check if there is any available seat left
                if (seats.FirstOrDefault(p => p.IsSeated == false) != null)
                {
                    // if so, get the seat and give to passenger
                    Seat seatAcuired = MatchMaker.GetBestSeat(passenger, seats);
                    // get the feedback point
                    feedback = feedback + MatchMaker.FindFeedback(passenger, seatAcuired);
                    passenger.AcquiredSeat = seatAcuired;
                }
                else
                {
                    break;
                }
            }

            // find penalty, in case there is passenger with no seat given
            passengers.Where(p => p.AcquiredSeat == null).ToList().ForEach(p =>
            {
                feedback = feedback + MatchMaker.findPenalty(p);
            });

            // find time for crew to close the storage
            time2Board = time2Board + Timer.CrewTime(passengers);

            Console.WriteLine("FeedBack is " + feedback.ToString());

            Console.WriteLine("Time to Board is " + time2Board + " seconds");

            Console.ReadKey();
        }

        static void CreatePassengers(int noPassengers)
        {
            passengers.Clear();
            for (int i = 1; i <= noPassengers; i++)
            {
                int memberType = new Random().Next(3);
                int seatPrefered = new Random().Next(3);
                int hasCarryOn = new Random().Next(2);
                passengers.Add(new Passenger
                {
                    Id = Guid.NewGuid().ToString()
                    ,
                    MembershipType = (MemberType)memberType
                    ,                    
                    SeatPreferedType = (SeatType)seatPrefered
                    ,
                    AcquiredSeat = null
                    , 
                    HasCarryOn = Convert.ToBoolean(hasCarryOn)
                }); 
            }
        }

        static void CreateSeats(int noRows)
        {
            seats.Clear();
            for (int i = 1; i <= noRows; i++)
            {
                for(int j=1; j <= 6; j++)
                {
                    if (j==1)
                    {
                        seats.Add(new Seat
                        {
                            RowId = i,
                            SeatType = SeatType.window,
                            Alphabet = Alphabet.a,
                            IsSeated = false
                        }); ;
                    }
                    else if (j == 2)
                    {
                        seats.Add(new Seat
                        {
                            RowId = i,
                            SeatType = SeatType.middle,
                            Alphabet = Alphabet.b,
                            IsSeated = false
                        });
                    }
                    else if (j == 3)
                    {
                        seats.Add(new Seat
                        {
                            RowId = i,
                            SeatType = SeatType.aisle,
                            Alphabet = Alphabet.c,
                            IsSeated = false
                        });
                    }
                    else if (j == 4)
                    {
                        seats.Add(new Seat
                        {
                            RowId = i,
                            SeatType = SeatType.aisle,
                            Alphabet = Alphabet.d,
                            IsSeated = false
                        });
                    }
                    else if (j == 5)
                    {
                        seats.Add(new Seat
                        {
                            RowId = i,
                            SeatType = SeatType.middle,
                            Alphabet = Alphabet.e,
                            IsSeated = false
                        });
                    }
                    else if (j == 6)
                    {
                        seats.Add(new Seat
                        {
                            RowId = i,
                            SeatType = SeatType.window,
                            Alphabet = Alphabet.f,
                            IsSeated = false
                        });
                    }
                    else
                    {
                        throw new NotImplementedException();
                    }
                }
            }
        }
    }
}
