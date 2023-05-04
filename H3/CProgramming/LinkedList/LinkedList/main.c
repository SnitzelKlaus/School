#include <stdio.h>
#include <stdlib.h>
#include "ChainList.h"

#define LIST_SIZE = 30

void main() {
	insertNodeStart(1);
	insertNodeStart(2);
	insertNodeStart(3);
	insertNodeStart(4);
	insertNodeStart(5);
	insertNodeStart(6);
	insertNodeStart(7);
	insertNodeStart(8);
	insertNodeStart(9);
	insertNodeStart(10);
	insertNodeStart(11);
	insertNodeStart(12);
	insertNodeStart(13);
	insertNodeStart(14);
	insertNodeStart(15);
	insertNodeStart(16);
	insertNodeStart(17);
	insertNodeStart(18);
	insertNodeStart(19);
	insertNodeStart(20);
	insertNodeStart(21);
	insertNodeStart(22);
	insertNodeStart(23);
	insertNodeStart(24);
	insertNodeStart(25);

	insertNodeAtIndex(head->next->next->next->next->next, 420);
	insertNodeAtIndex(head->next->next->next->next->next->next->next->next->next->next->next, 6969);

	printList();
}