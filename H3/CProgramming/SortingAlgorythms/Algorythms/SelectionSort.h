#include <stdio.h>
#include <stdlib.h>
#include <string.h>

// Selection sorting algorithm using pointers
void selectionSort(int *ptr, int length)
{
	int i, j, tmp;
	int *minVal;

	// Loops through all numbers
	for (i = 0; i < length; i++)
	{
		// Sets start pointer for the minimum value
		*minVal = (&ptr + i);

		for (j = 0; j < i; j++)
		{
			// Checks if the number is smaller than the current minimum
			if (*(ptr + j) < *minVal)
			{
				// Sets a new minimum pointer
				*minVal = (&ptr + j);
			}
		}

		// Swaps the minimum value with the current number in the array
		// This sets minimum values in the beginning of the array
		tmp = *minVal;
		*minVal = *(ptr + i);
		*(ptr + i) = tmp;
	}
	return 0;
}