/* 
 * File:   main.c
 * Author: Александр
 *
 * Created on 24 Сентябрь 2013 г., 17:47
 */
#include <math.h>
#include <stdio.h>

short prost(long long n)//для проверки простоты коэфицентов
{
	long long i;
	short k;
	k = 1;
	for(i = 1; i <= sqrt(n); i++)
		if(n % i == 0)
		{
			k += 1;
		}
	return k;
}

int main() 
{
	printf("numbers: ");
	short i, k1;
	long long c;
	k1 = 0;
	//long long c;
	for(i = 2; i <= 31; i++)
	{
		c = pow(2, i) - 1;
		if(prost(c) == 2) 
		{
			k1++;
			printf("%d) %ld\n", k1, c);
		}
	}
	getchar();
	return(0);
}
