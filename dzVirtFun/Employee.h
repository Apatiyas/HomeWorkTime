#pragma once
#include <string>
#include <iostream>


class Employee {
protected:
    std::string name;
	Employee(std::string name) 
		: name(name) {}
public:
	virtual std::string get_job_description() = 0;
	virtual ~Employee() {}
};