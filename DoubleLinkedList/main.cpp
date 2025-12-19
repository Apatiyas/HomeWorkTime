

#include <iostream>
#include "TwoDirectionList.h"

int main() {
    // Создаем список целых чисел
    TwoDirectionList<int> list;


    // Добавляем элементы
    list.push_back(10);
    list.push_back(20);
    list.push_back(30);
    list.push_back(40);
    list.push_back(50);

   

    // Изменяем элементы через оператор []
  
    list[0] = 100;  // Первый элемент
    list[2] = 300;  // Третий элемент
  
    

    // Тестирование вставки
    list.insert(2, 999);

  

    // Тестирование удаления
  
    list.remove(3);

    

    return 0;
}
