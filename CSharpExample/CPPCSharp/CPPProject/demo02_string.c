/* memcpy example */
#define _CRT_SECURE_NO_WARNINGS

#include <stdio.h>
#include <string.h>
/*
http://www.cplusplus.com/reference/cstring/
*/
struct {
	char name[40];
	int age;
} person, person_copy;

/*
Copying:memcpy,memmove,strcpy,strncpy
*/
void Copying_memcpy()
{
	char myname[] = "Pierre de Fermat";

	/* using memcpy to copy string: */
	memcpy(person.name, myname, strlen(myname) + 1);
	person.age = 46;

	/* using memcpy to copy structure: */
	memcpy(&person_copy, &person, sizeof(person));

	printf("person_copy: %s, %d \n", person.name, person.age);
	printf("person_copy: %s, %d \n", person_copy.name, person_copy.age);

	getchar();
}
void Copying_memmove()
{
	char str[] = "memmove can be very useful......";
	memmove(str + 20, str + 15, 11);
	puts(str);

	getchar();
}
void Copying_strcpy()
{
	char str1[] = "Sample string";
	char str2[40];
	char str3[40];
	strcpy(str2, str1);
	strcpy(str3, "copy successful");
	printf("str1: %s\nstr2: %s\nstr3: %s\n", str1, str2, str3);
	getchar();
}
void Copying_strncpy()
{
	char str1[] = "To be or not to be";
	char str2[40];
	char str3[40];

	/* copy to sized buffer (overflow safe): */
	strncpy(str2, str1, sizeof(str2));

	/* partial copy (only 5 chars): */
	strncpy(str3, str2, 5);
	str3[5] = '\0';   /* null character manually added */

	puts(str1);
	puts(str2);
	puts(str3);
	getchar();
}

/*
Concatenation:strcat,strncat
*/
void Concatenation_strcat()
{
	char str[80];
	strcpy(str, "these ");
	strcat(str, "strings ");
	strcat(str, "are ");
	strcat(str, "concatenated.");
	puts(str);
	getchar();
}
void Concatenation_strncat()
{
	char str1[20];
	char str2[20];
	strcpy(str1, "To be ");
	strcpy(str2, "or not to be");
	strncat(str1, str2, 6);
	puts(str1);
	getchar();
}

/*
Comparison:memcmp,strcmp,strcoll,strncmp,strxfrm
*/
void Comparison_memcmp()
{
	char buffer1[] = "DWgaOtP12df0";
	char buffer2[] = "DWGAOTP12DF0";

	int n;

	n = memcmp(buffer1, buffer2, sizeof(buffer1));

	if (n > 0) printf("'%s' is greater than '%s'.\n", buffer1, buffer2);
	else if (n < 0) printf("'%s' is less than '%s'.\n", buffer1, buffer2);
	else printf("'%s' is the same as '%s'.\n", buffer1, buffer2);
	getchar();
}
void Comparison_strcmp()
{
	char key[] = "apple";
	char buffer[80];
	do {
		printf("Guess my favorite fruit? ");
		fflush(stdout);
		scanf("%79s", buffer);
	} while (strcmp(key, buffer) != 0);
	puts("Correct answer!");
	getchar();
}
void Comparison_strcoll()
{
}
void Comparison_strncmp()
{
	char str[][5] = { "R2D2" , "C3PO" , "R2A6" };
	int n;
	puts("Looking for R2 astromech droids...");
	for (n = 0; n < 3; n++)
		if (strncmp(str[n], "R2xx", 2) == 0)
		{
			printf("found %s\n", str[n]);
		}
	getchar();
}
void Comparison_strxfrm()
{
}

/*
Searching:memchr,strchr,strcspn,strpbrk,strrchr,strspn,strstr,strtok
*/
void Searching_memchr()
{
	char * pch;
	char str[] = "Example string";
	pch = (char*)memchr(str, 'p', strlen(str));
	if (pch != NULL)
		printf("'p' found at position %d.\n", pch - str + 1);
	else
		printf("'p' not found.\n");

	getchar();
}
void Searching_strchr()
{
	char str[] = "This is a sample string";
	char * pch;
	printf("Looking for the 's' character in \"%s\"...\n", str);
	pch = strchr(str, 's');
	while (pch != NULL)
	{
		printf("found at %d\n", pch - str + 1);
		pch = strchr(pch + 1, 's');
	}
	getchar();
}
void Searching_strcspn()
{
	char str[] = "fcba73";
	char keys[] = "1234567890";
	int i;
	i = strcspn(str, keys);
	printf("The first number in str is at position %d.\n", i + 1);
	getchar();
}
void Searching_strpbrk()
{
	char str[] = "This is a sample string";
	char key[] = "aeiou";
	char * pch;
	printf("Vowels in '%s': ", str);
	pch = strpbrk(str, key);
	while (pch != NULL)
	{
		printf("%c ", *pch);
		pch = strpbrk(pch + 1, key);
	}
	printf("\n");
	getchar();
}
void Searching_strrchr()
{
	char str[] = "This is a sample string";
	char * pch;
	pch = strrchr(str, 's');
	printf("Last occurence of 's' found at %d \n", pch - str + 1);
	getchar();
}
void Searching_strspn()
{
	int i;
	char strtext[] = "129th";
	char cset[] = "1234567890";

	i = strspn(strtext, cset);
	printf("The initial number has %d digits.\n", i);
	getchar();
}
void Searching_strstr()
{
	char str[] = "This is a simple string";
	char * pch;
	pch = strstr(str, "simple");
	strncpy(pch, "sample", 6);
	puts(str);
	getchar();
}
void Searching_strtok()
{
	char str[] = "- This, a sample string.";
	char * pch;
	printf("Splitting string \"%s\" into tokens:\n", str);
	pch = strtok(str, " ,.-");
	while (pch != NULL)
	{
		printf("%s\n", pch);
		pch = strtok(NULL, " ,.-");
	}
	getchar();
}

/*
Other:memset,strerror,strlen
*/
void Other_memset()
{
	char str[] = "almost every programmer should know memset!";
	memset(str, '-', 6);
	puts(str);
	getchar();
}
void Other_strerror()
{
	FILE * pFile;
	pFile = fopen("unexist.ent", "r");
	if (pFile == NULL)
		printf("Error opening file unexist.ent: %s\n", strerror(errno));
	getchar();
}
void Other_strlen()
{
	char szInput[256];
	printf("Enter a sentence: ");
	gets(szInput);
	printf("The sentence entered is %u characters long.\n", (unsigned)strlen(szInput));
	getchar();
}

/*
Macros:NULL
*/

/*
Types:size_t
Unsigned integral type
Alias of one of the fundamental unsigned integer types.

It is a type able to represent the size of any object in bytes: size_t is the type returned by the sizeof operator and is widely used in the standard library to represent sizes and counts.

In <cstring>, it is used as the type of the parameter num in the functions memchr, memcmp, memcpy, memmove, memset, strncat, strncmp, strncpy and strxfrm, which in all cases it is used to specify the maximum number of bytes or characters the function has to affect.

It is also used as the return type for strcspn, strlen, strspn and strxfrm to return sizes and lengths.
*/

void GetsDemo()
{
	char string[256];
	printf("Insert your full address: ");
	gets(string);     // warning: unsafe (see fgets instead)
	printf("Your address is: %s\n", string);
	getchar();
}
void PutsDemo()
{
	char string[] = "Hello world!";
	puts(string);
	getchar();
}

void main()
{
	//getc
	//putc

	//getchar
	//putchar

	//fgetc
	//fputc

	//fgetchar
	//fputchar

	//fgetpos

	//fgetwc
	//fputwc

	//fgetws
	//fputws

	//_fgetchar
	//_fputchar

	//_fgetc_nolock
	//_fputc_nolock

	//_fgetwchar
	//_fputwchar

	//_fgetwc_nolock
	//_fputwc_nolock

	//gets
	//puts

	PutsDemo();
}