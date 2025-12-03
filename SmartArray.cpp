

#include <iostream>

class SmartArray {
	int* arr;
	int initial_size;
	
	int size;
	
public:
	SmartArray() {
		initial_size = 10;
		arr = new int[initial_size];
		
		size = 0;
	}

	

	 void resizeArr() {
		 int resizeStep = initial_size * 2;
		 int* temporaryArr = new int[resizeStep]();
		
		 for (int i = 0; i < size; i++) {
			 temporaryArr[i] = arr[i];
		 }
		 delete[] arr;
		 arr = temporaryArr;

		 initial_size = resizeStep;
	 }
	 ~SmartArray() {
		 delete[] arr;
	 }
	 void insert(int element, int index){


		 if (index < 0 || index > size) {
			 throw std::overflow_error("Index out of bounds");
		 }


		
		 if (size >= initial_size) {
			 resizeArr();
		 }

		
		 for (int i = size; i > index; i--) {
			 arr[i] = arr[i - 1];
		 }

		 arr[index] = element;
		 size += 1;
	 
	 
	 }


	 void push(int element) {
		 if (size >= initial_size) {
			
			 resizeArr();
		 }
	
			 arr[size] = element;
		
		 size += 1;
		
	 }

	 void print() {
		 for (int i = 0; i < size; i++) {
			 std::cout << arr[i]<<std::endl;
		 }
	 }
	 int& operator[](int index) {
		 if (index < 0 || index >= size) {  
			 throw std::overflow_error("Index out of bounds");
		 }
		 return arr[index];
	 }

	const int& operator[](int index)const {
		 if (index < 0 || index >= size) {
			 throw std::overflow_error("Index out of bounds");
		 }
		 return arr[index];
	 }
};

int main()
{
	SmartArray arr1;



	arr1.push(3);
	arr1.push(2);
	arr1.insert(5, 2);
	arr1.print();
	try{
		arr1.insert(7, 4);
	}
	catch (std::overflow_error& error) {
		std::cout << error.what() << std::endl;
	}

	try {
		std::cout << arr1[21];
	}
	catch (std::overflow_error& error) {
		std::cout << error.what() << std::endl;
	}
}

