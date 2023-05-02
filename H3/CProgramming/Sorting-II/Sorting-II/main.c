#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include "BubbleSort.h";
#include "SelectionSort.h";
#include "InsertionSort.h";

void main() 
{
	SelectionSortTest();
}

int SelectionSortTest()
{
	int arr[] = { 12, 11, 13, 5, 6 };
	int length = sizeof(arr) / sizeof(arr[0]);

	int i;
	for (i = 0; i < length; i++) {
		printf("%d\n", arr[i]);
	}

	printf("\n");

	selectionSort(&arr, length);

	for (i = 0; i < length; i++) {
		printf("%d\n", arr[i]);
	}
}

int InsertionSortTest()
{
	int arr[] = { 12, 11, 13, 5, 6 };
	int length = sizeof(arr) / sizeof(arr[0]);

	int i;
	for (i = 0; i < length; i++) {
		printf("%d\n", arr[i]);
	}
	
	printf("\n");

	insertionSort(arr, length);

	for (i = 0; i < length; i++) {
		printf("%d\n", arr[i]);
	}
}