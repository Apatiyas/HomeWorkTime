

#include <iostream>

class Electronic_wallet {
    int ruble;
    int kopeck;
   
public:

    void normalization() {
        if (kopeck > 99) {
            ruble += kopeck / 100;
            kopeck = kopeck%100;
        }
        else if (kopeck < 0) {
            ruble -= (-kopeck) / 100 + 1;
            kopeck = 100 - ((-kopeck) % 100);
        }
    }

    Electronic_wallet(){
        ruble = 0;
        kopeck = 0;
    }

    Electronic_wallet(int ruble, int kopeck){

        this->ruble = ruble;
        this->kopeck = kopeck;
        normalization();
    }


    Electronic_wallet(const  Electronic_wallet& other)  {
        ruble = other.ruble;
        kopeck = other.kopeck;
    }

    Electronic_wallet& operator = (const  Electronic_wallet& other) {
        if (this != &other) {
            ruble = other.ruble;
            kopeck = other.kopeck;
        }
        return *this;
    }

   bool operator == (const  Electronic_wallet& other)const {
        if ((ruble == other.ruble) && (kopeck == other.kopeck)) return true;
        return false;
   }
   bool operator<  (const  Electronic_wallet & other)const {
       if (ruble <other.ruble) return true;
       if ((ruble == other.ruble)&&(kopeck < other.kopeck)) return true;
       return false;
   }

   bool operator>  (const  Electronic_wallet& other)const {
       if (ruble > other.ruble) return true;
       if ((ruble == other.ruble) && (kopeck > other.kopeck)) return true;
       return false;
   }
   bool operator>=  (const  Electronic_wallet& other)const {
      
       return !(*this < other);
   }
   bool operator<=  (const  Electronic_wallet& other)const {

       return !(*this > other);
   }


   Electronic_wallet operator+  (const  Electronic_wallet& other)const {
       Electronic_wallet sum(ruble + other.ruble, kopeck + other.kopeck);
       sum.normalization();
       return sum;
   }
   Electronic_wallet operator-  (const  Electronic_wallet& other)const {
       Electronic_wallet difference(ruble - other.ruble, kopeck - other.kopeck);
       difference.normalization();
       return difference;
   }
   Electronic_wallet operator*  (int number1)const {
       Electronic_wallet product(ruble * number1, kopeck * number1);
       product.normalization();
       return product;
   }
   Electronic_wallet operator/  (int number2)const {
       if (number2 == 0) {
           std::cout << "error\n";
           return Electronic_wallet(0, 0);
       
       }
       Electronic_wallet quotient(ruble / number2, kopeck / number2);
       quotient.normalization();
       return quotient;
   }


    void display() {
        std::cout << std::endl;
        std::cout << ruble <<" ruble\n";
        std::cout << kopeck << " kopeck\n";
        
    }

    



};
int main()
{
    
    Electronic_wallet Ewallet1;
    Electronic_wallet Ewallet2(100,630);
    Ewallet2.normalization();
    Ewallet2.display();
    Electronic_wallet Ewallet3(Ewallet2);

    Electronic_wallet Ewallet4 = Ewallet2 + Ewallet3;
    Ewallet4.display();
    Electronic_wallet Ewallet5 = Ewallet2 - Ewallet3;
    Ewallet5.display();
    Electronic_wallet Ewallet6 = Ewallet2 * 3;
    Ewallet6.display();
    Electronic_wallet Ewallet7 = Ewallet2 / 3;
    Ewallet7.display();
    Electronic_wallet Ewallet8 = Ewallet6;
    Ewallet8.display();

    bool result = Ewallet2 == Ewallet3;
    std::cout << result<<std::endl;

    result = Ewallet2 < Ewallet3;
    std::cout << result << std::endl;

    result = Ewallet2 > Ewallet3;
    std::cout << result << std::endl;

    result = Ewallet2 <= Ewallet3;
    std::cout << result << std::endl;

    result = Ewallet2 >= Ewallet3;
    std::cout << result << std::endl;




}

