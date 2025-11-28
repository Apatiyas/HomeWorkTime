

#include <iostream>

class Natural_Fraction {
    int numerator;
    int denominator;
   
public:

   
    Natural_Fraction(){
         numerator = 0;
        denominator = 1;
    }
    

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
    
   Natural_Fraction& operator++() {
       numerator += 1;
       return *this;
   }
   Natural_Fraction operator++(int) {
       Natural_Fraction result = *this;
       ++(*this);
       return result;
   }
   Natural_Fraction& operator--() {
     numerator -= 1;
     return *this;
   }
   Natural_Fraction operator--(int) {
       Natural_Fraction result = *this;
       --(*this);
       return result;
   }


   Natural_Fraction operator-  ()const {
       return Natural_Fraction(-numerator, denominator);
   }

   Natural_Fraction operator!  ()const {
       return Natural_Fraction(denominator, numerator);
   }

   static Natural_Fraction NumberPi() {
       return Natural_Fraction(355, 113);
   }

   static Natural_Fraction* get_progression(int S, int N) {
       Natural_Fraction* progression = new Natural_Fraction[N];
       for (int i = 0; i < N; i++) {
           int denominator = 1 + i * S;
           progression[i] = Natural_Fraction(1, denominator);
       }
       return progression;
   }

};
int main()
{
    
   
    Natural_Fraction Fraction1(1,6);
    
    Natural_Fraction Fraction2(2,4);


    std::cout << "progression : " << std::endl;
    int N = 5;
    Natural_Fraction* progression = Natural_Fraction::get_progression(3, N);
    for (int i = 0; i < N; i++) {
        std::cout << progression[i];
    }
   std::cout << std::endl;


    std::cout << "Number Pi " << Natural_Fraction::NumberPi() << std::endl;


    Fraction1++;
    std::cout << "postfix increment" << Fraction1 << std::endl;
    Fraction1--;
    std::cout << "postfix decrement " << Fraction1 << std::endl;
    ++Fraction1;
    std::cout << "prefix increment" << Fraction1 << std::endl;
    --Fraction1;
    std::cout << "prefix decrement" << Fraction1 << std::endl;

   
    std::cout << "unury minus " << -Fraction2 << std::endl;
    std::cout << "logical negation " << !Fraction2 << std::endl;

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

