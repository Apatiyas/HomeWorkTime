#pragma once
#include <iostream>
#include <stdexcept>
#include <chrono>
#include <thread>

using USHORT = unsigned short;
using UCHAR = unsigned char;

class Snowflake
{
	USHORT row;		
	USHORT col;		
	float speed;	
	UCHAR melt;		
	
public:
	static USHORT max_row;		
	static float speed_base;
	static std::mutex mtx;		
	

	// Constructor
	Snowflake(USHORT row, USHORT col, float speed) {
		if (Snowflake::max_row == 0) {
			throw std::runtime_error("Landscape didn't set the max row value");
		}
		this->row = row;
		this->col = col;
		this->speed = speed;
		this->melt = 255;
	}


	// Draw snowflake on the screen
	void draw() {
		mtx.lock();
		// Set cursor position
		std::cout << "\x1b[" << row << ";" << col << "H";
		// Set color
		std::cout << "\x1b[38;2;" << (short)melt << ";" << (short)melt << ";" << (short)melt << "m";
		// Print star
		std::cout << '*';
		mtx.unlock();

	}
	void melting() {// Set cursor position
		while (melt > 0) {
			mtx.lock();
			std::cout << "\x1b[" << row << ";" << col << "H";
			// Set color
			std::cout << "\x1b[38;2;" << (short)melt << ";" << (short)melt << ";" << (short)melt << "m";
			// Print star
			std::cout << '*';
			mtx.unlock();

			std::this_thread::sleep_for(std::chrono::milliseconds(int(speed_base / speed)));
			if (melt >= 5) {
				melt -= 5;
			}
			else {
				melt = 0; 
			}

		}
		erase();
	}

	// Hide snowflake from screen
	void erase() {
		mtx.lock();
		// Set cursor position
		std::cout << "\x1b[" << row << ";" << col << "H";
		// Print space
		std::cout << ' ';
		mtx.unlock();
	}


	// Fall from current R position to max_row (bottom of the screen)
	void fall() {
		while (this->row < Snowflake::max_row) {
			erase();
			row++;
			draw();
			std::this_thread::sleep_for(std::chrono::milliseconds(int(speed_base / speed)));
			
		}
		if (this->row == Snowflake::max_row) {
			std::thread melt_thread(&Snowflake::melting, this);
			melt_thread.detach(); // 

		}
	}

};

USHORT Snowflake::max_row = 0;
float Snowflake::speed_base = 20;
std::mutex Snowflake::mtx;
