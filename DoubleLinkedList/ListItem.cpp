#pragma once
#include <iostream>

template <typename T>
class ListItem {
private:
	ListItem <T>* next; //адрес следующего элемента
	ListItem <T>* prev; //адрес предыдущего элемента
	T value;  //данные
public:
	ListItem(T new_value) : value(new_value), next(nullptr), prev(nullptr) {}  //конструктор 

	//геттер адреса следующего элемента
	ListItem <T>* get_next()const { 
		return next;
	}

	//геттер адреса предыдущего элемента
    ListItem <T>* get_prev() const{
		return prev;
	}

	//геттер данных
	T get_value() const {
		return value;
	}

	//сеттер адреса следующего элемента
	void set_next(ListItem <T>* new_next) {
		next = new_next;
	}
	//сеттер адреса предыдущего элемента
	void set_prev(ListItem <T>* new_prev) {
		prev = new_prev;
	}
	//сеттер данных
	void set_value(T new_value){

		value = new_value;
	}



	T& Linkget_value() {
		return value;
	}

	

};
