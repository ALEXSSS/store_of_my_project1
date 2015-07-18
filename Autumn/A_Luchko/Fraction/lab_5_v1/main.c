#include <stdio.h>
#include <stdlib.h>
#include <math.h>

/*
 * программа по выводу квадратного корня периодической дробью, если это надо
 */
int main()
{
	short k;
	int a, as, as1, z, d; //as1 служит для запоминания as

	printf("Program to find the root of the continued fraction.\n");
	k = 1;
	while(k == 1)
	{
		printf("Enter number: ");
		if(scanf("%d", &a) == 1)
		{
			if(sqrt(a) == (int) sqrt(a))
			{
				a = sqrt(a);
				printf("sqrt(a)=%d", a);
				k = 2;
			}
			else
			{

				as = (int) sqrt(a);
				z = 1;
				d = 0;
				int k = 0;
				as1 = as;
				printf("Expansion of the root of the continued fraction: %d,[", as);
				while((as != 2 * as1))
				{

					d = z * as - d;
					z = (a - d * d) / z;
					as = (as1 + d) / z;
					if(k == 0)
					{
						printf("%d", as);
						k = 1;
					}
					else
					{
						printf(",%d", as);
					}
				}
				printf("]");
				k = 2; //означает корректное завершение программы
			}
		}
		else
		{
			printf("Sorry, error enter datum.\n");
			scanf("%*[^\n]");
		}
	}
	getchar();
	getchar();
	return(0);
}