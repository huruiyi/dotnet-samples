//#define _D_SCL_SECURE_NO_WARNINGS
//#include <algorithm>
//#include <array>
//#include <iostream>
//#include <iterator>
//#include <numeric>
//#include <string>
//#include <vector>
//
//using namespace std;
//
//template <typename C> void print(const string& s, const C& c)
//{
//	cout << s;
//
//	for (const auto& e : c)
//	{
//		cout << e << " ";
//	}
//
//	cout << endl;
//}
//
//int main()
//{
//	vector<int> v(16);
//	iota(v.begin(), v.end(), 0);
//	print("v: ", v);
//
//	// OK: vector::iterator is checked in debug mode
//	// (i.e. an overrun will trigger a debug assertion)
//	vector<int> v2(16);
//	transform(v.begin(), v.end(), v2.begin(), [](int n) { return n * 2; });
//	print("v2: ", v2);
//
//	// OK: back_insert_iterator is marked as checked in debug mode
//	// (i.e. an overrun is impossible)
//	vector<int> v3;
//	transform(v.begin(), v.end(), back_inserter(v3), [](int n) { return n * 3; });
//	print("v3: ", v3);
//
//	// OK: array::iterator is checked in debug mode
//	// (i.e. an overrun will trigger a debug assertion)
//	array<int, 16> a4;
//	transform(v.begin(), v.end(), a4.begin(), [](int n) { return n * 4; });
//	print("a4: ", a4);
//
//	// OK: Raw arrays are checked in debug mode
//	// (i.e. an overrun will trigger a debug assertion)
//	// NOTE: This applies only when raw arrays are given to C++ Standard Library algorithms!
//	int a5[16];
//	transform(v.begin(), v.end(), a5, [](int n) { return n * 5; });
//	print("a5: ", a5);
//
//	// WARNING C4996: Pointers cannot be checked in debug mode
//	// (i.e. an overrun will trigger undefined behavior)
//	int a6[16];
//	int * p6 = a6;
//	transform(v.begin(), v.end(), p6, [](int n) { return n * 6; });
//	print("a6: ", a6);
//
//	// OK: stdext::checked_array_iterator is checked in debug mode
//	// (i.e. an overrun will trigger a debug assertion)
//	int a7[16];
//	int * p7 = a7;
//	transform(v.begin(), v.end(), stdext::make_checked_array_iterator(p7, 16), [](int n) { return n * 7; });
//	print("a7: ", a7);
//
//	// WARNING SILENCED: stdext::unchecked_array_iterator is marked as checked in debug mode
//	// (i.e. it performs no checking, so an overrun will trigger undefined behavior)
//	int a8[16];
//	int * p8 = a8;
//	transform(v.begin(), v.end(), stdext::make_unchecked_array_iterator(p8), [](int n) { return n * 8; });
//	print("a8: ", a8);
//}