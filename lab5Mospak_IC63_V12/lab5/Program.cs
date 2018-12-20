using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace lab5
{
    class Program
    {
        static string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=usersdb;Integrated Security=True";
        static void Main(string[] args)
        {
            Menu();
            Console.Read();
        }
        static public void Menu()
        {
            Console.Clear();
            Console.WriteLine("Лабораторная работа №5 Сделал:Мосьпак Олег Группа:IC-63 Вариант:12");
            Console.WriteLine("Выберите таблицу:");
            Console.WriteLine("1. Sudno(Судна)");
            Console.WriteLine("2. Perevezena(Перевозки)");
            Console.WriteLine("3. Port(Порт)");
            Console.WriteLine("4. Dogovor(Договор)");
            Console.WriteLine("5. Zakaz(Заказ)");
            Console.WriteLine("6. Выход");
            Console.Write("\n" + "Введите команду: ");
            char ch = char.Parse(Console.ReadLine());

            switch (ch)
            {
                case '1':
                    Console.Clear();
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        string sql = "SELECT * FROM Sudno";
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
                                Console.Write("Name="); newRow["Name"] = Console.ReadLine();
                                Console.Write("BuiltYear="); newRow["BuiltYear"] = Convert.ToInt32(Console.ReadLine());
                                Console.Write("StatePort="); newRow["StatePort"] = Console.ReadLine();
                                Console.Write("FullNameCap="); newRow["FullNameCap"] = Console.ReadLine();
                                Console.Write("QuantityPeople="); newRow["QuantityPeople"] = Convert.ToInt32(Console.ReadLine());
                                Console.Write("RebuiltYear="); newRow["RebuiltYear"] = Convert.ToInt32(Console.ReadLine());
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
                                if (pole == "BuiltYear" || pole == "QuantityPeople" || pole == "RebuiltYear")
                                {
                                    int val1 = Convert.ToInt32(val);
                                    sqlExpression = "UPDATE Sudno SET " + pole + "=" + val1 + " WHERE Id=" + help;
                                }
                                else sqlExpression = "UPDATE Sudno SET " + pole + "='" + val + "' WHERE Id=" + help;
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
                                if (pole == "BuiltYear" || pole == "QuantityPeople" || pole == "RebuiltYear" || pole == "Id")
                                {
                                    int val1 = Convert.ToInt32(val);
                                    sqlExpression = "DELETE FROM Sudno WHERE " + pole + "=" + val1;
                                }
                                else sqlExpression = "DELETE FROM Sudno WHERE " + pole + "='" + val + "'";
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
                        string sql = "SELECT * FROM Perevezena";
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
                                Console.Write("SudnoId="); newRow["SudnoId"] = Convert.ToInt32(Console.ReadLine());
                                Console.Write("VidVantazh="); newRow["VidVantazh"] = Console.ReadLine();
                                Console.Write("Quantity="); newRow["Quantity"] = Convert.ToInt32(Console.ReadLine());
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
                                if (pole == "SudnoId" || pole == "Quantity")
                                {
                                    int val1 = Convert.ToInt32(val);
                                    sqlExpression = "UPDATE Perevezena SET " + pole + "=" + val1 + " WHERE Id=" + help;
                                }
                                else sqlExpression = "UPDATE Perevezena SET " + pole + "='" + val + "' WHERE Id=" + help;
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
                                if (pole == "SudnoId" || pole == "Quantity" || pole == "Id")
                                {
                                    int val1 = Convert.ToInt32(val);
                                    sqlExpression = "DELETE FROM Perevezena WHERE " + pole + "=" + val1;
                                }
                                else sqlExpression = "DELETE FROM Perevezena WHERE " + pole + "='" + val + "'";
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
                        string sql = "SELECT * FROM Port";
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
                                Console.Write("PortVidprav="); newRow["PortVidprav"] = Console.ReadLine();
                                Console.Write("DateVidprav="); newRow["DateVidprav"] = Console.ReadLine();
                                Console.Write("CountryFinal="); newRow["CountryFinal"] = Console.ReadLine();
                                Console.Write("PortFinal="); newRow["PortFinal"] = Console.ReadLine();
                                Console.Write("DateFinal="); newRow["DateFinal"] = Console.ReadLine();
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
                                sqlExpression = "UPDATE Port SET " + pole + "='" + val + "' WHERE Id=" + help;
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
                                    sqlExpression = "DELETE FROM Port WHERE " + pole + "=" + val1;
                                }
                                else sqlExpression = "DELETE FROM Port WHERE " + pole + "='" + val + "'";
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
                        connection.Open();
                        string sql = "SELECT * FROM Dogovor";
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
                                Console.Write("NameComp="); newRow["NameComp"] = Console.ReadLine();
                                Console.Write("CountryComp="); newRow["CountryComp"] = Console.ReadLine();
                                Console.Write("VidVantazh="); newRow["VidVantazh"] = Console.ReadLine();
                                Console.Write("Quantity="); newRow["Quantity"] = Convert.ToInt32(Console.ReadLine());
                                Console.Write("PortId="); newRow["PortId"] = Convert.ToInt32(Console.ReadLine());
                                Console.Write("Plata="); newRow["Plata"] = Convert.ToInt32(Console.ReadLine());
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
                                if (pole == "Quantity" || pole == "PortId" || pole == "Plata")
                                {
                                    int val1 = Convert.ToInt32(val);
                                    sqlExpression = "UPDATE Dogovor SET " + pole + "=" + val1 + " WHERE Id=" + help;
                                }
                                else sqlExpression = "UPDATE Dogovor SET " + pole + "='" + val + "' WHERE Id=" + help;
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
                                if (pole == "Quantity" || pole == "PortId" || pole == "Plata" || pole == "Id")
                                {
                                    int val1 = Convert.ToInt32(val);
                                    sqlExpression = "DELETE FROM Dogovor WHERE " + pole + "=" + val1;
                                }
                                else sqlExpression = "DELETE FROM Dogovor WHERE " + pole + "='" + val + "'";
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
                case '5':
                    Console.Clear();
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        string sql = "SELECT * FROM Zakaz";
                        SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                        DataSet ds = new DataSet();
                        adapter.Fill(ds);

                        DataTable dt = ds.Tables[0];
                        foreach (DataColumn column in dt.Columns)
                            Console.Write("{0,-8}", column.ColumnName);
                        Console.WriteLine();
                        foreach (DataRow row in dt.Rows)
                        {
                            var cells = row.ItemArray;
                            foreach (object cell in cells)
                                Console.Write("{0,-8}", cell);
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
                                Console.Write("SudnoId="); newRow["SudnoId"] = Convert.ToInt32(Console.ReadLine());
                                Console.Write("DogovorId="); newRow["DogovorId"] = Convert.ToInt32(Console.ReadLine());
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
                                if (pole == "SudnoId" || pole == "DogovorId")
                                {
                                    int val1 = Convert.ToInt32(val);
                                    sqlExpression = "UPDATE Zakaz SET " + pole + "=" + val1 + " WHERE Id=" + help;
                                }
                                else sqlExpression = "UPDATE Zakaz SET " + pole + "='" + val + "' WHERE Id=" + help;
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
                                if (pole == "SudnoId" || pole == "DogovorId" || pole == "Id")
                                {
                                    int val1 = Convert.ToInt32(val);
                                    sqlExpression = "DELETE FROM Zakaz WHERE " + pole + "=" + val1;
                                }
                                else sqlExpression = "DELETE FROM Zakaz WHERE " + pole + "='" + val + "'";
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
                case '6':
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
    }
}
