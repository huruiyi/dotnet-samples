// arrfun1.cpp -- functions with an array argument
#include <iostream>
const int ArSize = 8;

// return the sum of an integer array
int sum_arr1(int arr[], int n)
{
	int total = 0;

	for (int i = 0; i < n; i++)
		total = total + arr[i];
	return total;
}

int main03()
{
	using namespace std;
	int cookies[ArSize] = { 1,2,4,8,16,32,64,128 };
	// some systems require preceding int with static to
	// enable array initialization

	int sum = sum_arr1(cookies, ArSize);
	cout << "Total cookies eaten: " << sum << "\n";
	// cin.get();
	return 0;
}