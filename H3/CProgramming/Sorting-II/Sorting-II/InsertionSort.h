#include <stdio.h>
#include <stdlib.h>
#include <string.h>

// Function to sort the numbers using pointers
void insertionSort(int* ptr, int length) {
	int i, j;

	for (i = 0; i < length; i++) {
		for (j = 0; j < i; j++) {
			if (*(ptr + i) < *(ptr + j)) 
			{
				*(ptr + i) = *(ptr + j);
				*(ptr + j) = *(ptr + i);
				break;
			}
		}
	}
}