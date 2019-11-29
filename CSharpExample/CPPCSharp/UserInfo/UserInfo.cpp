#include"pch.h"
#include <string.h>
#include <stdio.h>
#include "malloc.h"
#include "UserInfo.h"

extern "C" __declspec(dllexport) int Add(int x, int y)
{
	return x + y;
}
extern "C" __declspec(dllexport) int Sub(int x, int y)
{
	return x - y;
}
extern "C" __declspec(dllexport) int Multiply(int x, int y)
{
	return x * y;
}
extern "C" __declspec(dllexport) int Divide(int x, int y)
{
	return x / y;
}

typedef struct {
	char name[32];
	int age;
} User;

UserInfo* userInfo;

extern "C" __declspec(dllexport) User * Create(char* name, int age)
{
	User* user = (User*)malloc(sizeof(User));
	if (user) {
		userInfo = new UserInfo(name, age);
		strcpy_s(user->name, userInfo->GetName());
		user->age = userInfo->GetAge();
	}
	return user;
}