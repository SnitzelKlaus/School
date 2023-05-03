#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <time.h>
#include "BubbleSort.h"
#include "SelectionSort.h"
#include "InsertionSort.h"

#define TEST_SIZE 100000

void main() 
{
	//SelectionSortTest();
	InsertionSortTest();

}

int SelectionSortTest()
{
	int arr[TEST_SIZE];

	int i;
	for (i = 0; i < TEST_SIZE; i++) {
		arr[i] = rand() % 100;
	}

	for (i = 0; i < TEST_SIZE; i++) {
		printf("%d\n", arr[i]);
	}

	printf("\n");

	// Timer
	clock_t start, end;
	double cpu_time_used;

	start = clock();
	selectionSort(&arr, TEST_SIZE);
	end = clock();

	cpu_time_used = ((double)(end - start)) / CLOCKS_PER_SEC;

	for (i = 0; i < TEST_SIZE; i++) {
		printf("%d\n", arr[i]);
	}

	// Print time
	printf("Time(seconds): %f\n", cpu_time_used);

	return 0;
}

int InsertionSortTest()
{
	int arr[TEST_SIZE];

	int i;
	for (i = 0; i < TEST_SIZE; i++) {
		arr[i] = rand() % 100;
	}

	for (i = 0; i < TEST_SIZE; i++) {
		printf("%d\n", arr[i]);
	}
	
	printf("\n");

	// Timer
	clock_t start, end;
	double cpu_time_used;

	start = clock();
	insertionSort(&arr, TEST_SIZE);
	end = clock();

	cpu_time_used = ((double)(end - start)) / CLOCKS_PER_SEC;

	for (i = 0; i < TEST_SIZE; i++) {
		printf("%d\n", arr[i]);
	}

	// Print time
	printf("Time(seconds): %f\n", cpu_time_used);

	return 0;
}