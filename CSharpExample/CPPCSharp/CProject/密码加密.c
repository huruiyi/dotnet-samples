#include"密码加密.h"

int  getfilesize(char * path)
{
	FILE *pf = fopen(path, "r");
	if (pf == NULL)
	{
		return -1;
	}
	else
	{
		fseek(pf, 0, SEEK_END);//文件末尾
		int length = ftell(pf);
		return length;//返回长度
	}
}

char * stringjiami(char *password, char *string)
{
	int passlength = strlen(password);//获取加密长度
	int stringlength = strlen(string);//获取字符串长度
	if (stringlength %passlength == 0)
	{
		int ci = stringlength / passlength;//循环次数
		for (int i = 0; i < ci; i++)//循环次
		{
			for (int j = 0; j < passlength; j++)//循环密码
			{
				string[passlength*i + j] ^= password[j];//异或加密
			}
		}
	}
	else
	{
		int ci = stringlength / passlength;//循环次数
		for (int i = 0; i < ci; i++)//循环次
		{
			for (int j = 0; j < passlength; j++)//循环密码
			{
				string[passlength*i + j] ^= password[j];//异或加密
			}
		}
		int lastlength = stringlength%passlength;//剩下的长度
		for (int i = 0; i < lastlength; i++)
		{
			string[passlength*(stringlength / passlength) + i] ^= password[i];
		}
	}
	return  string;
}
//字符串解密
char * stringjiemi(char *password, char *jiastring)
{
	int passlength = strlen(password);//获取加密长度
	int stringlength = strlen(jiastring);//获取字符串长度
	if (stringlength %passlength == 0)
	{
		int ci = stringlength / passlength;//循环次数
		for (int i = 0; i < ci; i++)//循环次
		{
			for (int j = 0; j < passlength; j++)//循环密码
			{
				jiastring[passlength*i + j] ^= password[j];//异或加密
			}
		}
	}
	else
	{
		int ci = stringlength / passlength;//循环次数
		for (int i = 0; i < ci; i++)//循环次
		{
			for (int j = 0; j < passlength; j++)//循环密码
			{
				jiastring[passlength*i + j] ^= password[j];//异或加密
			}
		}
		int lastlength = stringlength%passlength;//剩下的长度
		for (int i = 0; i < lastlength; i++)
		{
			jiastring[passlength*(stringlength / passlength) + i] ^= password[i];
		}
	}
	return  jiastring;
}

void filejiami(char *path, char *pathjia, char *password)
{
	FILE *pfr, *pfw;
	pfr = fopen(path, "rb");
	pfw = fopen(pathjia, "wb");
	if (pfr == NULL || pfw == NULL)
	{
		fclose(pfr);
		fclose(pfw);
		return;
	}
	else
	{
		int length = getfilesize(path);//获取长度   430
									   //int passlength = strlen(password);//获取密码20
		char *newstr = (char*)malloc(sizeof(char)*(length + 1));
		for (int i = 0; i < length; i++)
		{
			char ch = fgetc(pfr);//获取一个字符
			newstr[i] = ch;//不断存入字符
		}
		newstr[length] = '\0';//字符串处理为'\0'
		stringjiami(password, newstr);//加密字符串
		for (int i = 0; i < length; i++)
		{
			fputc(newstr[i], pfw);//挨个写入字符
		}
		fclose(pfr);
		fclose(pfw);//关闭文件
		free(newstr);
	}
}

void filejiemi(char *pathjia, char *pathjie, char *password[])
{
	FILE *pfr;
	FILE *pfw;
	pfr = fopen(pathjia, "rb");
	pfw = fopen(pathjie, "wb");
	if (pfr == NULL || pfw == NULL)
	{
		fclose(pfr);
		fclose(pfw);
		return;
	}
	else
	{
		while (!feof(pfr))
		{
			char str[1024] = { 0 };
			fgets(str, 1024, pfr);
			stringjiemi(password, str);//加密啊
			fputs(str, pfw);//写入jie密文件
		}
		fclose(pfr);
		fclose(pfw);//关闭文件
	}
}