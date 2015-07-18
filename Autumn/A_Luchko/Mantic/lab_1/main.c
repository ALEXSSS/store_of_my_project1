#include <stdio.h>
#include <stdlib.h>
#include <math.h>

int main() 
{
	int i, i1, b, j, p;
	int k[3];
	printf("Enter FIO : ");
	char c;
	k[0] = k[1] = k[2] = 0;

	for(i = 0; i < 3; i++) 
	{
		c = getchar();
		while((c != ' ') && (c != '\n')) 
		{
			k[i] += 1;
		   	c = getchar();
		}
	}
	i = k[0] * k[1] * k[2];
	b = binary(&i); //двоичная запись числа i
	p = i + 127; //порядок для вычисления его двоичного представления
	i1 = binary(&p); //двоичное представление порядка (числа p)
	p = pow(10, i-1);
	printf("The number in the binary system: %d\n", b);
	printf("Mantis: 0 %d 0%d", i1, b % p);
	for(j = 0; j < 23 - i; j++) 
	{
		printf("0");
	}
	return(0);
}

int binary(int *p)	//Поступает число в системе счисления по основанию 10
{
	int i2 = *p;
	int a1, n, k;
	long long a2;
	n = a2 = 0;
	k = 1;
	while(i2 > 0)	//переводит изначальное число в систему счисления по основанию 2
	{
		a1 = i2 % 2;
		a2 = a2 + a1 * k;
		k = k * 10;
		i2 = i2 / 2;
		n++;
	}
	*p = n;		//для удобства вернём в пересенную p данные о разрядности a2
	return(a2);	//представление изначального числа по основанию 2
}
