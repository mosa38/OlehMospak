using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Лабораторная работа №2 Сделал:Мосьпак Олег Группа:IC-63 Вариант:12");
            Console.WriteLine("Задание: Реализовать задачу «Пассажироперевозчики (транспортные средства)». Реализовать транспорт в зависимости от расстояния и наличия путей сообщения\n");
            Driver driver = new Driver();
            Bus bus = new Bus();
            driver.Travel(bus);
            Taxi taxi = new Taxi();
            driver.Travel(taxi);
            Air air = new Air();
            Earth airTransport = new AirToWaterAdapter(air);
            driver.Travel(airTransport);
            Ship ship = new Ship();
            Earth shipTransport = new ShipToWaterAdapter(ship);
            driver.Travel(shipTransport);

            Console.Read();
        }
    }
    interface Earth
    {
        void Drive();
    }
    class Bus : Earth
    {
        public void Drive()
        {
            Console.WriteLine("Автобус едет по дороге(далеко)");
        }
    }
    class Taxi : Earth
    {
        public void Drive()
        {
            Console.WriteLine("Такси едет по дороге(не далеко)");
        }
    }
    class Driver
    {
        public void Travel(Earth ea)
        {
            ea.Drive();
        }
    }
    interface Water
    {
        void Move();
    }
    class Air : Water
    {
        public void Move()
        {
            Console.WriteLine("Человек летит в самолете через воду(далеко)");
        }
    }
    class Ship : Water
    {
        public void Move()
        {
            Console.WriteLine("Человек едет на корабле по воде(не далеко)");
        }
    }
    class AirToWaterAdapter : Earth
    {
        Air lgdistance;
        public AirToWaterAdapter(Air air)
        {
            lgdistance = air;
        }

        public void Drive()
        {
            lgdistance.Move();
        }
    }
    class ShipToWaterAdapter : Earth
    {
        Ship lgdistance;
        public ShipToWaterAdapter(Ship ship)
        {
            lgdistance = ship;
        }

        public void Drive()
        {
            lgdistance.Move();
        }
    }
    class Client
    {
        public void Request(Target target)
        {
            target.Request();
        }
    }
    // класс, к которому надо адаптировать другой класс   
    class Target
    {
        public virtual void Request()
        { }
    }
    // Адаптер
    class Adapter : Target
    {
        private Adaptee adaptee = new Adaptee();

        public override void Request()
        {
            adaptee.SpecificRequest();
        }
    }
    // Адаптируемый класс
    class Adaptee
    {
        public void SpecificRequest()
        { }
    }
}
