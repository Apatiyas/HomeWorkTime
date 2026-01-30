#pragma once
#include "Engineer.h"
#include "Director.h"
#include "Accountant.h"
#include <vector>
#include <iostream>

class Company {
	std::vector<Employee* > employees;
public:
	Company(std::vector<Employee* > emplist) {
		for (auto& emp : emplist) {
			employees.push_back(emp);
		}
	}
	Company() = default;

	void add_employee(Employee* emp) {
		employees.push_back(emp);
	}

	void print_all_descriptions() {

		for (const auto& emp : employees) {
			std::cout << emp->get_job_description() << "\n\n";
		}
	}

	~Company() {
		for (auto emp : employees) {
			delete emp;
		}
	}
};