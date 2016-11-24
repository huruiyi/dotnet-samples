#include <iostream>
#include <vector>
#include <iomanip>
#include <stdarg.h>
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
int main()
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