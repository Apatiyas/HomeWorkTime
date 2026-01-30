#pragma once
#include <string>
#include <iostream>
#include "Employee.h"

class Director : public Employee {

public:
	Director(std::string name):Employee(name){}
	virtual std::string get_job_description() override {
		return name + " (Director): Set company strategy, lead departments, make high-level decisions.";
	}
};