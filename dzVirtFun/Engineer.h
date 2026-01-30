#pragma once
#include <string>
#include <iostream>
#include "Employee.h"

class Engineer : public Employee {

public:
	Engineer(std::string name) :Employee(name) {}
	virtual std::string get_job_description() override {
		return name + " (Engineer): Design and develop technical systems, perform calculations, create prototypes.";
	}
};