#pragma once
#define  _CRT_SECURE_NO_WARNINGS//关闭安全检查
#include<stdio.h>
#include<stdlib.h>
#include<string.h>

//加密，按照密码

// 文件加密
// 字符串加密
char * stringjiami(char *password, char *string);
//字符串解密
char * stringjiemi(char *password, char *jiastring);
int  getfilesize(char * path);
void filejiami(char *path, char *pathjia, char *jiapassword[]);
void filejiemi(char *pathjia, char *pathjie, char *jiapassword[]);
