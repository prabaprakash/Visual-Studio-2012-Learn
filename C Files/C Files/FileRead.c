#define _CRT_SECURE_NO_DEPRECATE
#include<conio.h>
#include<stdio.h>
FILE *fp;
int main()
{
	printf("Welcome To Files");
	fp=fopen("a.txt","w");
	fprintf(fp,"this is testing");
	fclose(fp);
}
