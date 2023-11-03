using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Fraction_Calculator
{

    public class Fraction
    {
        public double Nums, Denom;

        public Fraction(double nums, double denom)
        {
            this.Nums = nums;
            this.Denom = denom;


        }

        // returning the instantiated numerator
        public double ReturnNumerator()
        {
            return this.Nums;
        }
        // returning the instantiated denominator
        public double ReturnDenominator()
        {
            return this.Denom;
        }

       
     
        // cross multiplying, adding the values then multiplying the denominators straight across
        public static Fraction operator +(Fraction F1, Fraction F2)
        {
           
            double cross = F1.ReturnNumerator() * F2.ReturnDenominator() + F1.ReturnDenominator() * F2.ReturnNumerator();
            double bottom = F1.ReturnDenominator() * F2.ReturnDenominator();
            return new Fraction(cross, bottom);

            
        }

        // cross multiplying, subtracting the values then multiply the denominators straight across
        public static Fraction operator -(Fraction F1, Fraction F2)
        {
            double cross = F1.ReturnNumerator() * F2.ReturnDenominator() - F1.ReturnDenominator() * F2.ReturnNumerator();
            double bottom = F1.ReturnDenominator() * F2.ReturnDenominator();
            return new Fraction(cross, bottom);

        }

        // multiplying horizonally across
        public static Fraction operator *(Fraction F1, Fraction F2)
        {
            double cross = F1.ReturnNumerator() * F2.ReturnNumerator();
            double bottom = F1.ReturnDenominator() * F2.ReturnDenominator();
            return new Fraction(cross, bottom);

        }

        // dividing with the keep change, flip, logic
        public static Fraction operator /(Fraction F1, Fraction F2)
        {
            double cross = F1.ReturnNumerator() * F2.ReturnDenominator();
            double bottom = F1.ReturnDenominator() * F2.ReturnNumerator();
            return new Fraction(cross, bottom);

        }





    }
}
