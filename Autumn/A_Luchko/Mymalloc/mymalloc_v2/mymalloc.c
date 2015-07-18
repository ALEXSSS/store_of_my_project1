
#include <stdio.h>
#include <stdlib.h>

unsigned char** first;
unsigned char** boxp;
unsigned char* end;
//int alllocated_pages;
int size, work;

void myinit()
{
	int n = 1024 * 1024 * 128;
	boxp = (unsigned char**) malloc(n);
	first = NULL;
	end = NULL;
	//alllocated_pages = 0;
	size = n;
	if(boxp == NULL)
	{
		printf("Sorry, is not exist this number memory");
		work = 0;
	}
	else
	{
		work = 1;
	}
}

void* mymalloc(int n)
{
	if(n <= 0)
		return NULL;
	if(work == 0)
	{
		printf("Repeat operation myinit, because works memory is not exist\n");
	}
	else
	{
		if(first == NULL)
		{
			if(n + sizeof(unsigned char*) + sizeof(int) <= size)
			{
				first = boxp;
				*boxp = NULL;
				end = ((unsigned char*) boxp + sizeof(int) + sizeof(unsigned char*) +n - 1);
				*(int*) ((char*) boxp + sizeof(unsigned char*)) = n;
				return(void*) ((char*) boxp + sizeof(unsigned char*) + sizeof(int));
			}
			else
			{
				return NULL;
			}
		}
		else
		{
			if(((char*) first - (char*) boxp) + 1 >= n + sizeof(unsigned char*) + sizeof(int))//в начале есть нужный кусок
			{
				unsigned char* z = (unsigned char*) first;
				first = boxp;
				*(int*) ((char*) boxp + sizeof(unsigned char*)) = n; //записали размер
				*first = z; //указатель на другой 
				return(void*) ((char*) boxp + sizeof(unsigned char*) + sizeof(int));
			}
			else
			{
				unsigned char* kfr = *first, *kfr1 = (unsigned char*) first; //kfr1-указывает на первый, kfr-на следующий
				int chek;
				while((kfr != NULL))
				{
					chek = *(int*) ((unsigned char*) (kfr1) + sizeof(unsigned char*));
					if(n + sizeof(unsigned char*) + sizeof(int) <= kfr - kfr1 - chek - 1)
					{
						*(unsigned char**) kfr1 = kfr1 + sizeof(unsigned char*) + sizeof(int)+chek;
						*(unsigned char**) (kfr1 + sizeof(unsigned char*) + sizeof(int)+chek) = kfr;
						*(int*) (kfr1 + 2 * sizeof(unsigned char*) + sizeof(int)+chek) = n;
						return(void*) (kfr1 + 2 * (sizeof(unsigned char*) + sizeof(int)) + chek);
					}
					else
					{
						kfr1 = kfr;
						kfr = *(unsigned char**) kfr;
					}
				}//вышли из цикла не с чем, есть два варианта
				chek = *(int*) ((unsigned char*) (kfr1) + sizeof(unsigned char*));
				if((((unsigned char*) boxp + size - 1) - kfr1 - sizeof(unsigned char*) - sizeof(int)-chek + 1) >= n + sizeof(unsigned char*) + sizeof(int))
				{

					*(unsigned char**) kfr1 = (unsigned char*) (kfr1 + sizeof(unsigned char*) + sizeof(int)+chek);
					*(unsigned char**) (kfr1 + sizeof(unsigned char*) + sizeof(int)+chek) = NULL;
					*(int*) (kfr1 + 2 * sizeof(unsigned char*) + sizeof(int)+chek) = n;
					end = kfr1 + 2 * (sizeof(unsigned char*) + sizeof(int)) + chek + n;
					return(void*) (kfr1 + 2 * (sizeof(unsigned char*) + sizeof(int)) + chek);
				}
				else
				{
					return NULL;
				}
			}
		}
	}
}

int myfree(void* k1)
{
	if(k1 != NULL)
	{
		void* k = (void*) ((unsigned char*) k1 - sizeof(int) - sizeof(unsigned char*));
		unsigned char* p = (unsigned char*) first;
		unsigned char* p1 = NULL;
		if(first != NULL)
		{
			while(((unsigned char*) k != p) && (p != NULL))
			{
				p1 = p;
				p = *(unsigned char**) p;
			}
			if(p == (unsigned char*) k)
			{
				if(p1 == NULL)
				{
					first = (unsigned char**) (*(unsigned char**) p);
				}
				else
				{
					if(p != NULL)
					{
						*(unsigned char**) p1 = *(unsigned char**) p;
					}
					else
					{
						*(unsigned char**) p1 = NULL;
					}
				}
				if(*(unsigned char**) p = NULL)
				{
					end = p1 + sizeof(int) + sizeof(unsigned char*)+*((int*) (p1 + sizeof(unsigned char*))) - 1;
				}
			}
		}
	}
}

void* myReallock(void* k1, int n)
{
	void* k = (void*) ((unsigned char*) k1 - sizeof(int) - sizeof(unsigned char*));
	if(k1 == NULL)
	{
		return mymalloc(n);
	}
	if(n == 0)
	{
		myfree(k);
		return NULL;
	}
	unsigned char* p = (unsigned char*) first, *p1 = NULL;
	while(((unsigned char*) k != p) && (p != NULL))
	{
		p1 = p;
		p = *(unsigned char**) p;
	}
	if(p == (unsigned char*) k)
	{
		int chek = *(int*) (p + sizeof(unsigned char*));
		if(chek >= n)
		{
			*(int*) (p + sizeof(unsigned char*)) = n;
			return(void*) (p + sizeof(int) + sizeof(unsigned char*));
		}
		else
		{
			int i;
			unsigned char* z = p, * k1;
			k1 = (unsigned char*) mymalloc(n);
			if(k1 == NULL)
			{
				myfree(p + sizeof(int) + sizeof(unsigned char*));
				return NULL;
			}
			for(i = 0; i < chek; i++)//взяли старую информацию
			{
				*((unsigned char*) k1 + i) = *((unsigned char*) z + sizeof(int) + sizeof(unsigned char*) +i);
			}
			myfree(p + sizeof(int) + sizeof(unsigned char*));
			return(void*) (k1 + sizeof(int) + sizeof(unsigned char*));
		}
	}
	else
	{
		return NULL;
	}
}

void mydispose()
{
	free(boxp);
}

struct memstat {
	int allocatedpages;
};

void mymemstat(struct memstat* stat)
{
	stat->allocatedpages = end != NULL ? ((end - (unsigned char*) boxp) / 4096 + 1) : 0;
}

