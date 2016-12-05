﻿using System.Collections.Generic;
using System.Linq;

namespace CarShop
{
    class Car
    {

        private readonly string make;
        private readonly string model;
        private readonly Engine engine;
        private readonly IEnumerable<Seat> seats;

        public Car(string make, string model, Engine engine, IEnumerable<Seat> seats)
        {
            this.make = make;
            this.model = model;
            this.engine = engine;
            this.seats = new List<Seat>(seats);
        }

        public CarRegistration Register()
        {
            return new CarRegistration(this.make.ToUpper(), this.model,
                                       this.engine.CylinderVolume,
                                       this.seats.Sum(seat => seat.Capacity));
        }

        public void Accept(ICarVisitor visitor)
        {
            visitor.Visit(this);
            this.engine.Accept(visitor);
            foreach (Seat seat in this.seats)
                seat.Accept(visitor);
        }
    }
}