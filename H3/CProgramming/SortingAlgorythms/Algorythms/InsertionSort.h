#include <stdio.h>
#include <stdlib.h>
#include <string.h>

// Insertion sort algorythm using pointers
int insertionSort(int *arr, int length)
{
	int i, j, temp;

	// Loops through all numbers
	for (i = 1; i < length; i++)
	{
		// Sets the current number as the temporary number
		temp = *(arr + i);
		j = i - 1;

		// Loops through all numbers before the current number
		while (temp < *(arr + j) && j >= 0)
		{
			// Moves the number to the right
			*(arr + (j + 1)) = *(arr + j);
			j--;
		}

		// Inserts the temporary number
		*(arr + (j + 1)) = temp;
	}
	return 0;
}