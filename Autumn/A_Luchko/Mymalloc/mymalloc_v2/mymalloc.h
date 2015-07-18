/* 
 * File:   mymalloc.h
 * Author: Stanislav Sartasov
 *
 * Created on 27 Ноябрь 2013 г., 13:58
 */

#ifndef MYMALLOC_H
#define	MYMALLOC_H

#ifdef	__cplusplus
extern "C" {
#endif

struct memstat
{
    int allocatedpages;
};
    
void myinit();

void* mymalloc(size_t size);

void myfree(void* pointer);

void myReallock(void* pointer, size_t newsize);

void mymemstat(struct memstat* stats);

#ifdef	__cplusplus
}
#endif

#endif	/* MYMALLOC_H */

