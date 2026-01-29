#pragma once
#include "Date.h"
#include <iostream>
#include <stdexcept>

class SmartDate : public top::Date {

public:
	SmartDate(top::uchar day, top::uchar month, top::ushort year) : top::Date(day, month, year) { set(day, month, year); }
	
	//SmartDate(top::Date date) : top::Date(date) {}
	void set(top::uchar day, top::uchar month, top::ushort year) {
		bool leapyear = ((year % 4 == 0) && (year % 100 != 0 || year % 400 == 0));

		Date::set(day, month , year);
		
		switch (month) {
		case 1: case 3: case 5: case 7: case 8: case 10: case 12:
			if (day > 31) {
				throw std::out_of_range("Day is out of range (max 31 for this month)");
			}
			break;
		case 4: case 6: case 9: case 11:
			if (day > 30) {
				throw std::out_of_range("Day is out of range (max 30 for this month)");
			}
			break;
		case 2:
			if (leapyear) { if (day > 29) { throw std::out_of_range("Day is out of range (max 29 for this month)"); } }
			else { if (day > 28) { throw std::out_of_range("Day is out of range (max 28 for this month)"); } }
			break;
		}
		
	}

}; 
