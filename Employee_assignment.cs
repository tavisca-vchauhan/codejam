using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace acgt
{

    public delegate void Del(Employee employee, int itr);
	class Empty_Exceptions:Exception
    {
        public Empty_Exceptions(string message):base(message) 
        {

        }
    }
	
    class employee
    {
        static int k = 0;

		public static string path = @"C:\Users\vishwas chauhan\logs.txt";
        
		
		static void AddEmp(Employee emp)
        {
            Console.WriteLine("Enter Name of Employee :");
            emp.name = Console.ReadLine();
            Console.WriteLine("Enter Qualification of Employee :(BE, BCA, BSC, Bcom, Mcom, CA)");
            emp.id=k+2560;
			 try
            {
                emp.qualification = Console.ReadLine();
				if (emp.qualification == "BE" || emp.qualification == "BCA" || emp.qualification == "BSC")
            {
                emp.department = "IT";
            }
            else if (emp.qualification == "BCom" || emp.qualification == "MCom" || emp.qualification == "CA")
            {
                emp.department = "Accounts";
            }


                    if (string.IsNullOrEmpty(emp.qualification))
                    { throw new Empty_Exceptions("Please Enter qualification as mentioned in the options.");
                       
                    }
					else{
						Console.WriteLine("Employee added under {0} department with Id :{1} ", emp.department,emp.id);
					}
            }
            catch (Empty_Exceptions empty)
            {
                Console.WriteLine(empty.Message);

                   if (!File.Exists(path))
                    {
                        // Create a file to write to.
                        using (StreamWriter sw = File.CreateText(path))
                        {
                            sw.WriteLine(empty.StackTrace);
                        }
                    }

            }

            
			
			
			
			
        }







        static void GetDetails(Employee emp)
        {
            Console.WriteLine("Name : {0}", emp.name);
            Console.WriteLine("Qualification : {0}", emp.qualification);
            Console.WriteLine("Department : {0}", emp.department);

        }








        public static void Main()
        {

            Employee[] emp = new Employee[30];

        top:
            Console.WriteLine("Enter \n 1 To Add Employee details \n 2 To Display details \n 3 To Exit ");
            int choice = Convert.ToInt32(Console.ReadLine());
            Employee reg = new Employee();
            if (choice == 1)
            {
                emp[k] = new Employee();
                AddEmp(emp[k]);
				k++;

            }
            else if (choice == 2)
            {
				Console.WriteLine("Enter Employee Id");
				int bb=Convert.ToInt32(Console.ReadLine());
				for(int i=0;i<k;i++)
				{
					if(bb==emp[i].id)
                    GetDetails(emp[i]);
				}
            }
            else if (choice == 3)
            {
                System.Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("You Entered wrong input. Please Try again...");
                goto top;
            }

            Console.WriteLine("Do You want to Continue : Y or N ");
            char ch = Convert.ToChar(Console.ReadLine());
            ch = Char.ToUpper(ch);
            if (ch == 'Y')
                goto top;




        }

	}
	
    public class Employee
    {

        public string name;
        public string qualification;
        public string department;
		public int id;
    }



}
