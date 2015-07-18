#include <stdio.h>
#include <stdlib.h>


int main()
{
	short k = 1;
	int n;
	while(k == 1)
	{
		printf("Enter the number: ");
		if((scanf("%d", &n) == 1)&&(n >= 0))
		{
			if(n == 0)
			{
				printf("Number of options: 0");
				k=2;
				getchar();
				getchar();
			}
			else
			{

				int j;
				int i, z;
				int coins[8] = {1, 2, 5, 10, 25, 50, 100, 200};
				long long* num[8];
				for(i = 0; i < 8; i++)//создание массива вариантов
				{
					num[i] = (long long*) malloc(n * (sizeof(long long)));
				}
				for(j = 0; j < 8; j++)//обнуление массива вариантов
					for(i = 0; i < n; i++)
					{
						num[j][i] = 0;
					}
				for(i = 0; i <= n; i++)//создание матрицы вариантов, с еденичной строчкой и столбцом
					num[0][i] = 1;
				for(j = 0; j < 8; j++)
					num[j][0] = 1;

				int b; //побочная переменная для подсчёта кол-во вариантов
				for(j = 1; j < 8; j++)//заполнение матрицы
					for(i = 1; i < n; i++)
					{

						b = i + 1;
						while(b >= 0)
						{
							if(b == 0)
							{
								num[j][i]++;
								b = -1;
							}
							else
							{
								num[j][i]  += num[j - 1][b - 1];
								b = b - coins[j];
							}
						}


					}
				printf("Number of options: %ld", num[7][n - 1]);
				k = 2;
				getchar();
				getchar();
			}
		}
		else
		{
			printf("Sorry, error datum.\n");
			scanf("%*[^\n]");
		}

	}
}

