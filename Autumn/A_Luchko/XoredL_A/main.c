#include <stdio.h>
#include <stdlib.h>

/*
 * 
 */
struct queue {
	int num;
	struct queue *adr;
};
typedef struct queue QUE;

struct start {
	QUE* start;
	QUE* end;
};
typedef struct start ST;

int pop(ST* k, int n)//добавляет
{
	QUE* p = (QUE*) malloc(sizeof(QUE));

	if(k->start == NULL)//если первый
	{
		p->num = n;
		p->adr = NULL;
		k->start = p;
		k->end = p;
	}
	else//если не первый
	{
		p->adr = k->start;
		k->start->adr = p^(k->start->adr);
		p->num = n;
		k->start = p;
	}


}

int dexor(ST* k, int n)//удаляет
{
	int c;
	QUE* p = k->start->adr;
	;
	QUE* p1, p2 = NULL;
	if(k->start == NULL)
	{
		printf("Sorry, is empty.");
	}
	else
	{
		while((p != k->end) && (p->num != n))
		{
			p2 = p;
			p = (p->adr)^p1;
			p1 = p2;
		}
		if((p == k->end) && (k->end->num != n))//первые случаи с проблемным концом
		{
			printf("Element does not exist");
		}
		else
		{
			if((p == k->end) && (k->end->num == n))
			{
				p1->adr = p;
				free(p);
			}
			else
			{
				if(p != k->end)//обычный случай
				{
					QUE* z; //вспомогательная переменная
					z=(p->adr)^p1;//адрес последующего
					p1->adr = (p1->adr | p)^z;//(p1->adr | p) даст обычный адрес до нашего
					z->adr = (z->adr | p)^p1;//перед нашим
					free(p);
				}
			}
		}
	}
}
