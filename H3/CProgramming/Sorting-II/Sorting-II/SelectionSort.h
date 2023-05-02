#include <stdio.h>
#include <stdlib.h>
#include <string.h>

selectionSort(int length, int* ptr) 
{
	int i, j, swapV;
	int* tmp;

	for (i = 0; i < length; i++)
	{
		tmp = (ptr + i);

		for (j = 0; j < i; j++) 
		{
			if (*(ptr + j) < *tmp)
			{
				tmp = (ptr + j);
			}
		}
		swapV = *tmp;
		tmp = *(ptr + i);
		ptr[i]= swapV;
	}
}