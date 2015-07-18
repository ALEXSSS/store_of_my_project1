/* 
 * File:   main.c
 * Author: Александр
 *
 * Created on 23 Сентябрь 2013 г., 12:42
 *
 *программа для проверки простой пифагоровой тройки
 */
#include <math.h>
#include <stdio.h>

int main()  
{
	int a, b, c, mnn, i, k;
	k = 1;
	while(k == 1) 
	{
		printf("Enter the length of the three sides of a right triangle: ");
		if((scanf("%d %d %d", &a, &b, &c) == 3)&&(c + b > a && c + a > b && b + a > c) && (a * a + b * b == c * c || b * b + c * c == a * a || a * a + c * c == b * b)) 
		{
			if (b <= a && b <= c)
			{
				mnn = b;
			} 
			else
				if(a <= b && a <= c) 
			{
				mnn = a;
			} 
			else
				if(c <= a && c <= b) 
			{
				mnn = c;
			}
			//проверка на общий делитель данной тройки           
			for(i = 2; i <= sqrt(mnn); i += 1)
				if(mnn % i == 0 && a % i == 0 && b % i == 0 && c % i == 0)
				{
					i = -2;
					break;
				}
			if(i == -2)
			{
				printf("no simple combination\n");
			} 
			else 
			{
				printf("simple combination\n");
			}
			k = 2;
		} 
		else
		{
			printf("Sorry, error\n");
			scanf("%*[^\n]");
		}
	}
	return(0);
}
