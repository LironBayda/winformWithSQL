using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace winformWithSQL
{
    class calculator
    {
        static string ASK_NUMBERS_FROM_THE_USER ="please enter number for x and y. enter two number at a time " +
            "enter number less then or equal to zero. max numbers you can enter is 10000";


        static int[,] results = new int[2, 10000];
        static int count_numbers = 0;


        private static void GetNumFromUser()
        {
            while (true)
            {
                Console.WriteLine(ASK_NUMBERS_FROM_THE_USER);
                Int32.TryParse(Console.ReadLine(),out results[0, count_numbers]);

                if (results[0, count_numbers] <= 0)
                    break;
                Int32.TryParse(Console.ReadLine(), out results[1, count_numbers]);


                if ( results[1, count_numbers] <= 0)
                    break;

                count_numbers++;


            }

       
        }


       private static string CreateSQLCommendFromXYResult ()
        {
            string SQLCommandForX = "";
            string SQLCommandForY = "";


            for (int i = 0; i < count_numbers-1; i++)
            {
                SQLCommandForX += $"insert into x values({results[0,i]}) \n";
                SQLCommandForY += $"insert into y values({results[1, i]}) \n";

            }

            return SQLCommandForX + SQLCommandForY;
        }




        public static void GetDataFromTheUserAndCalculate()
        {
            
            GetNumFromUser();
            InsertValuesToXYTables();
            CreateTableForCalculations();
            UpdateResultsInCalculations();
            ShowResult();
            RenoveValuesFromXYTablesAndDropCalculation();


        }

        private static void RenoveValuesFromXYTablesAndDropCalculation()
        {
            helpFunction.CreateCommandNonQuery("delete from x");
            helpFunction.CreateCommandNonQuery("delete from y");
            helpFunction.CreateCommandNonQuery("drop table calculations");


        }

        private static void ShowResult()
        {
            helpFunction.ReadOrderData("SELECT * FROM  calculations");
        }

        private static void UpdateResultsInCalculations()
        {
            helpFunction.CreateCommandNonQuery("update calculations set results= x_value+y_value" +
                " where operator_type like '+';");

            helpFunction.CreateCommandNonQuery("update calculations set results= x_value-y_value" +
        " where operator_type like '-';");

            helpFunction.CreateCommandNonQuery("update calculations set results= x_value*y_value" +
        " where operator_type like '*';");

            helpFunction.CreateCommandNonQuery("update calculations set results= x_value/y_value" +
        " where operator_type like '/';");

        }

        private static void CreateTableForCalculations()
        {
            string createCalculatonCmd = "with  temp as (SELECT * FROM x CROSS JOIN operator CROSS JOIN y ) select * into calculations from temp \n" +
         "ALTER TABLE Calculations ADD results int;";
            helpFunction.CreateCommandNonQuery(createCalculatonCmd);
        }

        private static void InsertValuesToXYTables()
        {
            string cmd = CreateSQLCommendFromXYResult();
            helpFunction.CreateCommandNonQuery(cmd);
        }
    }
}
