#ifdef _WIN32
#define _CRT_SECURE_NO_DEPRECATE
#endif
#include<conio.h>
#include<stdio.h>

//int main()
//{
//	printf("Welcome To Files");
//	fp=fopen("a.txt","w");
//	fprintf(fp,"this is testing");
//	fclose(fp);
//
//}

int main()
{
	
	FILE *fp,*fw;
	struct MyStruct
	{
    char deptNo[20],empName[20],empId[20];
	int basicSalary,days;
	};
	struct MyStruct e[10]
	;
	int i=0;
	double salary[10];
	printf("Powerful IDE With Powerful Language -> C Files\n");
	fp=fopen("employ.txt","r");

	while (fscanf(fp,"%s %s %s %d %d",e[i].deptNo,e[i].empName,e[i].empId,&e[i].basicSalary,&e[i].days)!=EOF)
	{
		printf("%s %s %s %d %d ",e[i].deptNo,e[i].empName,e[i].empId,e[i].basicSalary,e[i].days);
		salary[i]=(e[i].basicSalary+(e[i].basicSalary*0.75)+(e[i].basicSalary*0.3))/(30*e[i].days);
		printf("%f\n",salary[i]);
		i++;
		
	}
	fw=fopen("final.txt","w");
	for (int j= 0; j< i; j++)
	{
		fprintf(fw,"%s %s %s %d %d %f\n",e[j].deptNo,e[j].empName,e[j].empId,e[j].basicSalary,e[j].days,salary[j]);
		fflush(fw);
	
	}
	fclose(fw);
	fclose(fp);
	int a=NULL;
		scanf("%d",a);
	
	}



