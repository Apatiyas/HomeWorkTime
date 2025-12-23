#pragma once
#include <iostream>
#include <stdexcept>
enum class TempUnits {
	Fahrenheit,
	Celsius,
	Kelvin,
};



class Temperature {
	TempUnits Type_temp;
	double temp;

public:
	// Конструктор по умолчанию
	Temperature() {
		temp = 0;
		Type_temp = TempUnits::Kelvin;
	}
	// Параметризированный конструктор
	Temperature(double temp, TempUnits Type_temp) {
		setTemp(temp, Type_temp);
	}
	//Метод установки температуры с указанием единиц измерения
	void setTemp(double temp, TempUnits Type_temp) {
		switch (Type_temp) {
		case TempUnits::Fahrenheit:
			if (temp < -459.69) {
				throw std::range_error("Error");
			}
			this->temp = temp;
			this->Type_temp = Type_temp;
			break;
		case TempUnits::Celsius:
			if (temp < -273.15) {
				throw std::range_error("Error");
			}
			this->temp = temp;
			this->Type_temp = Type_temp;
			break;
		case TempUnits::Kelvin:
			if (temp < 0) {
				throw std::range_error("Error");
			}
			this->temp = temp;
			this->Type_temp = Type_temp;
			break;
		default:
			throw std::range_error("Error");
			break;
		}
	}
	// Перегруженный метод установки температуры (только значение)
	void setTemp(double newTemp) {
		setTemp(newTemp, Type_temp);
	}
	// Метод для отображения температуры на экране
	void  display() {
		std::cout << temp;
		char g = 248;
		switch (Type_temp) {
		case TempUnits::Fahrenheit:
			std::cout << g << "F";
			break;
		case TempUnits::Celsius:
			std::cout << g << "C";
			break;
		case TempUnits::Kelvin:
			std::cout << "K";
			break;
		}
		std::cout << std::endl;
	}
	   // Метод конвертации температуры в другие единицы измерения
	void convert_temp(TempUnits other) {
		if (Type_temp == other) {
			return;
		}
		switch (Type_temp) {
		case TempUnits::Fahrenheit:
			if (other == TempUnits::Kelvin) {
				temp = (((temp - 32) * 5) / 9) + 273.15;
			}
			else if (other == TempUnits::Celsius) {
				temp = ((temp - 32) * 5) / 9;
			}
			break;
		case TempUnits::Celsius:
			if (other == TempUnits::Kelvin) {
				temp = temp + 273.15;
			}
			else if (other == TempUnits::Fahrenheit) {
				temp = (temp * (9.0 / 5.0)) + 32;
			}
			break;
		case TempUnits::Kelvin:
			if (other == TempUnits::Celsius) {
				temp = temp - 273.15;
			}
			else if (other == TempUnits::Fahrenheit) {
				temp = ((temp - 273.15) * (9.0 / 5.0)) + 32;
			}
			break;
			
		}
		Type_temp = other;
	}
	// Перегруженный оператор разыменования *
	double operator*() const {
		return temp;
	}
};
