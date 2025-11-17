

#include <iostream>

class Natural_Fraction {
    int numerator;
    int denominator;
   
public:

   

    

    Natural_Fraction(int numerator, int denominator){

        this->numerator = numerator;
        this->denominator = denominator;
       
    }


    Natural_Fraction(const Natural_Fraction& other)  {
        numerator = other.numerator;
       denominator = other.denominator;
    }

    Natural_Fraction& operator = (const  Natural_Fraction& other) {
        if (this != &other) {
            numerator = other.numerator;
            denominator = other.denominator;
        }
        return *this;
    }

   bool operator == (const  Natural_Fraction& other)const {
       return (numerator * other.denominator) == (other.numerator * denominator);
   }
   bool operator<  (const  Natural_Fraction& other)const {
       return (numerator * other.denominator) < (other.numerator * denominator);
      
   }

   bool operator> (const  Natural_Fraction& other)const {
       return (numerator * other.denominator) > (other.numerator * denominator);
   }
   bool operator>=  (const Natural_Fraction& other)const {
      
       return !(*this < other);
   }
   bool operator<=  (const Natural_Fraction& other)const {

       return !(*this > other);
   }


   Natural_Fraction operator+  (const  Natural_Fraction& other)const {
       if (other.denominator == denominator) {
           int num = (numerator * other.denominator) + (other.numerator * denominator);
           int den = denominator;
           return Natural_Fraction(num, den);
       }
    int num = (numerator * other.denominator)+( other.numerator * denominator);
    int den =  (other.denominator * denominator);
       return Natural_Fraction(num, den);
   }

   Natural_Fraction operator-  (const  Natural_Fraction& other)const {
       if (other.denominator == denominator) {
           int num = (numerator * other.denominator) - (other.numerator * denominator);
           int den = denominator;
           return Natural_Fraction(num, den);
       }
       int num = (numerator * other.denominator) - (other.numerator * denominator);
       int den = (other.denominator * denominator);
       return Natural_Fraction(num, den);
   }

   Natural_Fraction operator*  (const  Natural_Fraction& other)const {
       Natural_Fraction product(numerator * other.numerator, denominator * other.denominator);
      
       return product;
   }
   Natural_Fraction operator/  (const  Natural_Fraction& other)const {
       Natural_Fraction quotien(numerator * other.denominator, denominator * other.numerator);

       return quotien;
   }

   
   friend std::ostream& operator<<(std::ostream& output, const Natural_Fraction& Fraction) {
       output << Fraction.numerator << "/" << Fraction.denominator << std::endl;
       output << Fraction.numerator << "." << Fraction.denominator << std::endl;
       return output;
   }
    



};
int main()
{
    
   
    Natural_Fraction Fraction1(1,6);
    
    Natural_Fraction Fraction2(2,4);

    Natural_Fraction Fraction3 = Fraction2 + Fraction1;
    std::cout << "sum: " << Fraction3 << std::endl;

     Fraction3 = Fraction2 - Fraction1;
     std::cout << "difference: " << Fraction3 << std::endl;

     Fraction3 = Fraction2 * Fraction1;
     std::cout << "product: " << Fraction3 << std::endl;

     Fraction3 = Fraction2 / Fraction1;
     std::cout << "quotient " << Fraction3 << std::endl;

    Fraction3 = Fraction2;
    std::cout << "sum: " << Fraction3 << std::endl;

    bool result = Fraction1 == Fraction2;
    std::cout << result<<std::endl;

    result = Fraction1 < Fraction2;
    std::cout << result << std::endl;

    result = Fraction1 > Fraction2;
    std::cout << result << std::endl;

    result = Fraction1 <= Fraction2;
    std::cout << result << std::endl;

    result = Fraction1 >= Fraction2;
    std::cout << result << std::endl;




}

