/* 
 * File:   main.c
 * Author: Александр
 *
 * Created on 26 Ноябрь 2013 г., 22:50
 */

#include <stdio.h>
#include <stdlib.h>

int main()
{
	printf("Program to find the sum of the digital roots.\n");
	short k = 1;
	long long dr1, sum;
	int n, i, j;
	while(k == 1)
	{
		printf("\n");
		
		
		
		printf("Enter positive integer or zero: ");
		if((scanf("%d", &n) == 1)&& (n >= 0))
		{
			if(n == 0)
			{
				printf("\nMax divigion root in divisors: 0");
				k = 2;
			}
			else
			{
				long long* dr = (long long*) malloc(n * sizeof(long long));
				dr[0] = 1;
				for(i = 1; i < n; i++)
				{
					dr[i] = (i + 1) % 9;
					if(dr[i] == 0)
					{
						dr[i] = 9;
					}
				}
				for(i = 2; i <= n; i++)
				{
					for(j = 2; j <= i; j++)
					{

						if(j * i <= n)
						{
							if(dr[j * i - 1]<(dr[j - 1] + dr[i-1]))
							{
								dr[j * i  - 1] = (dr[j-1] + dr[i-1]);
							}
						}
						else
						{
							break;
						}
					}
				}
				k = 2;
				for(i = 0; i < n; i++)
				{

					sum += dr[i];
					//printf("\n%d)%ld   summ=%ld", i + 1, dr[i], sum);
				}
				printf("\nThe sum of the digital roots of 1 to %d: %ld", n, sum);
			}
		}
		else
		{
			printf("Sorry, error datum.\n");
			scanf("%*[^\n]");
		}
	}
	getchar();
	getchar();
}
