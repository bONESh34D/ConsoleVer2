using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ConsoleVer2_GitHub
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Connection*/
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = "Server=PROD\\INSTANCE;Initial Catalog=DATABASE;Integrated Security=True";
                conn.Open();

                /*This is how it works in SQL just fine
                 * 
                 * Exec [UtilityDatabase].[dbo].[StoredProcedure] @Source = 'PROD_APP',	@Destination = 'APP-DEV', @Database = 'APP_A1_COMP',
		                @Process = 'MoveProdtoLowerLevels',	@CompanyCode =	'A1', @EmailRequestor = 'Joe.Blow@domain.com',
		                @ADRequestor = 'Joe.Blow'
        
                 */

                /*Variables*/
                string CompanyCode = "";
                string Source = "PROD_APP"; //hardcoded
                string Destination = "";
                string Database = "";
                string Process = "MoveProdtoLowerLevels"; //hardcoded
                string ADRequestor = "";
                string EmailRequestor = "";

                /*Header*/
                Console.WriteLine("                                                                        ");
                Console.WriteLine("                                                                        ");
                Console.WriteLine("                                                                        ");
                Console.WriteLine("__________________________________________________________________________________");
                Console.WriteLine($"\r\n   Welcome! Thank you for using the APP Lower Environment Refresh Tool (ver 2)   ");
                Console.WriteLine("__________________________________________________________________________________");
                Console.WriteLine($"\r\n\r\nPLEASE NOTE: The source of your database will be from " + Source + " Production.");
                

                /*_Command To Get List_*/

                Console.WriteLine($"\r\n\r\nHere is a list of CompanyCodes and their cooresponding database names for you to choose from:");
                Console.WriteLine($"_________________________________________________");

                
                using (SqlCommand selectCommand = new SqlCommand("SELECT [CompanyCode],[CompanyDatabase] FROM [UtilityDatabase].[dbo].[view]", conn))
                {

                    using (SqlDataReader reader = selectCommand.ExecuteReader())
                    {
                        Console.WriteLine("CompanyCode\t|CompanyDatabase\t");
                        while (reader.Read())
                        {
                            Console.WriteLine(String.Format("    {0} \t        | {1}",
                                reader[0], reader[1]));
                        }
                    }
                }


                
                //example of CompanyCode is A1
                Console.WriteLine($"_________________________________________________");
                Console.WriteLine($"\r\n\r\nWhich CompanyCode(database shortname) would you like to refresh? Please enter CompanyCode. (ie. A1) :");
                CompanyCode = Console.ReadLine();
                Console.WriteLine($"\r\n\r\nCONFIRMATION: You have chosen the " + CompanyCode + " database. - Please press enter to confirm");

                Console.ReadKey();

                //example of Destination var is APP-TEST
                Console.WriteLine($"\r\n\r\nPlease enter one of these destinations: APP-BFX, APP-DEV, APP-TEST, APP-UAT ");
                Destination = Console.ReadLine();
                Console.WriteLine($"\r\n\r\nCONFIRMATION: You have selected the " + Destination + " destination. - Please press enter to confirm");

                Console.ReadKey();

                //example of Database is APP_A1_COMP
                Console.WriteLine($"\r\n\r\nPLEASE NOTE: Since you have chosen " + CompanyCode + " as your database, we will calculate the full name of the database.");
                Database = "APP_" + CompanyCode + "_COMP";
                Console.WriteLine($" CONFIRMATION: This is the full name of your database: " + Database + ".  - Please press enter to confirm");

                Console.ReadKey();

                //Process is hard coded
                Console.WriteLine($"\r\n\r\nPLEASE NOTE: Your Process is " + Process + ".");

                //example of ADRequestor is Joe.Blow
                Console.WriteLine($"\r\n\r\nPlease type your First(.)Last name without spaces. It will become your ADRequestor :");
                ADRequestor = Console.ReadLine();
                Console.WriteLine($"\r\n\r\nCONFIRMATION: Your ADRequestor name is " + ADRequestor + ".  - Please press enter to confirm");

                Console.ReadKey();

                //example of EmailRequestor is Joe.Blow@domain.com
                EmailRequestor = ADRequestor + "@domain.com";
                Console.WriteLine($"\r\n\r\nPlease verify that your email address is " + EmailRequestor + ".");
                
                Console.ReadKey();

                Console.WriteLine($"\r\n\r\nCONFIRMATION: Your email address is " + EmailRequestor + ".  - Please press enter to confirm");

                Console.ReadKey();
                /*_RECAP THE VARIABLES THAT WILL BE ASSIGNED TO THE PARAMETERS_*/
                Console.WriteLine($"\r\n\r\n________________________________________________________");
                Console.WriteLine($"\r\n\r\nThis is a recap! Your parameters are as follows:");
                Console.WriteLine($"-------->   " + CompanyCode + "");
                Console.WriteLine($"-------->   " + Source + "");
                Console.WriteLine($"-------->   " + Destination + "");
                Console.WriteLine($"-------->   " + Database + "");
                Console.WriteLine($"-------->   " + Process + "");
                Console.WriteLine($"-------->   " + ADRequestor + "");
                Console.WriteLine($"-------->   " + EmailRequestor + "");
                Console.WriteLine($"\r\n\r\n________________________________________________________");
                Console.WriteLine("                                                                        ");
                Console.WriteLine("                                                                        ");
                Console.WriteLine("                                                                        ");

                /*_BEGIN_#######_ERROR HANDLING_*/
                Console.WriteLine($"_________________________________________________");

                Console.WriteLine("Submitting the parameters to the SP. Look for errors beyond this point!");

                /*_try block_*/
                try
                {
                    ///*_#########_BEGIN_ORIG TRY_##########################################################################################################*/
                    ///*_Create the command to execute!_*/
                    //                            /*_Test commandfail*/
                    //                            //SqlCommand commandfail = new SqlCommand("SELECT [FAIL] FROM [msst_test].[dbo].[Fail_vw_FAIL]", conn);
                    //SqlCommand storedprocCommand = new SqlCommand("Exec [UtilityDatabase].[dbo].[StoredProcedure] @Source = '" + Source + "', @Destination = '" + Destination + "', @Database = '" + Database + "', @Process = '" + Process + "', @CompanyCode = '" + CompanyCode + "', @EmailRequestor = '" + EmailRequestor + "',@ADRequestor = '" + ADRequestor + "'", conn);

                    ///*_Add the parameters._*/
                    //storedprocCommand.Parameters.Add(new SqlParameter("Source", Source));
                    //storedprocCommand.Parameters.Add(new SqlParameter("Destination", Destination));
                    //storedprocCommand.Parameters.Add(new SqlParameter("Database", Database));
                    //storedprocCommand.Parameters.Add(new SqlParameter("Process", Process));
                    //storedprocCommand.Parameters.Add(new SqlParameter("CompanyCode", CompanyCode));
                    //storedprocCommand.Parameters.Add(new SqlParameter("EmailRequestor", EmailRequestor));
                    //storedprocCommand.Parameters.Add(new SqlParameter("ADRequestor", ADRequestor));


                    ////Test commandfail will give on SQL error message
                    //// - Msg 208, Level 16, State 1, Line 4
                    ////Invalid object name 'someErrorColumn'.
                    ///*_ Errors will pop here:_*/
                    ///*_Note: since we are catching any code block errors, they will display here in the console.*/
                    //storedprocCommand.ExecuteNonQuery();

                    ///*Try to print the command being sent, make sure to remark out "storedprocCommand.ExecuteNonQuery();"*/
                    ////Console.WriteLine("___________________________________________________________________________________");
                    ////Console.WriteLine("Print the command: " + storedprocCommand + ""); //This writes "Print the command: System.Data.SqlClient.SqlCommand"
                    ////Console.WriteLine("___________________________________________________________________________________");
                    ///*_#########_END_ORIG TRY_##########################################################################################################*/

                    ///*_#########_BEGIN_NEW TRY_##########################################################################################################*
                    using (SqlCommand storedprocCommand = new SqlCommand("[dbo].[StoredProcedure]", conn))
                    {
                        storedprocCommand.CommandType = CommandType.StoredProcedure;
                        /*_NOTE:_*/
                        //cmd.Parameters.Add("@FirstName", SqlDbType.VarChar).Value = txtFirstName.Text;
                        //cmd.Parameters.Add("@LastName", SqlDbType.VarChar).Value = txtLastName.Text;
                        /*My try
                        storedprocCommand.Parameters.Add("@Source", SqlDbType.VarChar).Value = Source;
                        storedprocCommand.Parameters.Add("@Destination", SqlDbType.VarChar).Value = Destination;
                        storedprocCommand.Parameters.Add("@Database", SqlDbType.VarChar).Value = Database;
                        storedprocCommand.Parameters.Add("@Process", SqlDbType.VarChar).Value = Process;
                        storedprocCommand.Parameters.Add("@CompanyCode", SqlDbType.VarChar).Value = CompanyCode;
                        storedprocCommand.Parameters.Add("@EmailRequestor", SqlDbType.VarChar).Value = EmailRequestor;
                        storedprocCommand.Parameters.Add("@ADRequestor", SqlDbType.VarChar).Value = ADRequestor;
                        */
                        /*_Note:_Still getting time outs with this_
                        storedprocCommand.Parameters.Add(new SqlParameter("@Source", Source));
                        storedprocCommand.Parameters.Add(new SqlParameter("@Destination", Destination));
                        storedprocCommand.Parameters.Add(new SqlParameter("@Database", Database));
                        storedprocCommand.Parameters.Add(new SqlParameter("@Process", Process));
                        storedprocCommand.Parameters.Add(new SqlParameter("@CompanyCode", CompanyCode));
                        storedprocCommand.Parameters.Add(new SqlParameter("@EmailRequestor", EmailRequestor));
                        storedprocCommand.Parameters.Add(new SqlParameter("@ADRequestor", ADRequestor));
                        */
                        //conn.Open();
                        storedprocCommand.ExecuteNonQuery();
                    }
                    ///*_#########_END_NEW TRY_##########################################################################################################*/

                }
                /*_catch block_*/
                catch (SqlException er)
                {
                    /*_Any SQL Server errors will be thrown here_*/
                    Console.WriteLine("There was an error reported by SQL Server, " + er.Message);
                }
                /*_END_#######_ERROR HANDLING_*/


                Console.WriteLine("___________________________________________________________________________________");
                Console.WriteLine($"   Have a nice day! Thank you for using the APP Lower Environment Refresh Tool (ver 2)   ");
                Console.WriteLine("___________________________________________________________________________________");

                Console.ReadKey();

                Console.WriteLine("....wait for it!");

            }
        }
    }
}

