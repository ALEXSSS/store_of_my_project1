/* 
 * File:   main.c
 * Author: Stanislav Sartasov
 *
 * Created on 11 Декабрь 2013 г., 13:55
 */

#include <stdio.h>
#include <stdlib.h>
#include <time.h>
#include <sys/time.h>
#include "mymalloc.h"

/*
 * 
 */

struct timeval tm1;

void startTime()
{
    gettimeofday(&tm1, NULL);
}

unsigned long long stopTime()
{
    struct timeval tm2;
    gettimeofday(&tm2, NULL);

    unsigned long long t = 1000000 * (tm2.tv_sec - tm1.tv_sec) + (tm2.tv_usec - tm1.tv_usec);
	
	return t;
}

int compare(unsigned int* a, unsigned int* b, int number)
{
	int i;
	for (i = 0; i < number; i++)
	{
		if (a[i] != b[i]) return 0;
	}

	return 1;
}

int main(int argc, char** argv)
{
	int* pointers[700];
	int* myPointers[700];

	myinit();

	int i;
	int validStartIndex = 1;
	int validEndIndex = 0;
	for (i = 1; i < 700; i++)
	{
		struct timespec start;
		
		struct timespec end;

		if (i % 7 >= 5)
		{
			myfree(myPointers[validStartIndex]);
			free(pointers[validStartIndex]);
			validStartIndex++;
		}
		else
	
		{
			myPointers[validEndIndex] = (unsigned int*) mymalloc(sizeof (unsigned int) * i);
			pointers[validEndIndex] = (unsigned int*) malloc(sizeof (unsigned int) * i);
			memcpy(myPointers[validEndIndex], pointers[validEndIndex], sizeof (unsigned int) * i);

			validEndIndex++;
		}
	}

	struct memstat stats;
	mymemstat(&stats);
	int totalMemory;
	
	for (i = validStartIndex; i < validEndIndex; i++)
	{
		if (!compare(pointers[i], myPointers[i], i)) return (EXIT_FAILURE);
		totalMemory += i;
		free(pointers[i]);
		myfree(myPointers[i]);
	}
	
	totalMemory *= sizeof (unsigned int);

	printf("Memory consumption: %d out of %d bytes (%f%%)", totalMemory, stats.allocatedpages * 4096,
		   (float) totalMemory / stats.allocatedpages * 100);

	validStartIndex = 1;
	validEndIndex = 0;
	
	startTime();
	
	for (i = 1; i < 700; i++)
	{
		if (i % 7 >= 5)
		{
			myfree(myPointers[validStartIndex]);
			validStartIndex++;
		}
		else
		{
			myPointers[validEndIndex] = (unsigned int*) mymalloc(sizeof (unsigned int) * i);
			validEndIndex++;
		}
	}
	
	unsigned long long timeMy = stopTime();

	validStartIndex = 1;
	validEndIndex = 0;
	
	startTime();
	
	for (i = 1; i < 700; i++)
	{
		if (i % 7 >= 5)
		{
			free(pointers[validStartIndex]);
			validStartIndex++;
		}
		else
		{
			pointers[validEndIndex] = (unsigned int*) malloc(sizeof (unsigned int) * i);
			validEndIndex++;
		}
	}
	
	unsigned long long timeSystem = stopTime();
	
	for (i = validStartIndex; i < validEndIndex; i++)
	{
		totalMemory += i;
		free(pointers[i]);
		myfree(myPointers[i]);
	}
	
	printf("Throughput: %llu out of %llu us (%f%%)", timeMy,
		   timeSystem, 100.0f*(float) timeMy / (float) timeSystem);

	return (EXIT_SUCCESS);
}