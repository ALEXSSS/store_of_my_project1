/* 
 * File:   main.c
 * Author: Александр
 *
 * Created on 20 Октябрь 2013 г., 0:30
 */

#include <stdio.h>
#include <stdlib.h>

/*
 * 
 */
int k = 0;

struct eque {
	int num;
	struct eque* adr;
};
typedef struct eque EQUE;
EQUE* ADR1 = NULL;
EQUE* ADR2 = NULL;

int newl(int a)
{
	if (k = 0)
	{
		EQUE* p = (EQUE*) malloc(sizeof (EQUE));
		p->adr = ADR1;
		p->num = a;
		ADR1 = p;
		ADR2 = p;
		k++;
	} else
	{
		EQUE* p = (EQUE*) malloc(sizeof (EQUE));
		p->adr = ADR1;
		p->num = a;
		ADR1 = p;
		k++;
	}
}

int exitl()
{
	int i;
	EQUE* p = ADR1;
	for (i = 2; i <= k - 2; i++)
	{
		p = p->adr;
	}
	free(ADR2);
	ADR2 = p;
}

int main()
{
	short i, k;
	int a;

	for (i = 1; i < 9; i++)
	{
		printf("%d)Put in place the number?: ", i);
		scanf("%d/n", &a);
		newl(a);
	}
	printf("How to show?: ");
	scanf("%d", &k);
	for (i = 1; i <= k; i++)
	{
		if (i != k)
		{
			printf("%d,", ADR2->num);
			exitl();
		}
		else
		{
			printf("%d", ADR2->num);
			exitl();
		}
	}
	getchar();
	getchar();
	return (0);
}