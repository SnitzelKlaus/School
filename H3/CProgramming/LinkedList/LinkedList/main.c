#include <stdio.h>
#include <stdlib.h>
#include "ChainList.h"

#define LIST_SIZE = 30

void main() {
	insertNodeStart(1);
	insertNodeStart(2);
	insertNodeStart(3);
	insertNodeStart(4);

	deleteFirstNode();
	deleteLastNode();

	printList();
}