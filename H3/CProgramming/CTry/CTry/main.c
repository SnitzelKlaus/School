#include <stdio.h>
#include <string.h>
#include "Reverse.h";
#include "Bubble.h";
#include "Word.h";


int main()
{
	//firstAssignment();
	secondAssignment();
	//thirdAssignment();
	//fourthAssignment();
}

int firstAssignment()
{
	// creates string and gets length
	char text[] = "Hello World!";
	int length = strlen(text);

	// print string and length
	printf("%s\n", text);
	printf("%i\n", length);

	// reverse string
	rString(&text, length);

	// prints length reversed string
	printf("%s\n", text);
	printf("%i\n", length);

	return 0;
}

int secondAssignment()
{
	int arr[] = { 44,2,3,56,432,343,4343,2,32,2,3 };
	int length = sizeof(arr) / sizeof(int);
	
	printf("%d\n", length);

	bubbleSort(length, &arr);
	
	// prints array
	for (int i = 0; i < length; i++)
	{
		printf("%i ", arr[i]);
	}

	return 0;
}

int thirdAssignment()
{
	char text[] = "Jeg kan godt lide kage og toffee mint karameller";
	int length = strlen(text);

	printf("%s\n", text);

	// count words
	int words = countWords(&text, length);

	printf("%d", words);

	return 0;
}

int fourthAssignment()
{
	char text[] = "Jeg kan godt lide toffee mint bolsjer";
	int length = strlen(text);

	printf("%s\n", text);

	orderWords(&text, length);

	printf("%s\n", text);

	return 0;
}
