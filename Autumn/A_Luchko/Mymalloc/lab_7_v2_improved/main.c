
#include <stdio.h>
#include <stdlib.h>

unsigned char* p;
unsigned char* p1;
int* p2;
int size, work;

void myinit(int n)
{
	int j;
	p = (unsigned char*) malloc(n);
	p2 = (int*) malloc(n * 4);
	size = n;
	if((p == NULL) || (p2 == NULL))
	{
		printf("Sorry, is not exist this number memory");
		work = 0;
	}
	else
	{
		work = 1;
		for(j = 0; j < n; j++)
		{
			p2[j] = -1;
		}
	}
}

void* mymalloc(int n)
{
	if(work == 0)
	{
		printf("Repeat operation myinit, because works memory is not exist\n");
	}
	else
	{
		int i, k = 0, z = 0;
		while((k != n) && (z != size))
		{
			z++;
			if(p2[z - 1] == -1)
			{
				k++;
			}
			else
			{
				k = 0;
			}
		}
		if(z == size)
		{
			if(k == n)
			{
				for(i = 1; i < n; i++)
				{
					p2[size - n + i] = 0;
				}
				p2[size - n] = n;
				return p + (size - n);
			}
			else
			{
				return NULL;
			}
		}
		else
		{
			for(i = 1; i < n; i++)
			{
				p2[z - n + i] = 0;
			}
			p2[z - n] = n;
			return p + (z - n);
		}
	}
}

void myfree(void* k)
{
	int i, j;
	for(i = 0; i < size; i++)
	{
		if(p + i == k)
		{
			break;
		}
	}
	if(p2[i] > 0)
	{
		int chek = p2[i];
		j = i;
		while(j - i != chek)
		{
			p2[j] = -1;
			j++;
		}
		p2[i] = -1;
	}
}

void* myReallock(void* k1, int n)
{
	int i, j;
	if(k1 == NULL)
	{
		void* new1;
		new1 = mymalloc(n);
		return new1;
	}
	else
	{
		for(i = 0; i < size; i++)
		{
			if(p + i == (unsigned char*) k1)
			{
				break;
			}
		}
		if(p2[i] > 0)
		{
			if(p2[i] > n)
			{

				int chek;
				for(chek = i + n; chek != p2[i] + i; chek++)
				{
					p2[chek] = -1;
				}
				p2[i] = n;
				return k1;
			}
			else
			{
				if(p2[i] == n)
				{
					return k1;
				}
				else
				{
					int chek = n - p2[i];
					int i1, k = 1;
					for(i1 = 1; i1 <= chek; i1++)
					{
						if((i1 + i + p2[i] < size) && (p2[i1 + i + p2[i]] == -1))
						{
							k = 1;
						}
						else
						{
							k = 0;
							break;
						}
					}
					if(k == 0)
					{
						void* new1;
						int z, col1;
						col1 = p2[i];
						for(z = 0; z < col1; z++)
						{
							p2[z + i] = -1;
						}
						new1 = mymalloc(n);
						if(new1 != NULL)
						{
							unsigned char* z1 = (unsigned char*) new1;
							for(z = 0; z < col1; z++)
							{
								*(z1 + z) = p[z + i];
							}
							return new1;
						}
					}
					else
					{
						int z;
						for(z = 0; z < n - p2[i]; z++)
						{
							p2[z + i + p2[i]] = 0;
						}
						p2[i] = n;
						return k1;
					}
				}
			}
		}
		else
		{
			void* new1;
			new1 = mymalloc(n);
			return new1;
		}
	}
}