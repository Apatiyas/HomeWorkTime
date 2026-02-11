#pragma once
#pragma once
#include <stdexcept>
#include <iostream>
#include <string>

class file_error : public std::runtime_error {
public:
	file_error(const std::string& _Message) :runtime_error(_Message.c_str()) {}
	file_error(const char* _Message) :runtime_error(_Message) {}
};


class not_found_error : public file_error {
public:

	not_found_error(const std::string& _Message) :file_error(_Message.c_str()) {}
	not_found_error(const char* _Message) :file_error(_Message) {}
};

class access_error : public file_error {
public:

	access_error(const std::string& _Message) :file_error(_Message.c_str()) {}
	access_error(const char* _Message) :file_error(_Message) {}
};


class already_open_error : public file_error {
public:

	already_open_error(const std::string& _Message) :file_error(_Message.c_str()) {}
	already_open_error(const char* _Message) :file_error(_Message) {}
};