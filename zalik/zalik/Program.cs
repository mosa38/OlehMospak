using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace zalik
{
    class Program
    {
        static string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=task1;Integrated Security=True";
        static void Main(string[] args)
        {
            Menu();
            Console.Read();
        }
        static public void Menu()
        {
            Console.Clear();
            Console.WriteLine("Зачет Сделал:Мосьпак Олег Группа:IC-63 Вариант:8");
            Console.WriteLine("Выберите таблицу:");
            Console.WriteLine("1. Pogoda(Погода)");
            Console.WriteLine("2. Region(Регион)");
            Console.WriteLine("3. People(Люди)");
            Console.WriteLine("4. Запросы");
            Console.WriteLine("5. Выход");
            Console.Write("\n" + "Введите команду: ");
            char ch = char.Parse(Console.ReadLine());

            switch (ch)
            {
                case '1':
                    Console.Clear();
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        string sql = "SELECT * FROM Pogoda";
                        SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                        DataSet ds = new DataSet();
                        adapter.Fill(ds);

                        DataTable dt = ds.Tables[0];
                        foreach (DataColumn column in dt.Columns)
                            Console.Write("{0,-18}", column.ColumnName);
                        Console.WriteLine();
                        foreach (DataRow row in dt.Rows)
                        {
                            var cells = row.ItemArray;
                            foreach (object cell in cells)
                                Console.Write("{0,-18}", cell);
                            Console.WriteLine();
                        }
                        FragmentMenu();
                        string sqlExpression, pole, val;
                        int number;
                        char k = char.Parse(Console.ReadLine());
                        switch (k)
                        {
                            case '1':
                                Console.WriteLine("Введите значения для нового поля:");
                                DataRow newRow = dt.NewRow();
                                Console.Write("RegionId="); newRow["RegionId"] = Convert.ToInt32(Console.ReadLine());
                                Console.Write("Day="); newRow["Day"] = Console.ReadLine();
                                Console.Write("Temperature="); newRow["Temperature"] = Convert.ToInt32(Console.ReadLine());
                                Console.Write("Opadi="); newRow["Opadi"] = Console.ReadLine();
                                dt.Rows.Add(newRow);
                                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(adapter);
                                adapter.Update(ds);
                                ds.Clear();
                                adapter.Fill(ds);
                                Console.Write("Нажмите Enter для выхода");
                                Console.ReadLine();
                                break;
                            case '2':
                                Console.Write("Введите Id по которому будем менять значения: ");
                                int help = Convert.ToInt32(Console.ReadLine());
                                Console.Write("\nВведите поле которое будем менять: ");
                                pole = Console.ReadLine();
                                Console.Write("\nВведите новое значение: ");
                                val = Console.ReadLine();
                                if (pole == "RegionId" || pole == "Temperature")
                                {
                                    int val1 = Convert.ToInt32(val);
                                    sqlExpression = "UPDATE Pogoda SET " + pole + "=" + val1 + " WHERE Id=" + help;
                                }
                                else sqlExpression = "UPDATE Pogoda SET " + pole + "='" + val + "' WHERE Id=" + help;
                                SqlCommand command = new SqlCommand(sqlExpression, connection);
                                number = command.ExecuteNonQuery();
                                Console.Write("Нажмите Enter для выхода");
                                Console.ReadLine();
                                break;
                            case '3':
                                Console.Write("\nВведите поле по которому будем удалять строку: ");
                                pole = Console.ReadLine();
                                Console.Write("\nВведите значение по которому будем удалять строку: ");
                                val = Console.ReadLine();
                                if (pole == "RegionId" || pole == "Temperature" || pole == "Id")
                                {
                                    int val1 = Convert.ToInt32(val);
                                    sqlExpression = "DELETE FROM Pogoda WHERE " + pole + "=" + val1;
                                }
                                else sqlExpression = "DELETE FROM Pogoda WHERE " + pole + "='" + val + "'";
                                SqlCommand command1 = new SqlCommand(sqlExpression, connection);
                                number = command1.ExecuteNonQuery();
                                Console.Write("Нажмите Enter для выхода");
                                Console.ReadLine();
                                break;
                            case '4':
                                break;
                        }
                    }
                    break;
                case '2':
                    Console.Clear();
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        string sql = "SELECT * FROM Region";
                        SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                        DataSet ds = new DataSet();
                        adapter.Fill(ds);

                        DataTable dt = ds.Tables[0];
                        foreach (DataColumn column in dt.Columns)
                            Console.Write("{0,-12}", column.ColumnName);
                        Console.WriteLine();
                        foreach (DataRow row in dt.Rows)
                        {
                            var cells = row.ItemArray;
                            foreach (object cell in cells)
                                Console.Write("{0,-12}", cell);
                            Console.WriteLine();
                        }
                        FragmentMenu();
                        string sqlExpression, pole, val;
                        int number;
                        char k = char.Parse(Console.ReadLine());
                        switch (k)
                        {
                            case '1':
                                Console.WriteLine("Введите значения для нового поля:");
                                DataRow newRow = dt.NewRow();
                                Console.Write("Name="); newRow["Name"] = Console.ReadLine();
                                Console.Write("Square="); newRow["Square"] = Convert.ToInt32(Console.ReadLine());
                                Console.Write("PeopleId="); newRow["PeopleId"] = Convert.ToInt32(Console.ReadLine());
                                dt.Rows.Add(newRow);
                                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(adapter);
                                adapter.Update(ds);
                                ds.Clear();
                                adapter.Fill(ds);
                                Console.Write("Нажмите Enter для выхода");
                                Console.ReadLine();
                                break;
                            case '2':
                                Console.Write("Введите Id по которому будем менять значения: ");
                                int help = Convert.ToInt32(Console.ReadLine());
                                Console.Write("\nВведите поле которое будем менять: ");
                                pole = Console.ReadLine();
                                Console.Write("\nВведите новое значение: ");
                                val = Console.ReadLine();
                                if (pole == "Square" || pole == "PeopleId")
                                {
                                    int val1 = Convert.ToInt32(val);
                                    sqlExpression = "UPDATE Region SET " + pole + "=" + val1 + " WHERE Id=" + help;
                                }
                                else sqlExpression = "UPDATE Region SET " + pole + "='" + val + "' WHERE Id=" + help;
                                SqlCommand command = new SqlCommand(sqlExpression, connection);
                                number = command.ExecuteNonQuery();
                                Console.Write("Нажмите Enter для выхода");
                                Console.ReadLine();
                                break;
                            case '3':
                                Console.Write("\nВведите поле по которому будем удалять строку: ");
                                pole = Console.ReadLine();
                                Console.Write("\nВведите значение по которому будем удалять строку: ");
                                val = Console.ReadLine();
                                if (pole == "Square" || pole == "PeopleId" || pole == "Id")
                                {
                                    int val1 = Convert.ToInt32(val);
                                    sqlExpression = "DELETE FROM Region WHERE " + pole + "=" + val1;
                                }
                                else sqlExpression = "DELETE FROM Region WHERE " + pole + "='" + val + "'";
                                SqlCommand command1 = new SqlCommand(sqlExpression, connection);
                                number = command1.ExecuteNonQuery();
                                Console.Write("Нажмите Enter для выхода");
                                Console.ReadLine();
                                break;
                            case '4':
                                break;
                        }
                    }
                    break;
                case '3':
                    Console.Clear();
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        string sql = "SELECT * FROM People";
                        SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                        DataSet ds = new DataSet();
                        adapter.Fill(ds);

                        DataTable dt = ds.Tables[0];
                        foreach (DataColumn column in dt.Columns)
                            Console.Write("{0,-15}", column.ColumnName);
                        Console.WriteLine();
                        foreach (DataRow row in dt.Rows)
                        {
                            var cells = row.ItemArray;
                            foreach (object cell in cells)
                                Console.Write("{0,-15}", cell);
                            Console.WriteLine();
                        }
                        FragmentMenu();
                        string sqlExpression, pole, val;
                        int number;
                        char k = char.Parse(Console.ReadLine());
                        switch (k)
                        {
                            case '1':
                                Console.WriteLine("Введите значения для нового поля:");
                                DataRow newRow = dt.NewRow();
                                Console.Write("Name="); newRow["Name"] = Console.ReadLine();
                                Console.Write("Language="); newRow["Language"] = Console.ReadLine();
                                dt.Rows.Add(newRow);
                                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(adapter);
                                adapter.Update(ds);
                                ds.Clear();
                                adapter.Fill(ds);
                                Console.Write("Нажмите Enter для выхода");
                                Console.ReadLine();
                                break;
                            case '2':
                                Console.Write("Введите Id по которому будем менять значения: ");
                                int help = Convert.ToInt32(Console.ReadLine());
                                Console.Write("\nВведите поле которое будем менять: ");
                                pole = Console.ReadLine();
                                Console.Write("\nВведите новое значение: ");
                                val = Console.ReadLine();
                                sqlExpression = "UPDATE People SET " + pole + "='" + val + "' WHERE Id=" + help;
                                SqlCommand command = new SqlCommand(sqlExpression, connection);
                                number = command.ExecuteNonQuery();
                                Console.Write("Нажмите Enter для выхода");
                                Console.ReadLine();
                                break;
                            case '3':
                                Console.Write("\nВведите поле по которому будем удалять строку: ");
                                pole = Console.ReadLine();
                                Console.Write("\nВведите значение по которому будем удалять строку: ");
                                val = Console.ReadLine();
                                if (pole == "Id")
                                {
                                    int val1 = Convert.ToInt32(val);
                                    sqlExpression = "DELETE FROM People WHERE " + pole + "=" + val1;
                                }
                                else sqlExpression = "DELETE FROM People WHERE " + pole + "='" + val + "'";
                                SqlCommand command1 = new SqlCommand(sqlExpression, connection);
                                number = command1.ExecuteNonQuery();
                                Console.Write("Нажмите Enter для выхода");
                                Console.ReadLine();
                                break;
                            case '4':
                                break;
                        }
                    }
                    break;
                case '4':
                    Console.Clear();
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        FragmentMenu1();
                        string  pole;
                        int number;
                        char k = char.Parse(Console.ReadLine());
                        switch (k)
                        {
                            case '1':
                                connection.Open();
                                Console.Write("Введите название региона: ");
                                pole = Console.ReadLine();
                                string sql = "SELECT * FROM Pogoda p INNER JOIN Region r WHERE r.Id=p.RegionId and r.Name='" + pole + "'";
                                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                                DataSet ds = new DataSet();
                                adapter.Fill(ds);

                                DataTable dt = ds.Tables[0];
                                foreach (DataColumn column in dt.Columns)
                                    Console.Write("{0,-12}", column.ColumnName);
                                Console.WriteLine();
                                foreach (DataRow row in dt.Rows)
                                {
                                    var cells = row.ItemArray;
                                    foreach (object cell in cells)
                                        Console.Write("{0,-12}", cell);
                                    Console.WriteLine();
                                }
                                Console.Write("Нажмите Enter для выхода");
                                Console.ReadLine();
                                break;
                            case '2':
                                connection.Open();
                                Console.Write("Введите название региона: ");
                                pole = Console.ReadLine();
                                Console.Write("Введите температуру: ");
                                number = Convert.ToInt32(Console.ReadLine());
                                string sql1 = "SELECT r.Name, p.Day, FROM Pogoda p INNER JOIN Region r WHERE r.Id=p.RegionId and r.Name='" + pole + "' and Opadi='Snow' and Temperature<" + number;
                                SqlDataAdapter adapter1 = new SqlDataAdapter(sql1, connection);
                                DataSet ds1 = new DataSet();
                                adapter1.Fill(ds1);

                                DataTable dt1 = ds1.Tables[0];
                                foreach (DataColumn column in dt1.Columns)
                                    Console.Write("{0,-12}", column.ColumnName);
                                Console.WriteLine();
                                foreach (DataRow row in dt1.Rows)
                                {
                                    var cells = row.ItemArray;
                                    foreach (object cell in cells)
                                        Console.Write("{0,-12}", cell);
                                    Console.WriteLine();
                                }
                                Console.Write("Нажмите Enter для выхода");
                                Console.ReadLine();
                                break;
                            case '3':
                                connection.Open();
                                Console.Write("Введите язык: ");
                                pole = Console.ReadLine();
                                string sql2 = "SELECT r.Name, p.Day,p.Opadi FROM Pogoda p INNER JOIN Region r INNER JOIN People p WHERE r.Id=p.RegionId and p.Id=r.PeopleId and p.Language='" + pole + "'";
                                SqlDataAdapter adapter2 = new SqlDataAdapter(sql2, connection);
                                DataSet ds2 = new DataSet();
                                adapter2.Fill(ds2);

                                DataTable dt2 = ds2.Tables[0];
                                foreach (DataColumn column in dt2.Columns)
                                    Console.Write("{0,-12}", column.ColumnName);
                                Console.WriteLine();
                                foreach (DataRow row in dt2.Rows)
                                {
                                    var cells = row.ItemArray;
                                    foreach (object cell in cells)
                                        Console.Write("{0,-12}", cell);
                                    Console.WriteLine();
                                }
                                Console.Write("Нажмите Enter для выхода");
                                Console.ReadLine();
                                break;
                            case '4':
                                break;
                            case '5':
                                return;
                        }
                    }
                    break;
                case '5':
                    return;
            }
            Menu();
        }
        static public void FragmentMenu()
        {
            Console.WriteLine();
            Console.Write("1-Добавить    ");
            Console.Write("2-Изменить     ");
            Console.Write("3-Удалить   ");
            Console.WriteLine("4-Назад    ");
            Console.Write("\n" + "Введите команду: ");
        }
        static public void FragmentMenu1()
        {
            Console.WriteLine();
            Console.WriteLine("1-Вивести відомості про погоду в заданому регіоні.");
            Console.WriteLine("2-Вивести дати, коли в заданому регіоні йшов сніг і температура була нижче заданої від‘ємної.");
            Console.WriteLine("3-Вивести інформацію про погоду за минулий тиждень в регіонах, жителі яких спілкуються заданою мовою.");
            Console.WriteLine("4-Вивести середню температуру за минулий тиждень в регіонах з площею більше заданої.");
            Console.WriteLine("5-Назад");
            Console.Write("\n" + "Введите команду: ");
        }
    }
}
