#define  _CRT_SECURE_NO_WARNINGS//关闭安全检查
#include"密码加密.h"

void   main01()
{
	char *path = "C:\\Users\\jie\\Desktop\\原.txt";
	char *pathjia = "C:\\Users\\jie\\Desktop\\加密.txt";
	char *pathjie = "C:\\Users\\jie\\Desktop\\解密.txt";
	char *jiapassword[20] = { 0 };
	char *jiepassword[20] = { 0 };
	printf("请输入加密密码：");
	scanf("%s", &jiapassword);

	printf("%s\n", jiapassword);
		filejiami(path, pathjia, jiapassword);
		printf("请输入解密密码：");
	AA:
		scanf("%s", &jiepassword);
		if (*jiapassword != *jiepassword)
		{
			printf("两次密码不一致，请重新输入解密密码：");
			goto AA;
		}
		filejiami(pathjia, pathjie, jiepassword);
		printf("解密成功！");
	system("pause");
}