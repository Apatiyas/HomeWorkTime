#include <iostream>
#include "ReadFile.h"
#include "FileName.h"
#include <stdexcept>
#include "stream_execeptions.h"

int main()
{
	try {
		ReadFile file("stih.txt");
		file.read_text();
		file.close();
		
	}
	catch (const not_found_error& e) {
		std::cerr << "error:" << e.what() << std::endl;
	}
	catch (const std::exception& e) {
		std::cerr << "error:" << e.what() << std::endl;
	}


}

