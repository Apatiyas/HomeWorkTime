#pragma once
#include <iostream>
#include "ListItem.h"
template <typename T>

class TwoDirectionList {
private:
    ListItem<T>* first; //адрес первого элемента
    ListItem<T>* last;  //адрес последнего элемента
    int counter;        //счетчик

public:
    TwoDirectionList() {
        first = nullptr;
        last = nullptr;
        counter = 0;
    }

    void push_front(T new_value) {  //добавление в начало
        ListItem<T>* new_element = new ListItem<T>(new_value);
        if (first == nullptr) {
            first = new_element;
            last = new_element;
        }
        else {
            new_element->set_next(first);
            first->set_prev(new_element);
            first = new_element;
        }
        counter++;
    }

    void push_back(T new_value) {  //добавление в конец
        ListItem<T>* new_element = new ListItem<T>(new_value);
        if (first == nullptr) {
            first = new_element;
            last = new_element;
        }
        else {
            new_element->set_prev(last);
            last->set_next(new_element);
            last = new_element;
        }
        counter++;
    }

    void insert(int index, T new_value) {
        if (index < 0 || index > counter) {
            std::cout << "Index out of bounds!" << std::endl;
            return;
        }

        if (index == 0) {
            push_front(new_value);
            return;
        }
        else if (index == counter) {
            push_back(new_value);
            return;
        }

        ListItem<T>* new_element = new ListItem<T>(new_value);
        ListItem<T>* current = first;

        for (int i = 0; i < index; i++) {
            current = current->get_next();
        }

        ListItem<T>* prev_element = current->get_prev();

        new_element->set_next(current);
        new_element->set_prev(prev_element);

        if (prev_element != nullptr) {
            prev_element->set_next(new_element);
        }
        current->set_prev(new_element);

        counter++;
    }

    void remove(int index) {  
        if (first == nullptr) {
            std::cout << "List is empty!" << std::endl;
            return;
        }

        if (index < 0 || index >= counter) {
            std::cout << "Index out of bounds!" << std::endl;
            return;
        }

        if (index == 0) {
            ListItem<T>* toDelete = first;
            first = first->get_next();
            if (first != nullptr) {
                first->set_prev(nullptr);
            }
            else {
                last = nullptr;  
            }
            delete toDelete;
            counter--;
            return;
        }

        if (index == counter - 1) {  
            ListItem<T>* toDelete = last;
            last = last->get_prev();
            if (last != nullptr) {
                last->set_next(nullptr);
            }
            else {
                first = nullptr;  
            }
            delete toDelete;
            counter--;
            return;
        }

        ListItem<T>* current = first;
        for (int i = 0; i < index; i++) {
            current = current->get_next();
        }

        ListItem<T>* prev = current->get_prev();
        ListItem<T>* next = current->get_next();

        if (prev != nullptr) {
            prev->set_next(next);
        }
        if (next != nullptr) {
            next->set_prev(prev);
        }

        delete current;
        counter--;
    }

    T& operator[](int index) {
        if (index < 0 || index >= counter) {
            std::cout << "index error" << std::endl;
        }

        ListItem<T>* current = first;
        for (int i = 0; i < index; i++) {
            current = current->get_next();
        }
        return current-> Linkget_value();
    }

  
    const T& operator[](int index) const {
        if (index < 0 || index >= counter) {
            std::cout << "index error" << std::endl;
        }

        ListItem<T>* current = first;
        for (int i = 0; i < index; i++) {
            current = current->get_next();
        }
        return current->get_value();
    }
  
};
