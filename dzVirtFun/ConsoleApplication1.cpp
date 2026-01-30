
#include <iostream>
#include "Company.h"
#include <vector>
#include "Engineer.h"
#include "Director.h"
#include "Accountant.h"

int main()
{
    Company company1({
        new Engineer("Anton"),
        new Director("Peter"),
        new Accountant("Jon")
    });
    company1.add_employee(new Engineer("Vlad"));
    company1.add_employee(new Engineer("Victor"));
    company1.add_employee(new Engineer("Oleg"));

    company1.print_all_descriptions();
}