using System.IO;
using System;


class Bank
{
    static int k=0;
    private static int _currentNumber=0;
    
    
    
    static void OpenAcc(register emp )
    {
        Console.WriteLine("Enter Name  & Account Type :");
        emp.name= Console.ReadLine();
        emp.AccType=Console.ReadLine();
        Console.WriteLine("Enter starting balance :");
        emp.balance=Convert.ToInt32(Console.ReadLine());
        emp.AccId=Convert.ToInt32(Bank.GetNextNumber());
        Console.WriteLine("You have successfully created a {0} account with Account Id :{1} ",emp.AccType,emp.AccId);
        k++;
    }
    
    
    
    public static string GetNextNumber()
       {
            _currentNumber++;
            return "5502060"+_currentNumber.ToString();
       }
       
       
    
    static void GetDetails(register emp)
    {
        Console.WriteLine("Name : {0}",emp.name);
        Console.WriteLine("Account Type : {0}",emp.AccType);
        Console.WriteLine("Balance : {0}",emp.balance);
        Console.WriteLine("Account Id : {0}",emp.AccId);
    }
    
    
    
    static void withdraw( register emp)
    {
        int bal=emp.balance;
        Console.WriteLine("Enter the amount you want to withdraw ");
        int draw=Convert.ToInt32(Console.ReadLine());
        if(emp.AccType == "savings")
        {
            if( (bal-draw) < 1000)
            {
                Console.WriteLine("Minimum Balance in savings account must be 1000 Rs. Please withdraw some less amount.");
            }
            else
            {
                emp.balance = bal-draw;   
            }
        }
        else  if(emp.AccType =="current")
        {
            if( (bal-draw) < 0)
            {
                Console.WriteLine("Minimum Balance in current account must be 0 Rs. Please withdraw some less amount.");
            }
            else
            {
                emp.balance = bal-draw;
            }
        }
        else
        {
            if( (bal-draw) < -10000)
            {
                Console.WriteLine("Minimum Balance in current account must be -10000 Rs. Please withdraw some less amount.");
            }
            else
            {
                emp.balance = bal-draw;
            }
        }
    }
    
    
    
    
    static void deposit(register emp)
    {
        Console.WriteLine("Enter the amount you want to deposit ");
        int depo=Convert.ToInt32(Console.ReadLine());
        emp.balance+=depo;
    }
    
    
    
    static void interest(register emp)
    {
         int principalAmount = emp.balance;
         float simpleInterest=0;
         if(emp.AccType == "savings")
         {
              simpleInterest = (principalAmount * 4 * 1) / 100;
              Console.WriteLine("Interest is: {0} Rs per Year", simpleInterest);
         }
         else if (emp.AccType=="current")
            {
                simpleInterest = (principalAmount * 1 * 1)/100;
                Console.WriteLine("Interest is: {0} Rs per Year", simpleInterest);
            }
            else
            {
                Console.WriteLine("Interest cannot be appliet on DMAT's Account");
            }
    }
    
    public static void Main()
    {
       
     register[] emp=new register[30]; 
      
      top: 
      Console.WriteLine("Enter \n 1 To Open new account \n 2 To Display account details \n 3 To Withdraw some amount \n 4 To Deposit money \n 5 To check Interest ");
      int choice=Convert.ToInt32(Console.ReadLine());
      register reg=new register();
      int count=0;
      if(choice==1)
      {
          emp[k]=new register();
          OpenAcc(emp[k]); 
         
      }
      else
      {
        count=0;
        Console.WriteLine("Enter Your Account Id");
        int id=Convert.ToInt32(Console.ReadLine());
        for(int i=0;i<k;i++)
        {
            if(emp[i].AccId == id)
            {
                 reg=emp[i];
                count=1;
            }
        }
        if(count!=1)
        {
            Console.WriteLine("No account found for this Account Id . Please Try Again.");
            goto top;
        }
      if(choice==2)
      {
        
           GetDetails(reg);
      }
      else if(choice==3)
      {
           withdraw(reg);
         
      }
      else if(choice==4)
      {
           deposit(reg);
         
      }
      else if(choice==5)
      {
           interest(reg);
      }
      else 
      {
       Console.WriteLine("You Entered wrong input. Please Try again...");
       goto top;
      }
     }
      Console.WriteLine("Do You want to Continue : Y or N ");
      char ch=Convert.ToChar(Console.ReadLine());
      ch=Char.ToUpper(ch);
      if(ch=='Y')
      goto top;
      
      
      
        
    }
}


class register
{
    
    public string name;
    public int AccId;
    public string AccType;
    public int balance;
}





