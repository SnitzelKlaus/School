#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include ".\Algorythms\BubbleSort.h"
#include ".\Algorythms\SelectionSort.h"
#include ".\Algorythms\InsertionSort.h"

void main()
{
	printf("Hello World!\n");

	int i;

	for (i = 0; i < 10; i++)
	{
		printf("%d\n", i);
	}

	
}

// int SelectionSortTest()
// {
// 	int arr[] = {12, 11, 13, 5, 6};
// 	int length = sizeof(arr) / sizeof(arr[0]);

// 	int i;
// 	for (i = 0; i < length; i++)
// 	{
// 		printf("%d\n", arr[i]);
// 	}

// 	printf("\n");

// 	// selectionSort(&arr, length);

// 	for (i = 0; i < length; i++)
// 	{
// 		printf("%d\n", arr[i]);
// 	}
// }

// int InsertionSortTest()
// {
// 	int arr[] = {12, 11, 13, 5, 6};
// 	int length = sizeof(arr) / sizeof(arr[0]);

// 	int i;
// 	for (i = 0; i < length; i++)
// 	{
// 		printf("%d\n", arr[i]);
// 	}

// 	printf("\n");

// 	insertionSort(arr, length);

// 	for (i = 0; i < length; i++)
// 	{
// 		printf("%d\n", arr[i]);
// 	}
// }