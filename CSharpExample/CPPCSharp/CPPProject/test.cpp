#include <iostream>
#include <vector>
#include <iomanip>
#include <stdarg.h>
#include <windows.h>
using std::cout;
using std::endl;
using std::setw;
using namespace std;

int main1()
{
	int num1{ 1234 }, num2{ 5678 };
	cout << endl;                                // Start on a new line
	cout << setw(10) << num1 << setw(6) << num2;  // Output two values
	cout << endl;                                // Start on a new line
	system("pause");
	return 0;                                    // Exit program
}

void main2()
{
	/*char * chrs;
	cin >> chrs;
	int *p = (int *)chrs;*/
	char  a[10];
	cin >> a;

	cout << *a << endl;
	getchar();
}

int main3()
{
	int x;
	float y;
	cin >> x;
	cout << "The int number is x= " << x << endl;
	cout << "Please input a float number:" << endl;
	cin >> y;
	cout << "The float number is y= " << y << endl;
	getchar();
	return 0;
}

void main4()
{
	vector<int> first;
	vector<int> second;
	vector<int> third;

	first.assign(7, 100);             // 7 ints with a value of 100

	vector<int>::iterator it;
	it = first.begin() + 1;

	second.assign(it, first.end() - 1); // the 5 central values of first

	int myints[] = { 1776, 7, 4 };
	third.assign(myints, myints + 3);   // assigning from array.

	cout << "Size of first: " << int(first.size()) << '\n';
	cout << "Size of second: " << int(second.size()) << '\n';
	cout << "Size of third: " << int(third.size()) << '\n';

	int arr[] = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
	cout << &arr[0];
	for (int i = 0; i < 9; i++)
	{
		cout << arr[i] + "  " << &arr[i] << endl;
	}
	getchar();
}

double average(int num, ...)
{
	va_list valist;
	double sum = 0.0;
	int i;

	/* 为 num 个参数初始化 valist */
	va_start(valist, num);

	/* 访问所有赋给 valist 的参数 */
	for (i = 0; i < num; i++)
	{
		sum += va_arg(valist, int);
	}
	/* 清理为 valist 保留的内存 */
	va_end(valist);

	return sum / num;
}

void main5()
{
	printf("Average of 2, 3, 4, 5 = %f\n", average(4, 2, 3, 4, 5));
	printf("Average of 5, 10, 15 = %f\n", average(3, 5, 10, 15));
	system("pause");
}

int main6()
{
	using namespace std;

	int n_int = INT_MAX;        // initialize n_int to max int value
	short n_short = SHRT_MAX;   // symbols defined in climits file
	long n_long = LONG_MAX;

	long long n_llong = LLONG_MAX;
	long long llmin = LLONG_MIN;

	// sizeof operator yields size of type or of variable
	cout << "int is " << sizeof(int) << " bytes." << endl;
	cout << "short is " << sizeof n_short << " bytes." << endl;
	cout << "long is " << sizeof n_long << " bytes." << endl;
	cout << "long long is " << sizeof n_llong << " bytes." << endl;
	cout << endl;

	cout << "Maximum values:" << endl;
	cout << "int: " << n_int << endl;
	cout << "short: " << n_short << endl;
	cout << "long: " << n_long << endl << endl;

	cout << "long long max: " << n_llong << endl;
	cout << "long long min: " << llmin << endl << endl;

	cout << "Minimum int value = " << INT_MIN << endl;
	cout << "Bits per byte = " << CHAR_BIT << endl;
	cin.get();

	return 0;
}

void main7() {
	while (-1)
	{
		cout << "-11111111111" << endl;
		break;
	}
	while (0)
	{
		cout << "-00000000000" << endl;
		break;
	}
	while (1)
	{
		cout << "+11111111111" << endl;
		break;
	}

	int a = 1;
	do
	{
		cout << a << endl;
		a++;
	} while (a <= 12);
	for (; a < 100; a++)
	{
		cout << a << endl;
	}
	getchar();
}
/*
Data Types
This topic lists the data types most commonly used in the Microsoft Foundation Class Library. Most of the data types are exactly the same as those in the Windows Software Development Kit (SDK), while others are unique to MFC.
Commonly used Windows SDK and MFC data types are as follows: BOOL A Boolean value.
BSTR A 32-bit character pointer.
BYTE An 8-bit integer that is not signed.
COLORREF A 32-bit value used as a color value.
DWORD A 32-bit unsigned integer or the address of a segment and its associated offset.
LONG A 32-bit signed integer.
LPARAM A 32-bit value passed as a parameter to a window procedure or callback function.
LPCSTR A 32-bit pointer to a constant character string.
LPSTR A 32-bit pointer to a character string.
LPCTSTR A 32-bit pointer to a constant character string that is portable for Unicode and DBCS.
LPTSTR A 32-bit pointer to a character string that is portable for Unicode and DBCS.
LPVOID A 32-bit pointer to an unspecified type.
LRESULT A 32-bit value returned from a window procedure or callback function.
UINT A 16-bit unsigned integer on Windows versions 3.0 and 3.1; a 32-bit unsigned integer on Win32.
WNDPROC A 32-bit pointer to a window procedure.
WORD A 16-bit unsigned integer.
WPARAM A value passed as a parameter to a window procedure or callback function: 16 bits on Windows versions 3.0 and 3.1; 32 bits on Win32.
Data types unique to the Microsoft Foundation Class Library include the following:
POSITION A value used to denote the position of an element in a collection; used by MFC collection classes. LPCRECT A 32-bit pointer to a constant (nonmodifiable) RECT structure.
然而，在实际情况中，DWORD会根据操作系统的不同，被定义成了不同的长度，比如vs8(xp)中，DWORD被定义成了如下的类型：
typedef unsigned long DWORD; 而unsigned long 的长度则是4个字节即32位，如果是在64位的操作系统中，这个长度可能会更长，这需要取决于当前操作系统以及开发环境等有关方面，具体可以参考相关的帮助说明！
*/
void main()
{
	int a = 12;
	cout << sizeof(a) << endl;

	DWORD b = 12;
	cout << sizeof(b) << endl;

	getchar();
}