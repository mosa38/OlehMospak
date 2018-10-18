using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            User user = new User();
            Menu(user);
        }
        static public void Menu(User user)
        {
            Console.Clear();
            Console.WriteLine("Лабораторная работа №1 Сделал:Мосьпак Олег Группа:IC-63 Вариант:12");
            Console.WriteLine("Задание: Реализовать задачу создания различных геометрических фигур. Должно быть реализовано создание нескольких фигур с различными характеристиками");
            Console.WriteLine("Выберите любую фигуру, которую хотите сделать");
            Console.WriteLine("1. Квадрат");
            Console.WriteLine("2. Круг");
            Console.WriteLine("3. Треугольник");
            Console.WriteLine("4. Выход");
            Console.Write("\n" + "Введите команду: ");
            FigureBuilder builder = new KvadratFigureBuilder();
            char ch = char.Parse(Console.ReadLine());
            switch (ch)
            {
                case '1':
                    Console.Clear();
                    builder = new KvadratFigureBuilder();
                    Figure kvadratFigure = user.Look(builder);
                    Console.WriteLine(kvadratFigure.ToString());
                    Console.Write("Нажмите Enter для выхода");
                    Console.ReadLine();
                    Menu(user);
                    break;
                case '2':
                    Console.Clear();
                    builder = new KrugFigureBuilder();
                    Figure krugFigure = user.Look(builder);
                    Console.WriteLine(krugFigure.ToString());
                    Console.Write("Нажмите Enter для выхода");
                    Console.ReadLine();
                    Menu(user);
                    break;
                case '3':
                    Console.Clear();
                    builder = new TreugolnikFigureBuilder();
                    Figure treugolnikFigure = user.Look(builder);
                    Console.WriteLine(treugolnikFigure.ToString());
                    Console.Write("Нажмите Enter для выхода");
                    Console.ReadLine();
                    Menu(user);
                    break;
                case '4':
                    return;

            }
        }
    }
    abstract class FigureBuilder
    {
        public Figure Figure { get; private set; }
        public void CreateFigure()
        {
            Figure = new Figure();
        }
        public abstract void SetType();
        public abstract void SetStorona();
        public abstract void SetPerimetr();
        public abstract void SetPlosha();
    }
    class User
    {
        public Figure Look(FigureBuilder FigureBuilder)
        {
            FigureBuilder.CreateFigure();
            FigureBuilder.SetType();
            FigureBuilder.SetStorona();
            FigureBuilder.SetPerimetr();
            FigureBuilder.SetPlosha();
            return FigureBuilder.Figure;
        }
    }
    class KvadratFigureBuilder : FigureBuilder
    {
        private int a = 3;
        public override void SetType()
        {
            this.Figure.Type = new Type { type = "Квадрат:" };
        }

        public override void SetStorona()
        {
            this.Figure.Storona = new Storona { storona = "Сторона - " + a };
        }
        public override void SetPerimetr()
        {
            this.Figure.Perimetr = new Perimetr { perimetr = "Периметр - " + (4 * a) };
        }
        public override void SetPlosha()
        {
            this.Figure.Plosha = new Plosha { plosha = "Площадь - " + (Math.Pow(a, 2)) };
        }

    }
    class KrugFigureBuilder : FigureBuilder
    {
        private double pi = 3.14;
        private int r = 3;
        private int d = 4;
        public override void SetType()
        {
            this.Figure.Type = new Type { type = "Круг:" };
        }
        public override void SetStorona()
        {
            this.Figure.Storona = new Storona { storona = "Радиус - " + r + "\nДиаметр - " + d };
        }
        public override void SetPerimetr()
        {
            this.Figure.Perimetr = new Perimetr { perimetr = "Периметр - " + (2 * pi * r) };
        }
        public override void SetPlosha()
        {
            this.Figure.Plosha = new Plosha { plosha = "Площадь - " + (pi * Math.Pow(r, 2)) };
        }
    }
    class TreugolnikFigureBuilder : FigureBuilder
    {
        private int a = 3;
        private int b = 4;
        private int c = 5;
        public override void SetType()
        {
            this.Figure.Type = new Type { type = "Треугольник:" };
        }
        public override void SetStorona()
        {
            this.Figure.Storona = new Storona { storona = "Катет 1 - " + a + "\nКатет 2 - " + b + "\nГипотенуза - " + c };
        }
        public override void SetPerimetr()
        {
            this.Figure.Perimetr = new Perimetr { perimetr = "Периметр - " + (a + b + c) };
        }
        public override void SetPlosha()
        {
            this.Figure.Plosha = new Plosha { plosha = "Площадь - " + (a * b / 2) };
        }
    }
}

