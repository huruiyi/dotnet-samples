#pragma once

class UserInfo {
private:
	char* m_Name;
	int m_Age;
public:
	UserInfo(char* name, int age)
	{
		m_Name = name;
		m_Age = age;
	}
	virtual ~UserInfo() { }
	int GetAge() { return m_Age; }
	char* GetName() { return m_Name; }
};