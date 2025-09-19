using System;



abstract class Account
    {
        public string AccountNumber { get; set; }
        public string AccountName { get; set; }
        public double AccBalance { get; set; }

        public Account(string accountNumber, string accountName, double accbalance)
        {
            AccountNumber = accountNumber;
            AccountName = accountName;
            AccBalance = accbalance;
        }

        public abstract double CalculateInterest(); //im gonna use this method in my next classes to 
    }

class SavingsAccount : Account
{

    private double InterestRate;
    //internal object interestrate;

    //double InterestRate { get; set; }

    public SavingsAccount(string accountNumber, string accountName, double balance, double intRate) : base(accountNumber, accountName, balance)

    {
        InterestRate = intRate;
    }

    public override double CalculateInterest()
    {
        return AccBalance * InterestRate / 100; //interest 2 percent
    }
}

class CurrentAccount : Account

{
    private double InterestRate;
   

    //public double interestRate { get; set; }

    public CurrentAccount(string accountNumber, string accountName,double accbalance,double intRate) : base(accountNumber, accountName, accbalance)

    {
        InterestRate = intRate;

    }
    public override double CalculateInterest()
    {
        return AccBalance * InterestRate / 100; //interest 0.5 percent
    }
} 

public class BankAccount 
    {
   

    public static void Main(string[] args)
    {
        /*string accountNumber = null;
        string AccountName = null;
        double AccBalance = 0;
        double interestrate = 0;
        SavingsAccount sb= new SavingsAccount(accountNumber, AccountName, AccBalance , interestrate);
        sb.CalculateInterest();

        CurrentAccount cb = new CurrentAccount(accountNumber, AccountName, AccBalance, interestrate);
        cb.CalculateInterest();*/

        Console.Write("enter the accountNumber:");
        string AccountNumber = Console.ReadLine();
        Console.Write("enter the accountName:");
        string AccountName = Console.ReadLine();
        Console.Write("enter the sb accountbalance:");
       double  sbAccBalance= double.Parse(Console.ReadLine());
        Console.Write("\nenter the cb accountNumber:");
        string cbAccountNumber = Console.ReadLine();
        Console.Write("enter the cb accountName:");
        string cbAccountName = Console.ReadLine();
        Console.Write("enter the cb accountbalance:");
        double cbAccBalance= double.Parse(Console.ReadLine());
        double  sbinterestRate = 0.005;
        double cbinterestRate = 0.2;

        SavingsAccount sb = new SavingsAccount(AccountNumber, AccountNumber, sbAccBalance, sbinterestRate);
        CurrentAccount cb=new CurrentAccount(AccountNumber, AccountNumber, cbAccBalance, cbinterestRate);

        double sbinterest = sb.CalculateInterest();
        double cbinterest = cb.CalculateInterest();

        Console.WriteLine("\n\nsavings account \nAccount Number: " + AccountNumber + "\naccountName: " + AccountName + "\nbalance: " + sbAccBalance + "\n interest percentage <2%> \n interets: " + sbinterest );
        Console.WriteLine("\n\ncurrent account \nAccount Number: " + cbAccountNumber + "\naccountName: " + cbAccountName + "\nbalance: " + cbAccBalance + "\n interest percentage <0.5%> \n interets: " + cbinterest);






    }

}



