// C4996.cpp  
// compile with: /W3  
// C4996 warning expected  
#include <stdio.h>  

// #pragma warning(disable : 4996)  
void func1(void) {
	printf_s("\nIn func1");
}

__declspec(deprecated) void func1(int) {
	printf_s("\nIn func2");
}

int main() {
	func1();
//	func1(1);
}