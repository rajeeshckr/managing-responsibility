﻿namespace CarShop
{
    interface ICarPartVisitor
    {
        void Visit(Engine engine);
        void Visit(Seat seat);
    }
}
