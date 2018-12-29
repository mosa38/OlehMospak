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
        static public SqlConnection connection = null;
        static public void OpenConnection(string connectionString)
        {
            connection = new SqlConnection(connectionString);
            connection.Open();
        }
        static public void CloseConnection()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Close();
            }
        }
        static void Main(string[] args)
        {
            Menu();
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
                    Pogoda();
                    break;
                case '2':
                    Console.Clear();
                    Region();
                    break;
                case '3':
                    Console.Clear();
                    People();
                    break;
                case '4':
                    Console.Clear();
                    FragmentMenu1();
                    char k = char.Parse(Console.ReadLine());
                    switch (k)
                    {
                        case '1':
                            Zap1();
                            break;
                        case '2':
                            Zap2();
                            break;
                        case '3':
                            Zap3();
                            break;
                        case '4':
                            Zap4();
                            break;
                        case '5':
                            break;
                    }
                    break;
                case '5':
                    return;
            }
            Menu();
        }
        static public void Pogoda()
        {
            OpenConnection(connectionString);
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
                    try
                    {
                        number = command.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        Exception error = new Exception("Error", ex);
                        throw error;
                    }
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
                    try
                    {
                        number = command1.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        Exception error = new Exception("Error", ex);
                        throw error;
                    }
                    Console.Write("Нажмите Enter для выхода");
                    Console.ReadLine();
                    break;
                case '4':
                    return;
            }
            CloseConnection();
        }

        static public void Region()
        {
            OpenConnection(connectionString);
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
                    try
                    {
                        number = command.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        Exception error = new Exception("Error", ex);
                        throw error;
                    }
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
                    try
                    {
                        number = command1.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        Exception error = new Exception("Error", ex);
                        throw error;
                    }
                    Console.Write("Нажмите Enter для выхода");
                    Console.ReadLine();
                    break;
                case '4':
                    return;
            }
            CloseConnection();
        }
        static public void People()
        {
            OpenConnection(connectionString);
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
                    try
                    {
                        number = command.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        Exception error = new Exception("Error", ex);
                        throw error;
                    }
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
                    try
                    {
                        number = command1.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        Exception error = new Exception("Error", ex);
                        throw error;
                    }
                    Console.Write("Нажмите Enter для выхода");
                    Console.ReadLine();
                    break;
                case '4':
                    return;
            }
            CloseConnection();
        }
        static public void Zap1()
        {
            OpenConnection(connectionString);
            string pole;
            Console.Write("Введите название региона: ");
            pole = Console.ReadLine();
            string sql = "SELECT p.Id, r.Name AS Region,p.Day,p.Temperature,p.Opadi FROM Pogoda p JOIN Region r ON r.Id=p.RegionId WHERE r.Name='" + pole + "'";
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
            CloseConnection();
            Console.Write("\nНажмите Enter для выхода");
            Console.ReadLine();
        }
        static public void Zap2()
        {
            OpenConnection(connectionString);
            string pole;
            int number;
            Console.Write("Введите название региона: ");
            pole = Console.ReadLine();
            Console.Write("Введите температуру: ");
            number = Convert.ToInt32(Console.ReadLine());
            string sql1 = "SELECT r.Name AS Region, p.Day FROM Pogoda p JOIN Region r ON r.Id=p.RegionId WHERE r.Name='" + pole + "' AND p.Opadi='Snow' AND p.Temperature<" + number;
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
            CloseConnection();
            Console.Write("\nНажмите Enter для выхода");
            Console.ReadLine();
        }
        static public void Zap3()
        {
            OpenConnection(connectionString);
            string pole;
            Console.Write("Введите язык: ");
            pole = Console.ReadLine();
            string sql2 = "SELECT r.Name AS Region, p.Day,p.Temperature, p.Opadi FROM Pogoda p JOIN Region r ON r.Id=p.RegionId JOIN People pe ON pe.Id=r.PeopleId WHERE pe.Language='" + pole + "'";
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
            CloseConnection();
            Console.Write("\nНажмите Enter для выхода");
            Console.ReadLine();
        }
        static public void Zap4()
        {
            OpenConnection(connectionString);
            int number;
            Console.Write("Введите площадь: ");
            number = Convert.ToInt32(Console.ReadLine());
            string sql3 = "SELECT r.Name AS Region,r.Square, AVG(p.Temperature) AS T_average FROM Pogoda p JOIN Region r ON r.Id=p.RegionId WHERE r.Square>" + number + " GROUP BY r.Name, r.Square;";
            SqlDataAdapter adapter3 = new SqlDataAdapter(sql3, connection);
            DataSet ds3 = new DataSet();
            adapter3.Fill(ds3);

            DataTable dt3 = ds3.Tables[0];
            foreach (DataColumn column in dt3.Columns)
                Console.Write("{0,-12}", column.ColumnName);
            Console.WriteLine();
            foreach (DataRow row in dt3.Rows)
            {
                var cells = row.ItemArray;
                foreach (object cell in cells)
                    Console.Write("{0,-12}", cell);
                Console.WriteLine();
            }
            CloseConnection();
            Console.Write("\nНажмите Enter для выхода");
            Console.ReadLine();
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
            Console.WriteLine("1-Вывести сведения о погоде в заданном регионе.");
            Console.WriteLine("2-Вывести дни, когда в заданном регионе шел снег и температура была ниже заданной.");
            Console.WriteLine("3-Вывести информацию о погоде за прошедшую неделю в регионах, жители которых общаются на заданном языке.");
            Console.WriteLine("4-Вывести среднюю температуру за неделю в регионах с площадью больше чем заданая.");
            Console.WriteLine("5-Назад");
            Console.Write("\n" + "Введите команду: ");
        }
    }
}
