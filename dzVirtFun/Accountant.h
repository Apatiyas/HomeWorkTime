#pragma once
#include <string>
#include <iostream>
#include "Employee.h"

class Accountant : public Employee {

public:
	Accountant(std::string name) :Employee(name) {}
	virtual std::string get_job_description() override {
		return name + " (Accountant): Manage financial records, prepare reports, handle taxes and audits.";
	}
};