using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanCalculation
{
    class Program
    {
        static void Main(string[] args)
        {
            double monthsInterest, months;
            Console.WriteLine("Welcome to the ANNUITY console application.");
            Console.Write("Please enter an Annual Interest Rate: ");
            monthsInterest = Convert.ToDouble(Console.ReadLine()) / 12000;
            Console.Write("Please enter an Number of Years: ");
            months = Convert.ToDouble(Console.ReadLine()) * 12;
            enterChoiceAndCaculate(monthsInterest, months);

            Console.ReadLine();
        }

        static void enterChoiceAndCaculate(double monthsInterest, double months)
        {
            double variable, payment, loan;
            string choice;
            bool flag = false;
            while(!flag)
            {
                Console.WriteLine("Would you like to calculate this annuity\n" +
               "by using a Monthly Payment or a Loan Amount?\n" +
               "Enter M for monthly payment or L for loan amount.");
                choice = Console.ReadLine();
                choice = choice.ToUpper();
                if (choice.StartsWith("M"))
                {
                    Console.Write("Enter a monthly payment amount: ");
                    variable = Convert.ToDouble(Console.ReadLine());
                    loan = variable * calculateAnnuity(monthsInterest, months);
                    Console.WriteLine("-------------------------------");
                    Console.WriteLine("Interest: " + monthsInterest * 12000);
                    Console.WriteLine("Years: " + months / 12);
                    Console.WriteLine("Payment: " + variable);
                    Console.WriteLine("Loan calculated will be: " + loan);

                    flag = true;
                }
                else if (choice.StartsWith("L"))
                {
                    Console.Write("Enter a loan amount: ");
                    variable = Convert.ToDouble(Console.ReadLine());
                    payment = variable / calculateAnnuity(monthsInterest, months);
                    Console.WriteLine("-------------------------------");
                    Console.WriteLine("Interest: " + monthsInterest * 12000);
                    Console.WriteLine("Years: " + months / 12);
                    Console.WriteLine("Loan: " + variable);
                    Console.WriteLine("Payment calculated will be: " + payment);
                    flag = true;
                }
                else
                {
                    Console.WriteLine(choice.ToString() + " is not a valid option.\n" +
                        "Please try again");
                }
            }
        }

        static double calculateAnnuity(double monthsInterest, double months)
        {
            double annuity = 0.0;
            annuity = (1 - Math.Pow((1 + monthsInterest), (-1 * months)) / monthsInterest);
            return annuity;
        }
    }
}
