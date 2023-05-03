#include <stdio.h>
#include <stdlib.h>
#include <string.h>

// Insertion sort algorythm using pointers
int insertionSort(int* ptr, int length)
{
	int i, j, temp;

	// Loops through all numbers
	for (i = 1; i < length; i++)
	{
		// Sets the current number as the temporary number
		temp = *(ptr + i);
		j = i - 1;

		// Loops through all numbers before the current number
		while (temp < *(ptr + j) && j >= 0)
		{
			// Moves the number to the right
			*(ptr + (j + 1)) = *(ptr + j);
			j--;
		}

		// Inserts the temporary number
		*(ptr + (j + 1)) = temp;
	}
	return 0;
}