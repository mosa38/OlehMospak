using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    class Program
    {

        static void Main(string[] args)
        {
            int key = 1;
            int key1 = 1;
            Wiki wiki = new Wiki();
            Article article = new Article();
            Wiki1 wiki1 = new Wiki1();
            Article1 article1 = new Article1();


            Menu(wiki, article, key, key1, wiki1, article1);
        }
        static public void Menu(Wiki wiki, Article article, int key, int key1, Wiki1 wiki1, Article1 article1)
        {
            Console.Clear();
            Console.WriteLine("Лабораторная работа №3 Сделал:Мосьпак Олег Группа:IC-63 Вариант:12");
            Console.WriteLine("Задание: Существует набор статей в википедии. Реализовать процесс раздачи статей по требованию для изменения, сохраняя исходный вариант для возможного восстановления статьи в исходном виде");
            Console.WriteLine("Википедия. Выберите статью:");
            Console.WriteLine("1. Статья 1");
            Console.WriteLine("2. Статья 2");
            Console.WriteLine("3. Выход");
            Console.Write("\n" + "Введите команду: ");
            char ch = char.Parse(Console.ReadLine());

            switch (ch)
            {
                case '1':
                    Console.Clear();
                    if (key == 1)
                        wiki.History.Push(article.SaveState());
                    else
                        Console.WriteLine("Текст текущей статьи: " + article.text);
                    key++;
                    FragmentMenu();
                    char k = char.Parse(Console.ReadLine());
                    switch (k)
                    {
                        case '1':
                            Console.Clear();
                            article.Change();
                            Console.WriteLine();
                            Console.Write("Нажмите Enter для выхода");
                            Console.ReadLine();
                            Menu(wiki, article, key, key1, wiki1, article1);
                            break;
                        case '2':
                            wiki.History.Push(article.SaveState());
                            goto case '4';
                        case '3':
                            Console.Clear();
                            article.RestoreState(wiki.History.Pop());
                            Console.Write("Нажмите Enter для выхода");
                            Console.ReadLine();
                            Menu(wiki, article, key, key1, wiki1, article1);
                            break;
                        case '4':
                            Menu(wiki, article, key, key1, wiki1, article1);
                            break;
                    }
                    break;
                case '2':
                    Console.Clear();
                    if (key1 == 1)
                        wiki1.History1.Push(article1.SaveState1());
                    else
                        Console.WriteLine("Текст текущей статьи: " + article1.text1);
                    key1++;
                    FragmentMenu();
                    char k1 = char.Parse(Console.ReadLine());
                    switch (k1)
                    {
                        case '1':
                            Console.Clear();
                            article1.Change1();
                            Console.WriteLine();
                            Console.Write("Нажмите Enter для выхода");
                            Console.ReadLine();
                            Menu(wiki, article, key, key1, wiki1, article1);
                            break;
                        case '2':
                            wiki1.History1.Push(article1.SaveState1());
                            goto case '4';
                        case '3':
                            Console.Clear();
                            article1.RestoreState1(wiki1.History1.Pop());
                            Console.Write("Нажмите Enter для выхода");
                            Console.ReadLine();
                            Menu(wiki, article, key, key1, wiki1, article1);
                            break;
                        case '4':
                            Menu(wiki, article, key, key1, wiki1, article1);
                            break;
                    }
                    break;
                case '3':
                    return;
            }
        }
        static public void FragmentMenu()
        {
            Console.Write("1-Изменить    ");
            Console.Write("2-Сохранить     ");
            Console.Write("3-Предыдущая версия   ");
            Console.WriteLine("4-Назад    ");
            Console.Write("\n" + "Введите команду: ");
        }
    }

    class Article
    {
        public string text = "Здесь должен быть текст первой статьи";

        public void Change()
        {
            if (text != null)
            {
                Console.WriteLine("Ввести новый текст: ");
                text = Console.ReadLine();
                Console.WriteLine("Сейчас первая статья такая: " + text);
            }
            else
                Console.WriteLine("Ошибка, текст не был введен");
        }
        public ArticleMemento SaveState()
        {
            Console.WriteLine("Cейчас текст такой\n{0}", text);
            return new ArticleMemento(text);
        }

        public void RestoreState(ArticleMemento memento)
        {
            this.text = memento.Text;
            Console.WriteLine("Восстановление статьи. Теперь текст такой\n{0}", text);
        }
    }
    class ArticleMemento
    {
        public string Text { get; private set; }

        public ArticleMemento(string text)
        {
            this.Text = text;
        }
    }

    class Wiki
    {
        public Stack<ArticleMemento> History { get; private set; }
        public Wiki()
        {
            History = new Stack<ArticleMemento>();
        }
    }
    class Memento
    {
        public string State { get; private set; }
        public Memento(string state)
        {
            this.State = state;
        }
    }

    class Caretaker
    {
        public Memento Memento { get; set; }
    }

    class Originator
    {
        public string State { get; set; }
        public void SetMemento(Memento memento)
        {
            State = memento.State;
        }
        public Memento CreateMemento()
        {
            return new Memento(State);
        }
    }
    class Article1
    {
        public string text1 = "Здесь должен быть текст второй статьи";

        public void Change1()
        {
            if (text1 != null)
            {
                Console.WriteLine("Ввести новый текст: ");
                text1 = Console.ReadLine();
                Console.WriteLine("Сейчас вторая статья такая: " + text1);
            }
            else
                Console.WriteLine("Ошибка, текст не был введен");
        }
        public ArticleMemento1 SaveState1()
        {
            Console.WriteLine("Cейчас текст такой\n{0}", text1);
            return new ArticleMemento1(text1);
        }

        public void RestoreState1(ArticleMemento1 memento)
        {
            this.text1 = memento.Text1;
            Console.WriteLine("Восстановление статьи. Теперь текст такой\n{0}", text1);
        }
    }
    class ArticleMemento1
    {
        public string Text1 { get; private set; }

        public ArticleMemento1(string text1)
        {
            this.Text1 = text1;
        }
    }

    class Wiki1
    {
        public Stack<ArticleMemento1> History1 { get; private set; }
        public Wiki1()
        {
            History1 = new Stack<ArticleMemento1>();
        }
    }
    class Memento1
    {
        public string State1 { get; private set; }
        public Memento1(string state1)
        {
            this.State1 = state1;
        }
    }

    class Caretaker1
    {
        public Memento1 Memento1 { get; set; }
    }

    class Originator1
    {
        public string State1 { get; set; }
        public void SetMemento1(Memento1 memento)
        {
            State1 = memento.State1;
        }
        public Memento1 CreateMemento1()
        {
            return new Memento1(State1);
        }
    }
}
