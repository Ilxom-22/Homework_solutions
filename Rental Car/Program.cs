﻿namespace Rental;

class Program
{
    static async Task Main(string[] args)
    {
        var rental = new CarRentalManagement();

        var x5 = new BMW("X5");
        var x7 = new BMW("X7");
        var ix = new BMW("iX");

        var a6 = new Audi("A6");
        var a8 = new Audi("A8");
        var q8Etron = new Audi("Q8 e-tron");

        rental.Add(x5);
        rental.Add(x7);
        rental.Add(ix);

        rental.Add(a6);
        rental.Add(a8);
        rental.Add(q8Etron);

        var rentedCar1 = rental.Rent("x5");
        if (rentedCar1 != null)
        {
            await Task.Delay(1000 * 1);
            rental.Return(rentedCar1);
        }

        var rentedCar2 = rental.Rent("Q8 e-tron");
        if (rentedCar2 != null)
        {
            await Task.Delay(1000 * 3);
            rental.Return(rentedCar2);
        }
       

        Console.WriteLine(rental.CalculateBalance().ToString("C"));
    }
}