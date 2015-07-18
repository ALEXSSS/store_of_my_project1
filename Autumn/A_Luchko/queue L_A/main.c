
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

int main(int argc, char** argv)
{
	int i,k,n,a,a1;
	QUE* Start = NULL;//начало очереди
	QUE* End = NULL;//конец очереди
    printf("How many  elements? ");
	scanf("%d",&a);
	for(i=1; i<=a;i++)
	{
		printf("%d)Enter number: ",i);
		scanf("%d",n);
	inqueue(&Start,&End,n);
	}
	 printf("How many  elements in exit? ");
	scanf("%d",&a1);
	for(i=1; i<=a;i++)
	{
	dequeue(&End);
	}




	return (EXIT_SUCCESS);
}

int inqueue(QUE **st, QUE **st1, int n)//добавляет в очередь
{
	QUE* p = (QUE*) malloc(sizeof (QUE));

	if ((*st == NULL) && (*st1 == NULL))//если первый
	{
		p->num = n;
		p->adr = NULL;
		*st = p;
		*st1 = p;
	}
	else//если не первый
	{
		(*st)->adr = p;
		p->num = n;
		p->adr = NULL;
		*st = p;
	}


}
int dequeue(QUE **st)//На вход получаем конец очереди &Myeuque1
{
	QUE* p;
	int n=0;
if((*st == NULL))
{
	printf("Sorry, is empty.");
}
else
{
	n=(*st)->num;
	p=(*st)->adr;
	free(*st);
	*st=p;
	printf("num=%d\n",n);	
	}
}

