

#include <iostream>
#include "Temperature.h"

int main() {
    Temperature Temp1;
    Temperature Temp2(65, TempUnits::Celsius);
    Temp1.setTemp(45, TempUnits::Kelvin);
    Temp1.convert_temp(TempUnits::Celsius);
    Temp2.convert_temp(TempUnits::Fahrenheit);
    Temp1.display();
    Temp2.display();
    return 0;
}
