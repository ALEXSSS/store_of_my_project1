#include <stdio.h>
#include <stdlib.h>

/*
 * 
 */
int main()
{
	long long n, p = 0, k = 0;

	while(k == 0)
	{
		printf("Enter the number: ");

		if(scanf("%d", &n) == 1)
		{
			delivery(&p, n, 200);
			printf("Number of cases: %d", p);
			k = 1;
			getchar();
			getchar();
		}
		else
		{
			printf("Sorry, error datum. Enter an integer.\n");
			scanf("%*[^\n]");
		}
	}
}

int delivery(int* p, int k, int max)
{
	if(k > 0)
	{
		if(max == 200)
		{
			delivery(p, k - 200, 200);
			*p = *p + tis(200, k);
		}
		if(max >= 100)
		{
			delivery(p, k - 100, 100);
			*p = *p + tis(200, k);
		}
		if(max >= 50)
		{
			delivery(p, k - 50, 50);
			*p = *p + tis(50, k);
		}
		if(max >= 25)
		{
			delivery(p, k - 25, 25);
			*p = *p + tis(25, k);
		}
		if(max >= 10)
		{
			delivery(p, k - 10, 10);
			*p = *p + tis(10, k);
		}
		if(max >= 5)
		{
			delivery(p, k - 5, 5);
			*p = *p + tis(5, k);
		}
		if(max >= 1)
		{
			delivery(p, k - 1, 1);
			*p = *p + tis(1, k);
		}




	}
}

int tis(int m, int n)
{
	if(m - n == 0)
	{
		return 1;
	}
	else
	{
		return 0;
	}
}

