#include <stdio.h>
#include <string.h>

// Function to sort the numbers using pointers
void bubbleSort(int length, int* ptr)
{
	int i, j, tmp;

	// Sort the numbers using pointers
	for (i = 0; i < length; i++) {
		for (j = i + 1; j < length; j++) {
			if (*(ptr + j) < *(ptr + i)) {
				tmp = *(ptr + i);
				*(ptr + i) = *(ptr + j);
				*(ptr + j) = tmp;
			}
		}
	}
}